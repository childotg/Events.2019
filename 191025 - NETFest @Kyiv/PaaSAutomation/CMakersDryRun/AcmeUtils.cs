using Certes;
using Certes.Acme;
using Certes.Acme.Resource;
using Microsoft.Azure.Management.Dns.Fluent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMakersDryRun
{
    public static class AcmeUtils
    {
        public static async Task<(string,string)?> GenerateCertificate(string subDomain,string rootDomain,IDnsZone dns)
        {
            var client = new AcmeContext(WellKnownServers.LetsEncryptV2);
            var account = await client.NewAccount("demo@cloudmakers.xyz",true);
            var domain = $"{subDomain}.{rootDomain}";
            var order = await client.NewOrder(new[] { domain });
            var auth = (await order.Authorizations()).First();
            var dnsChallenge = await auth.Dns();
            var dnsTxt = client.AccountKey.DnsTxt(dnsChallenge.Token);
            var acmeAlias = $"_acme-challenge.{subDomain}";

            dns.Update()
                .DefineTxtRecordSet(acmeAlias)
                .WithText(dnsTxt)
                .WithTimeToLive(1).Attach().Apply();

            var result = await dnsChallenge.Validate();
            var retries = 10;
            while ((!result.Status.HasValue || result.Status.Value != ChallengeStatus.Valid) && retries-- > 0)
            {
                await Task.Delay(5000);
                result = await dnsChallenge.Validate();
            }
            if (result.Status.Value == ChallengeStatus.Valid)
            {
                var key = KeyFactory.NewKey(KeyAlgorithm.ES256);
                var cert = await order.Generate(new CsrInfo()
                {
                    CommonName = domain,
                    State = "MI",
                    CountryName = "IT",
                    Locality = "Milano",
                    Organization = "CloudMakers XYZ",
                    OrganizationUnit = "DEV"
                }, key);

                var pfx = Path.GetTempFileName();
                File.WriteAllBytes(pfx, cert.ToPfx(key).Build(domain, S.PfxPassword));
                return (pfx, S.PfxPassword);
            }
            else return null;
        }
    }
}
