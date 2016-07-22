using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Member
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string LName { get; set; }
        public string MName { get; set; }
        public Nullable<int> Title { get; set; }
        public Nullable<int> Gender { get; set; }
        public Nullable<int> CountryOfBirth { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public Nullable<decimal> IDNumber { get; set; }
        public string PassportNumber { get; set; }
        public Nullable<decimal> HomeTelNo { get; set; }
        public Nullable<decimal> WorkTelNo { get; set; }
        public Nullable<decimal> CellularNo { get; set; }
        public string PrimeryEmail { get; set; }
        public string AlternativeEmail { get; set; }
        public string FacebookId { get; set; }
        public string Twitter { get; set; }
        public string ResidentialAdd { get; set; }
        public string PostalAdd { get; set; }
    }
}
