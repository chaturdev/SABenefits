using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
   public interface IOrgDAL
    {

       int CreateOrg(Domain.CustomModels.OrgCustomModel model);

       int IsMemberExsit(string fName, string lName, int gender, int cob, DateTime dob, decimal idNumber, decimal workTelNo);
       void CreateIndv(Domain.CustomModels.OrgCustomModel model);
    }
}
