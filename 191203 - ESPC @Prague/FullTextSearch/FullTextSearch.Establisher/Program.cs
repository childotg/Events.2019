using System;
using System.Threading.Tasks;

namespace FullTextSearch.Establisher
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await new EstablisherTask().RunAsync();
        }
    }
}
