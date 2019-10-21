using System;
using System.Threading;

namespace Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Hello World! It's {DateTime.UtcNow}");
            Thread.Sleep(60000);
        }
    }
}
