using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CustomModels
{
   public class OrgCustomModel
    {
       public Org org { get; set; }
       public Member member { get; set; }
       public OrgChief chief { get; set; }
       public int OrgType { get; set; }
    }
}
