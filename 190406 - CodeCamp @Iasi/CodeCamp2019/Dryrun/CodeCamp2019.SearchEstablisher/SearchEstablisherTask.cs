using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System;
using System.Threading.Tasks;

namespace CodeCamp2019.SearchEstablisher
{
    internal class SearchEstablisherTask
    {
        public SearchEstablisherTask()
        {
        }

        internal async Task RunAsync()
        {
            var searchService = "azure-demos";
            var searchKey = "[removed]";
            var searchIndex = "applications";
            var connectionString = "[removed]";
            var newTenant = $"{searchIndex}-t2";

            var client = new SearchServiceClient(searchService, new SearchCredentials(searchKey));
            var ds = new DataSource(newTenant, DataSourceType.AzureSql,
                new DataSourceCredentials(connectionString), new DataContainer("dbo.vApplications"), null,
                new HighWaterMarkChangeDetectionPolicy("AppLastUpdate"), null, null);
            await client.DataSources.CreateOrUpdateAsync(ds);

            var indexer = new Indexer(newTenant, newTenant, "applications", null,
                new IndexingSchedule(TimeSpan.FromMinutes(5)));
            await client.Indexers.CreateOrUpdateAsync(indexer);
            

        }
    }
}