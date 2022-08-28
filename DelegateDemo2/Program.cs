namespace DelegateDemo2
{
    /// <summary>
    /// Covariance:
    /// Contravariance:
    /// </summary>
    public class Program
    {
        delegate Car CarFactoryDel(int id, string name);

        delegate void LogICECarDeatails(ICECar car);
        delegate void LogEVCarDetails(EVCar car);


        static void Main(string[] args)
        {
            Console.WriteLine("Covariance and Contravariance Delegate Demo");
            Console.WriteLine("_________________________________________________");
            Console.WriteLine();
            
            //Covriant
            //            
                        CarFactoryDel carFactoryDel = CarFactory.ReturnICECar;
                        Car iceCar = carFactoryDel.Invoke(1, "Audi R8"); // carFactoryDel(1, "Audi R8");
             
                        Console.WriteLine($"Object type: {iceCar.GetType()}");
                        Console.WriteLine($"Car details: { iceCar.GetCarDetails()}");


                        carFactoryDel = CarFactory.ReturnEVCar;
             
                        Car evCar = carFactoryDel(2, "Tesla Model-S");

                                    //Console.WriteLine();
                                    //Console.WriteLine("*********************** Covariance Demo ***********************");
                                    //Console.WriteLine();

                                    //Console.WriteLine($"Object type: {evCar.GetType()}");
                                    //Console.WriteLine($"Car details: {evCar.GetCarDetails()}");
            

            //Contravriant
            //
            Console.WriteLine();
            Console.WriteLine("*********************** Contravariance Demo ***********************");
            Console.WriteLine();

            LogICECarDeatails logICECarDeatails = LogCarDetails;
            logICECarDeatails(iceCar as ICECar);

            LogEVCarDetails logEVCarDetails = LogCarDetails;
            logEVCarDetails(evCar as EVCar); 

            Console.ReadKey();
        }

        static void LogCarDetails(Car car)
        {
            if (car is ICECar)
            {
                Console.WriteLine($"Object type: {car.GetType()}");
                Console.WriteLine($"Car details: {car.GetCarDetails()}");
            }
            else if (car is EVCar)
            {
                Console.WriteLine($"Object type: {car.GetType()}");
                Console.WriteLine($"Car details: {car.GetCarDetails()}");
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }

    public static class CarFactory
    {
        public static ICECar ReturnICECar(int id, string name)
        {
            return new ICECar { Id = id, Name = name };
        }

        public static EVCar ReturnEVCar(int id, string name)
        {
            return new EVCar { Id = id, Name = name };
        }
    }

    public class ICECar : Car
    {
        public override string GetCarDetails()
        {
            return $"{base.GetCarDetails()} - Internal Combustion Engine";

        }
    }

    public class EVCar : Car
    {
        public override string GetCarDetails()
        {
            return $"{base.GetCarDetails()} - Electric Motor";

        }
    }
    public abstract class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual string GetCarDetails() 
        {
            return $"{Id} - {Name}";
        }
    }
}
