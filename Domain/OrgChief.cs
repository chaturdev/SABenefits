using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
  public  class OrgChief
    {
        public int ChiefId { get; set; }
        public Nullable<int> OrgId { get; set; }
        public Nullable<int> OrgRole { get; set; }
        public Nullable<System.DateTime> AppointmentDate { get; set; }
        public Nullable<System.DateTime> TerminationDate { get; set; }
        public Nullable<int> IndvDetailId { get; set; }
    }
}
