using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concret
{
  public  class OrgDAL:Interface.IOrgDAL
    {
      SABenefitsEntities1 dbcontext;
     public OrgDAL()
      {
          dbcontext = new SABenefitsEntities1();
      }

      public int CreateOrg(Domain.CustomModels.OrgCustomModel model)
      {
          try
          {
              dbcontext.sp_InsertUpdateOrg(model.org.OrgId, model.org.ParentOrgId, model.org.OrgName,
                  model.org.OrgType, model.org.IsOrgReg, model.org.RegType, model.org.RegNumber,
                  model.org.OrglegalName, model.org.EstablishedDate, model.org.InactiveDate,
                  model.org.CreatedBy, model.org.CreatedDate, model.org.ModifiedBy, model.org.ModifiedDate);
              int OrgId = dbcontext.OrgTbls.Max(p => p.OrgId);
              return OrgId;

          }catch(Exception ex){
              throw ex;
          }

      }

      public int IsMemberExsit(string fName, string lName, int gender, int cob, DateTime dob, decimal idNumber, decimal workTelNo)
      {
          try
          {
             var memberId= dbcontext.sp_IsMemberExist(fName, lName, gender, cob, dob, idNumber, workTelNo);
             if (memberId.Count() == 0)
             {
                 return 0;
             }
             else
             {
                 return Convert.ToInt32(memberId.FirstOrDefault());
             }
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public void CreateIndv(Domain.CustomModels.OrgCustomModel model){
           dbcontext.sp_insertupdateIndv(model.member.Id, model.member.Fname, model.member.LName, model.member.MName, model.member.Title,
                  model.member.Gender, model.member.CountryOfBirth, model.member.DOB, model.member.IDNumber, model.member.PassportNumber, model.member.HomeTelNo, model.member.CellularNo, model.member.PrimeryEmail,
                  model.member.WorkTelNo, model.member.AlternativeEmail, model.member.FacebookId, model.member.Twitter,
                  model.member.ResidentialAdd, model.member.PostalAdd, model.org.OrgId);
           int memberId = dbcontext.IndvidualTbls.Max(p => p.Id);
              dbcontext.sp_InsertUpdateChief(model.chief.ChiefId, model.org.OrgId, model.chief.OrgRole, model.chief.AppointmentDate, model.chief.TerminationDate, memberId);
      }
    }
}
