// See https://aka.ms/new-console-template for more information
using AsyncProcessing;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Async Processing");
        Console.WriteLine();

        Console.WriteLine($"Method name: Main, Thread {Thread.CurrentThread.ManagedThreadId}");

        StockMarketTechnicalData stockMarketTechnicData = new StockMarketTechnicalData("STAZA", new DateTime(2010, 1, 1), new DateTime(2020, 1, 1));

        DateTime dateTimeStart = DateTime.Now;
        Console.WriteLine(dateTimeStart);

        // Call methods syncronousely - all method run sequentially in the same thread, the total time is the sum of each individual method
        /*
        decimal[] data1 = stockMarketTechnicData.GetOpeningPrices();
        decimal[] data2 = stockMarketTechnicData.GetClosingPrices();
        decimal[] data3 = stockMarketTechnicData.GetPriceHighs();
        decimal[] data4 = stockMarketTechnicData.GetPriceLows();
        decimal[] data5= stockMarketTechnicData.CalculateFastMovingAverages();
        decimal[] data6 = stockMarketTechnicData.CalculateSlowMovingAverages();
        decimal[] data7 = stockMarketTechnicData.CalculateUpperBoundBollingBand();
        decimal[] data8 = stockMarketTechnicData.CalculateLowerBoundBollingBand();
        decimal[] data9 = stockMarketTechnicData.CalculateStockStats();
        */

        // Call methods asyncronousely all tasks run concurrenlty in diffrent thread, the total time is the time spent of the longest running task
        //
        List<Task<decimal[]>> tasks = new List<Task<decimal[]>>();

        Task<decimal[]> getOpeningPricesTask = Task.Run(() => stockMarketTechnicData.GetOpeningPrices());
        Task<decimal[]> getClosingPricesTask = Task.Run(() => stockMarketTechnicData.GetClosingPrices());
        Task<decimal[]> getPricesHighsTask = Task.Run(() => stockMarketTechnicData.GetPriceHighs());
        Task<decimal[]> getPricesLowsTask = Task.Run(() => stockMarketTechnicData.GetPriceLows());
        Task<decimal[]> calculateFastMovingAverages = Task.Run(() => stockMarketTechnicData.CalculateFastMovingAverages());
        Task<decimal[]> calculateSlowMovingAverages = Task.Run(() => stockMarketTechnicData.CalculateSlowMovingAverages());
        Task<decimal[]> calculateUpperBoundBollingBand = Task.Run(() => stockMarketTechnicData.CalculateUpperBoundBollingBand());
        Task<decimal[]> calculateLowerBoundBollingBand = Task.Run(() => stockMarketTechnicData.CalculateLowerBoundBollingBand());
        Task<decimal[]> calculateStockStats = Task.Run(() => stockMarketTechnicData.CalculateStockStats());

        tasks.Add(getOpeningPricesTask);
        tasks.Add(getClosingPricesTask);
        tasks.Add(getPricesLowsTask);
        tasks.Add(getPricesHighsTask);
        tasks.Add(calculateFastMovingAverages);
        tasks.Add(calculateSlowMovingAverages);
        tasks.Add(calculateUpperBoundBollingBand);
        tasks.Add(calculateLowerBoundBollingBand);
        tasks.Add(calculateStockStats);

        Task.WaitAll(tasks.ToArray());

        decimal[] data1 = tasks[0].Result;
        decimal[] data2 = tasks[1].Result;
        decimal[] data3 = tasks[2].Result;
        decimal[] data4 = tasks[3].Result;
        decimal[] data5 = tasks[0].Result;
        decimal[] data6 = tasks[1].Result;
        decimal[] data7 = tasks[2].Result;
        decimal[] data8 = tasks[3].Result;
        decimal[] data9 = tasks[3].Result;

        DateTime dateTimeEnd = DateTime.Now;
        Console.WriteLine(dateTimeEnd);

        TimeSpan timeSpan = dateTimeEnd.Subtract(dateTimeStart);

        Console.WriteLine($"Total time for operations to complete took {timeSpan.Seconds} seconds.");

        DisplayDataChart(data1, data2, data3, data4, data5, data6, data7, data8, data9);

        Console.ReadKey();
    }

    public static void DisplayDataChart(decimal[] data1, decimal[] data2, decimal[] data3, decimal[] data4, decimal[] data5, decimal[] data6, decimal[] data7, decimal[] data8, decimal[] data9)
    {
        Console.WriteLine($"Data is displayed in charts....");
    }
}