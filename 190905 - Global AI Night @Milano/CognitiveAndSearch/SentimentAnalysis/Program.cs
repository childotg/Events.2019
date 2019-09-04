using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using Microsoft.Rest;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace SentimentAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            var endpoint = $"https://westeurope.api.cognitive.microsoft.com";
            var cl = new TextAnalyticsClient(new ApiKeyServiceClientCredentials(""))
            {
                Endpoint=endpoint
            };
            var modelPath = Path.Combine(AppContext.BaseDirectory,@"..\..\..\..\","Dataset.json");
            var models = JsonConvert.DeserializeObject<Reviews[]>(File.ReadAllText(modelPath))
                .Select(p => new MultiLanguageInput(p.ID, p.Body, p.Language.ToLower())).ToList();

            var result = cl.SentimentBatch(new Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models.MultiLanguageBatchInput()
            {
                Documents = models
            });
        }
    }
}
