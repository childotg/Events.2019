using Nancy;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CustomersAPI
{
    public class Customers : NancyModule
    {
        public Customers() : base("/api")
        {


            Get["/customers/{take}"] = x =>
            {
                using (var ctx = new dataEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    var res = ctx.Customer.Take((int)x.take).Include("CustomerAddress").ToArray();
                    return Response.AsJson<Customer[]>(res);
                }
            };

            Get["/customer/{id}"] = x =>
            {
                using (var ctx = new dataEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    var res = ctx.Customer.Find((int)x.id);
                    return Response.AsJson<Customer>(res);
                }
            };

        }
    }
}