namespace DelegateDemo
{

    //delegate void LogDel(string message, DateTime dateTime); // Declare delegate
    internal class Program
    {
        // 1. Declare delegate
        delegate void LogDel(string message, DateTime dateTime); 

        delegate int AddTotal(int fistNo, int secondNo);

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World! Please enter your name");

            // instantiate the class containing the method that will be used by the delegate - for delegate to use instance method, insted of statid method
            Log log = new Log(); 

            // Invoke delegate
            AddTotal addTotal = new AddTotal(Add);// Add;  //Pass the method to delegate

            int total = addTotal(10, 20);// addTotal.Invoke(19, 20);

            Console.WriteLine("Invokded by deletegate, the total is {0}", total);
            /**  */

            //LogDel logDel = new LogDel(log.LogTexttoScreen2); // create an instance of the delegate and pass the method

            var name = Console.ReadLine();

            //logDel("passed...again!!"); // invoke the delegate with the message passed in.
            //logDel(name!, DateTime.Now);// invoke the delegate



            /** Multicasting delegate*/
            
            LogDel LogTextToScreen, LogTextToScreen2; // Instantiate delegate
              
            // Pass the method to delegate to be invokded
            //
            LogTextToScreen = log.LogTextToScreen; // new LogDel(log.LogTextToScreen); // use instance method, instead of static method
            LogTextToScreen2 = new LogDel(log.LogTexttoScreen2);


            //LogDel multiLogDel = LogTextToScreen + LogTextToScreen2;

            // OR
            LogDel multiLogDel = LogTextToScreen;
            multiLogDel += LogTextToScreen2;

            // Invoke multicast delegate
            //
            multiLogDel(name!, DateTime.Now);

            // alternative way to invoke the delegate by passing the delegate, as an argument, to the static method
            //
            LogText(multiLogDel, name!); // passing multicase delegate to the static method - Two method executed

            LogText(LogTextToScreen, name!); // passing single delegate to the static method - One method executed

            Console.ReadKey();
        }

        static void LogText(LogDel logDel, string text)
        {
            logDel(text, DateTime.Now);
        }

        static int Add(int a, int b)
        {
            return a + b;
        }

        
    }

    public class Log
    {
        public void LogTextToScreen(string text, DateTime dateTime) // The method that is called when the delegate is invokde
        {
            Console.WriteLine($"{text}1 entered at {dateTime} - frist method executed!");
        }

        public void LogTexttoScreen2(string text, DateTime dateTime)
        {
            Console.WriteLine($"at {dateTime} {text}2 is entered - second method executed!");
        }
    }
}