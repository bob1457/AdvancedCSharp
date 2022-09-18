using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class AppService
    {
        public void OnFoodPrepared(object source, EventArgs args) // It ha the same signature as the delegate
        {
            Console.WriteLine($"AppService: your food is ready....");
        }
    }
}
