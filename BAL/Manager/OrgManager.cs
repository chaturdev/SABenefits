using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Concret;
using DAL.Interface;
using Domain;
using Domain.CustomModels;

namespace BAL.Manager
{
   public class OrgManager
    {

       IOrgDAL dal;
       public OrgManager()
       {
           dal = new OrgDAL();
       }

       public int CreateOrg(OrgCustomModel model)
       {
           try
           {
             return  dal.CreateOrg(model);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public int IsMemberExsit(string fName, string lName, int gender, int cob, DateTime dob, decimal idNumber, decimal workTelNo)
       {

           try
           {
               return dal.IsMemberExsit(fName, lName, gender, cob, dob, idNumber, workTelNo);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public void CreateIndv(Domain.CustomModels.OrgCustomModel model)
       {
           try
           {
               dal.CreateIndv(model);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
    }
}
