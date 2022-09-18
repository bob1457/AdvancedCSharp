using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class Ladder : HardwareItem, ILadder
    {
        public string LadderBrandName { get; set; }
    }
}
