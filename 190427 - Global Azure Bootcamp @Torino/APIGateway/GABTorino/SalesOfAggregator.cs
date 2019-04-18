using Newtonsoft.Json;
using Ocelot.Middleware;
using Ocelot.Middleware.Multiplexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GABTorino
{
    public class SalesOfAggregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<DownstreamResponse> responses)
        {
            var c = JsonConvert.DeserializeObject<CustomerModel>(await responses[0].Content.ReadAsStringAsync());
            var s = JsonConvert.DeserializeObject<SalesModel[]>(await responses[1].Content.ReadAsStringAsync());
            return new DownstreamResponse(new HttpResponseMessage()
            {
                Content=new StringContent(JsonConvert.SerializeObject(new
                {
                    CustomerID=c.customerID,
                    CustomerName=$"{c.firstName} {c.lastName}",
                    CustomerSales=s.Sum(p=>p.subTotal)
                }))
            });
        }
    }

    public class CustomerModel
    {
        public int customerID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }

    public class SalesModel
    {
        public double subTotal { get; set; }
    }
}
