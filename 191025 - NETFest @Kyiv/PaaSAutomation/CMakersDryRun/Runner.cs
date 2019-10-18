using Certes;
using Certes.Acme;
using Certes.Acme.Resource;
using Microsoft.Azure.EventGrid;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.Sql.Fluent;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CMakersDryRun
{
    internal class Runner
    {
        public Runner()
        {
        }

        internal async Task RunAsync(Rootobject rootobject)
        {
            var cred = SdkContext.AzureCredentialsFactory
                .FromServicePrincipal(S.AzureClientID, S.AzureClientSecret,
                S.AzureTenantId, AzureEnvironment.AzureGlobalCloud);

            var azure = Azure.Authenticate(cred)
                .WithSubscription(S.AzureSubscription);

            var id = DateTime.UtcNow.Ticks.ToString();

            var server = azure.SqlServers
                .GetByResourceGroup(S.ResourceGroup, S.SqlServer);
            var pool = azure.SqlServers.ElasticPools
                .GetBySqlServer(server, S.SqlPool);

            var newDB = azure.SqlServers.Databases
                .Define($"t-{id}")
                .WithExistingSqlServer(server)
                .WithExistingElasticPool(pool)
                .Create();

            newDB.ImportBacpac(S.DbImage)
                .WithStorageAccessKey(S.StorageKey)
                .WithSqlAdministratorLoginAndPassword(S.SqlUser, S.SqlPassword)
                .Execute();

            var plan = azure.AppServices.AppServicePlans
                .GetByResourceGroup(S.AppServicePlanRG, S.AppServicePlan);

            var webApp = azure.WebApps
                .Define($"cm-web-t-{id}")
                .WithExistingWindowsPlan(plan)
                .WithExistingResourceGroup(S.AppServicePlanRG)
                .WithClientAffinityEnabled(false)
                .WithHttpsOnly(true)
                .WithDefaultDocuments(Enumerable.Empty<string>().ToList())
                .WithoutPhp()
                .WithPlatformArchitecture(Microsoft.Azure.Management.AppService.Fluent.PlatformArchitecture.X64)
                .WithWebAppAlwaysOn(true)
                .WithAppSettings(new Dictionary<string, string>()
                {
                    {S.TenantKey,id },
                    {S.DbConnectionKey,string.Format(S.DbConnectionValue,id,S.SqlUser,S.SqlPassword) }
                })
                .Create();

            var host = webApp.HostNames.First();

            var dns = azure.DnsZones
                .GetByResourceGroup(S.CustomDomainRG, S.CustomDomain)
                .Update()
                .DefineCNameRecordSet(id)
                .WithAlias(host)
                .WithTimeToLive(S.DNSTtl)
                .Attach().Apply();

            webApp.Update()
                .DefineHostnameBinding()
                .WithThirdPartyDomain(S.CustomDomain)
                .WithSubDomain(id)
                .WithDnsRecordType(Microsoft.Azure.Management.AppService.Fluent.Models.CustomHostNameDnsRecordType.CName)
                .Attach().Apply();


            var certificate = AcmeUtils.GenerateCertificate(id, S.CustomDomain, dns).GetAwaiter().GetResult();
            var domain = $"{id}.{S.CustomDomain}";
            if (certificate.HasValue)
            {
                webApp.Update()
                .DefineSslBinding()
                .ForHostname(domain)
                .WithPfxCertificateToUpload(certificate.Value.Item1,certificate.Value.Item2)
                .WithSniBasedSsl()
                .Attach().Apply();
            }
            
            var deploy = webApp.Deploy()
                .WithPackageUri(S.WebAppImage)
                .WithExistingDeploymentsDeleted(true)
                .Execute();

            if (deploy.Complete)
            {
                Console.WriteLine($"Deployed {rootobject.RequestID}-{rootobject.TenantName} with ID: {id}");
                var client = new EventGridClient(new TopicCredentials(S.EventGridTopicKey));
                await client.PublishEventsAsync(new Uri(S.EventGridTopicEndpoint).Host,
                    new List<EventGridEvent>{
                        new EventGridEvent()
                        {
                            Id=rootobject.RequestID,
                            Subject=id,
                            DataVersion="1.0",
                            EventTime=DateTime.UtcNow,
                            EventType="CMakers.Tenant.Created",
                            Data=new DataModel
                            {
                                URL=$"http://{id}.{S.CustomDomain}"
                            }
                        }
                    });
            }


        }
    }
}