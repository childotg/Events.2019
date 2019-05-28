using Newtonsoft.Json;
using Ocelot.Middleware;
using Ocelot.Middleware.Multiplexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CloudDDDR
{
    public class SalesOfAggregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<DownstreamContext> responses)
        {
            var customer = JsonConvert.DeserializeObject<CustomerItem>
                (await responses.First().DownstreamResponse.Content
                .ReadAsStringAsync());
            var sales = JsonConvert.DeserializeObject<SalesItem[]>
                (await responses.Skip(1).First().DownstreamResponse.Content
                .ReadAsStringAsync());
            return new DownstreamResponse(new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(new
                {
                    CustomerID = customer.customerID,
                    CustomerName = $"{customer.firstName} {customer.lastName}",
                    CustomerSales = sales.Sum(p => p.subTotal)
                }, Formatting.Indented))
            });

        }
    }
    public class CustomerItem
    {
        public int customerID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }

    public class SalesItem
    {
        public double subTotal { get; set; }
    }
}
