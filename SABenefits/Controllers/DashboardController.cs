using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SABenefits.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            ViewBag.Role = Session["Role"].ToString();
            ViewBag.userEmail = Session["UserEmail"].ToString();
            return View();
        }

        public PartialViewResult _Dashboard()
        {
            return PartialView();
        }
    }
}