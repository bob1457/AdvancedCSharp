using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class Brush : HardwareItem, IBrush
    {
        public string BrushBrandName { get; set; }
    }
}
