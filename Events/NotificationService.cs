using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class NotificationService
    {
        public void OnFoodPrepared(object source, EventArgs eventArgs)
        {
            Console.WriteLine("NotificationService: your food is prepared.");
        }
    }
}
