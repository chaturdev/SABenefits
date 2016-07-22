using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concret
{
   public class DashboardDal:Interface.IDashboardDAL
    {
       SABenefitsEntities1 dbEntites = new SABenefitsEntities1();

        public string GetUserRoleByMemberAndOrg(string userEmail, int orgId)
        {
            return dbEntites.sp_GetRolebyMemberandorg(userEmail, orgId).FirstOrDefault();
        }

        public IList<Domain.OrgMember> GetOrgMemberLink(string userEmail)
        {
            var Items = dbEntites.sp_MemberOrgLinkCount11(userEmail).ToList();
            IList<Domain.OrgMember> values=new List<Domain.OrgMember>();

            if (Items.Count() > 0)
            {
                values = Items.Select(x => new Domain.OrgMember { OrgId = Convert.ToInt32(x.OrgId), OrgName = x.OrgName }).ToList();
            }
            return values;
        }

   public  void InsertRoleandOrg(string userId, string roleId, int orgId)
        {
            dbEntites.sp_InsertRoleWithOrg(userId, roleId, orgId);

        }
    }
}
