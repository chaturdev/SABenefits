//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrgTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrgTbl()
        {
            this.OrgChiefAdmins = new HashSet<OrgChiefAdmin>();
        }
    
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
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrgChiefAdmin> OrgChiefAdmins { get; set; }
    }
}
