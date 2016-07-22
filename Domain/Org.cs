using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Org
    {
        public int OrgId { get; set; }
        public Nullable<int> ParentOrgId { get; set; }
        public string OrgName { get; set; }
        public Nullable<int> OrgType { get; set; }
        public Nullable<bool> IsOrgReg { get; set; }
        public string RegType { get; set; }
        public string RegNumber { get; set; }
        public string OrglegalName { get; set; }
        public Nullable<System.DateTime> EstablishedDate { get; set; }
        public Nullable<System.DateTime> InactiveDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}
