using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class FoodOrderingService
    {
        public delegate void FoodPeparedEventHandler(object source, EventArgs args); // Delcare delegate

        public event FoodPeparedEventHandler FoodPepared; // Declare event based on the delegate (the event is the type of the delegate)

        public void PrpareOrder(Order order) // public method of service
        {
            Console.WriteLine($"Preparing your order, please wait...");
            Thread.Sleep(5000);

            OnFoodPrepared(); // Raise the event when the food is prepared
        }

        private void OnFoodPrepared()
        {   
            if(FoodPepared is not null)         
                FoodPepared(this, null); // It has the same signature as the delegate
        }
    }

    public class Order
    {
        public string Item { get; set; }
    }
}
