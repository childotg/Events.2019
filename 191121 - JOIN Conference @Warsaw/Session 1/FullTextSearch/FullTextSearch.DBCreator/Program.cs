using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace FullTextSearch.DBCreator
{
    class Program
    {

        static async Task Main(string[] args)
        {
            var factory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("FullTextSearch.DBCreator", LogLevel.Debug)
                    .AddConsole();
            });

            await new DBCreatorTask(factory,args[0],args[1]).RunAsync();
        }
    }
}
