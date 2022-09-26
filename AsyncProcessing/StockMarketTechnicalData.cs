using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProcessing
{
    public class StockMarketTechnicalData
    {
        public StockMarketTechnicalData(string stockSymbol, DateTime dateTimeStart, DateTime dateTimeEnd)
        {
            // Get data from remote data source
        }

        public decimal[] GetOpeningPrices()
        {
            decimal[] data;

            Console.WriteLine($"Method name: {nameof(GetOpeningPrices)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}.");

            Thread.Sleep(1000);

            data = new decimal[] {};

            return data;
        }

        public decimal[] GetClosingPrices()
        {
            decimal[] data;

            Console.WriteLine($"Method name: {nameof(GetClosingPrices)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}.");

            Thread.Sleep(2000);

            data = new decimal[] { };

            return data;
        }

        public decimal[] GetPriceHighs()
        {
            decimal[] data;

            Console.WriteLine($"Method name: {nameof(GetPriceHighs)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}.");

            Thread.Sleep(1000);

            data = new decimal[] { };

            return data;
        }

        public decimal[] GetPriceLows()
        {
            decimal[] data;

            Console.WriteLine($"Method name: {nameof(GetPriceLows)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}.");

            Thread.Sleep(1000);

            data = new decimal[] { };

            return data;
        }

        public decimal[] CalculateStockStats()
        {
            decimal[] data;

            Console.WriteLine($"Method name: {nameof(CalculateStockStats)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}.");

            Thread.Sleep(10000);

            data = new decimal[] { };

            return data;
        }

        public decimal[] CalculateFastMovingAverages()
        {
            decimal[] data;

            Console.WriteLine($"Method name: {nameof(CalculateFastMovingAverages)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}.");

            Thread.Sleep(6000);

            data = new decimal[] { };

            return data;
        }

        public decimal[] CalculateSlowMovingAverages()
        {
            decimal[] data;

            Console.WriteLine($"Method name: {nameof(CalculateSlowMovingAverages)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}.");

            Thread.Sleep(7000);

            data = new decimal[] { };

            return data;
        }

        public decimal[] CalculateUpperBoundBollingBand()
        {
            decimal[] data;

            Console.WriteLine($"Method name: {nameof(CalculateUpperBoundBollingBand)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}.");

            Thread.Sleep(4000);

            data = new decimal[] { };

            return data;
        }

        public decimal[] CalculateLowerBoundBollingBand()
        {
            decimal[] data;

            Console.WriteLine($"Method name: {nameof(CalculateLowerBoundBollingBand)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}.");

            Thread.Sleep(5000);

            data = new decimal[] { };

            return data;
        }
    }
}
