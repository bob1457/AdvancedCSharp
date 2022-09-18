using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseApi
{
    public class QueueEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
    
}
