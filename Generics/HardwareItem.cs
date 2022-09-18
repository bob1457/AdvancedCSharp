using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseApi;

namespace Generics
{
    public abstract class HardwareItem : IEntityPrimaryProperties, IEntityAdditionalProperties
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public decimal UnitValue { get; set; }
    }
}
