using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Manager
{
  public  class DashboardManager
    {

      DAL.Interface.IDashboardDAL Dal = new DAL.Concret.DashboardDal();

      public string GetUserRoleByMemberAndOrg(string userEmail, int orgId)
      {
          return Dal.GetUserRoleByMemberAndOrg(userEmail, orgId);
      }

      public IList<Domain.OrgMember> GetOrgMemberLink(string userEmail)
      {
          return Dal.GetOrgMemberLink(userEmail);
      }
      public void InsertRoleandOrg(string userId, string roleId, int orgId)
      {
          Dal.InsertRoleandOrg(userId, roleId, orgId);
      }
    }
}
