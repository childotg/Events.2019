using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CodeCamp2019.DBCreator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await new DBCreatorTask(
                new LoggerFactory().AddConsole(),
                args[0],args[1]).RunAsync();
        }
    }
}
