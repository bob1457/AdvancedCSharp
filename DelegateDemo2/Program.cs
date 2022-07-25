namespace DelegateDemo2
{
    /// <summary>
    /// Covariance:
    /// Contravariance:
    /// </summary>
    public class Program
    {
        delegate Car CarFactoryDel(int id, string name);
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

            Console.WriteLine();

            Console.WriteLine($"Object type: {evCar.GetType()}");
            Console.WriteLine($"Car details: {evCar.GetCarDetails()}");

            Console.ReadKey();
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
