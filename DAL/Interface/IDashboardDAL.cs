using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
   public interface IDashboardDAL
    {
       string GetUserRoleByMemberAndOrg(string userEmail, int orgId);

       IList<Domain.OrgMember> GetOrgMemberLink(string userEmail);

       void InsertRoleandOrg(string userId, string roleId, int orgId);
      

    }
}
