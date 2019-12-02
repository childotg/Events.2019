using HtmlAgilityPack;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;

namespace ScrapeTheAgenda
{
    internal class ScrapeTask
    {
        public ScrapeTask()
        {
        }

        internal void Run()
        {
            var blToken = "[removed]";
            var blUri = "https://chrome.browserless.io/webdriver";
			var storageCS = "[removed]";

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-background-timer-throttling");
            options.AddArgument("--disable-backgrounding-occluded-windows");
            options.AddArgument("--disable-breakpad");
            options.AddArgument("--disable-component-extensions-with-background-pages");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-features=TranslateUI,BlinkGenPropertyTrees");
            options.AddArgument("--disable-ipc-flooding-protection");
            options.AddArgument("--disable-renderer-backgrounding");
            options.AddArgument("--enable-features=NetworkService,NetworkServiceInProcess");
            options.AddArgument("--force-color-profile=srgb");
            options.AddArgument("--hide-scrollbars");
            options.AddArgument("--metrics-recording-only");
            options.AddArgument("--mute-audio");
            options.AddArgument("--headless");
            options.AddArgument("--no-sandbox");
            options.AddAdditionalCapability("browserless.token", blToken, true);
            
            //Plain local driver
            //IWebDriver driver = new ChromeDriver();
            //Remote driver
            IWebDriver driver = new RemoteWebDriver(
              new Uri(blUri), options.ToCapabilities()
            );

            var uri = "https://www.wpc2019.it/cms/it-IT/Agenda";
            driver.Navigate().GoToUrl(uri);
            Thread.Sleep(5000);

            var content = driver.PageSource;
            var doc = new HtmlDocument();
            doc.LoadHtml(content);

            var sessions=doc.DocumentNode.SelectNodes("//div[@data-sessionid]").Select(p => new
            {
                ID = p.Attributes["data-sessionid"].Value,
                Title = p.SelectSingleNode(".//h3/a/text()").InnerText
            }).ToArray();

            var saveThat = JsonConvert.SerializeObject(sessions,Formatting.Indented);

            var blob = CloudStorageAccount.Parse(storageCS)
                .CreateCloudBlobClient()
                .GetContainerReference("data")
                .GetBlockBlobReference("wpcSessions.json");
            blob.UploadText(saveThat);

            driver.Quit();

            Console.WriteLine(blob.Uri.ToString());

        }
    }
}