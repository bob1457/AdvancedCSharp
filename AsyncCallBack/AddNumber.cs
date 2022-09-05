using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncCallBack
{
    public static class AddNumber
    {
        public static async Task<int> Add(Func<int, int, Task<int>> Sum)
        {
            Console.WriteLine("Add() running on thread {0}", Environment.CurrentManagedThreadId);
            //await Task.Delay(2000);

            return await Task.Run(() => Sum(3, 5));

        }
    }
}
