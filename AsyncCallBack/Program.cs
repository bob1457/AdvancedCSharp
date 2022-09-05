using AsyncCallBack;

internal class Program
{     
    private async static Task Main(string[] args)
    {
        Console.WriteLine("Async Call Back");
        Console.WriteLine("");

       
        Console.WriteLine("------ Async Delegate Invocation -------");

        //Print out the ID of the executing thread
        Console.WriteLine("Main() invoked on thread {0}", Thread.CurrentThread.ManagedThreadId);


        await AddNumber.Add(async (int a, int b) =>
        {
            var sum = a + b;
            await Task<int>.Run(() => Console.WriteLine($"Result:{sum}"));
            return sum;

        }

        );

        //Do some other work on priamry thread..
        //
        Console.WriteLine("Doing some work in Main()!");

        await HelloWorldAsync(async (string inputText) =>
            await Task.Run(() => Console.WriteLine(inputText))
        );

        static async Task HelloWorldAsync(Func<string, Task> task)
        {
            //Thread.Sleep(5000);
            Console.WriteLine("HelloWorldAsync() running on thread {0}", Environment.CurrentManagedThreadId);
            await task("Hello world...but async!");
        }


    }

    
}

//Ref: https://anthonygiretti.com/2021/05/01/c-make-your-delegates-asynchronous-from-synchronous-delegates/





