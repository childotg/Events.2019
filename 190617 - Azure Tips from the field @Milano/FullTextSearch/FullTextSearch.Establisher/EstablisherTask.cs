using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System;
using System.Threading.Tasks;

namespace FullTextSearch.Establisher
{
    internal class EstablisherTask
    {
        public EstablisherTask()
        {
        }

        internal async Task RunAsync()
        {
            var searchName = "searchdemos";
            var cred = new SearchCredentials("[removed]");
            var cl = new SearchServiceClient(searchName, cred);

            var ds = new DataSource("tenant-2",
                DataSourceType.AzureSql,
                new DataSourceCredentials("[removed]"),
                new DataContainer("dbo.vApplications"),
                null, new HighWaterMarkChangeDetectionPolicy("AppLastUpdate"));
            await cl.DataSources.CreateOrUpdateAsync(ds);

            var indexer = new Indexer("tenant-2", "tenant-2", "applications", null, null,
                new IndexingSchedule(TimeSpan.FromMinutes(5)));
            await cl.Indexers.CreateOrUpdateAsync(indexer);

                


        }
    }
}