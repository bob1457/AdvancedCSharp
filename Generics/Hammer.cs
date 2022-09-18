using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class Hammer : HardwareItem, IHammer
    {
        public string HammerBrandName { get; set; }
    }
}
