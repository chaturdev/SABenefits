using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SABenefits.Models;

namespace SABenefits.Controllers
{
    public class HomeController : Controller
    {
         private ApplicationSignInManager _signInManager;
         private ApplicationUserManager _userManager;


          public HomeController()
        {
        }

          public HomeController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult CreateOrg()
        {
            BAL.Manager.MValueManager manager = new BAL.Manager.MValueManager();
            var allmasterData=manager.GetAllMasterValues();
            var orgtype = allmasterData.Where(c => c.MasterTypeId == 1);

            TempData["title"] = allmasterData.Where(c => c.MasterTypeId == 2).ToList(); ;

            TempData["gender"] = allmasterData.Where(c => c.MasterTypeId == 3).ToList();
            TempData["COB"] = allmasterData.Where(c => c.MasterTypeId == 4).ToList();
          TempData.Keep("title");
          TempData.Keep("gender");
          TempData.Keep("COB");
            ViewBag.OrgType = orgtype.ToList().Select(c => new SelectListItem
            {
                Text = c.Value,
                Value = c.MasterValueId.ToString()
            }).ToList();

          //  ViewBag.OrgType = new SelectList(orgtype, "MasterValueId", "Value");
            return View();

        }

        public PartialViewResult _CreateOrg()
        {
            BAL.Manager.MValueManager manager = new BAL.Manager.MValueManager();
            var orgtype = manager.GetAllMasterValues();
            //ViewBag.OrgType = orgtype.ToList().Select(c => new SelectListItem
            //{
            //    Text = c.Value,
            //    Value = c.MasterValueId.ToString()
            //}).ToList();

            ViewBag.OrgType = new SelectList(orgtype, "MasterValueId", "Value");
            return PartialView();
        }


        [HttpPost]
        public PartialViewResult _CreateOrg(Domain.CustomModels.OrgCustomModel model)
        {
            //if (ModelState.IsValid)
            //{
                BAL.Manager.OrgManager manager = new BAL.Manager.OrgManager();

            int orgId=    manager.CreateOrg(model);
            model.org.OrgId = orgId;
            //}
            fillViewBag();
            return PartialView("_CreateCheif",model);
        }
        void fillViewBag()
        {
            var title = TempData["title"] as List<Domain.MasterValue>;
            var gender = TempData["gender"] as List<Domain.MasterValue>;
            var COB = TempData["COB"] as List<Domain.MasterValue>;
                TempData["title"] =title;

                TempData["gender"] = gender;
            TempData["COB"] = COB;
            TempData.Keep("title");
            TempData.Keep("gender");
            TempData.Keep("COB");
            ViewBag.title = title.ToList().Select(c => new SelectListItem
            {
                Text = c.Value,
                Value = c.MasterValueId.ToString()
            }).ToList();

            ViewBag.gender = gender.ToList().Select(c => new SelectListItem
            {
                Text = c.Value,
                Value = c.MasterValueId.ToString()
            }).ToList();
            ViewBag.COB = COB.ToList().Select(c => new SelectListItem
            {
                Text = c.Value,
                Value = c.MasterValueId.ToString()
            }).ToList();
        }
        public PartialViewResult _CreateCheif()
        {
          
          
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult _CreateCheif(Domain.CustomModels.OrgCustomModel model)
        {
            fillViewBag();
            BAL.Manager.OrgManager mngr = new BAL.Manager.OrgManager();
            if (ModelState.IsValid)
            {
            var mmbrid=    mngr.IsMemberExsit(model.member.Fname, model.member.LName,Convert.ToInt32(model.member.Gender),Convert.ToInt32( model.member.CountryOfBirth),Convert.ToDateTime(model.member.DOB),Convert.ToDecimal(model.member.IDNumber), Convert.ToDecimal(model.member.WorkTelNo));
            if (mmbrid != 0)
            {
                mngr.CreateIndv(model);
                return PartialView(model);
            } 
            else
            {
                RegisterViewModel rMdl = new RegisterViewModel();
                rMdl.Email = model.member.PrimeryEmail;
                rMdl.Password = "Asl@123";
                Register(rMdl,model.org.OrgId);
                if (!ModelState.IsValid)
                {
                    return PartialView(model);
                }
                else
                {
                    mngr.CreateIndv(model);
                  
                }
            }
            return PartialView(model);
            }
            else
            {
                return PartialView(model);
            }

           // return PartialView();
        }

        [AllowAnonymous]
        public  void Register(RegisterViewModel model,int orgId)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result =  UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                     SignInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                  //  UserManager.AddToRole(user.Id,"Chief");
                     BAL.Manager.DashboardManager mngr = new BAL.Manager.DashboardManager();
                     mngr.InsertRoleandOrg(user.Id, "1", orgId);
                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                     string code =  UserManager.GenerateEmailConfirmationToken(user.Id);
                     var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // UserManager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

       
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
         
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
          }
}