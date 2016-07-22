using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class MasterValue
    {
        public int MasterValueId { get; set; }
        public string Value { get; set; }
        public Nullable<int> MasterTypeId { get; set; }
    }
}
