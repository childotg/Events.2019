using System;
using System.Threading.Tasks;

namespace CodeCamp2019.SearchEstablisher
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await new SearchEstablisherTask().RunAsync();
        }
    }
}
