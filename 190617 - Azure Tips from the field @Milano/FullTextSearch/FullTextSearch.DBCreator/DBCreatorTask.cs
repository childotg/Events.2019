using System.Linq;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using FullTextSearch.Models;
using System.Globalization;

namespace FullTextSearch.DBCreator
{
    internal class DBCreatorTask
    {
        private readonly ILogger _logger = null;
        private readonly string _filePath = "googleplaystore_cleaned.csv";
        private readonly string _connectionString = null;
        private readonly string _type = null;
        public DBCreatorTask(ILoggerFactory loggerFactory,string connectionString,string type)
        {
            this._connectionString = connectionString;
            this._type = type;
            this._logger = loggerFactory.CreateLogger<DBCreatorTask>();
        }

        internal async Task RunAsync()
        {
            _logger.LogInformation("Using Google Play Store dataset found on https://www.kaggle.com/lava18/google-play-store-apps");
            var path = Path.Combine(
                new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName, "Content", _filePath);
            _logger.LogInformation($"Parsing cleaned file {_filePath}");
            var parsed = File.ReadAllLines(path).Skip(1)
                .Select(p => p.Split(';'))
                .Select((p, i) => new AppItem
                {
                    //AppId = i + 1000,
                    AppName = p[0],
                    AppCategory = p[1],
                    AppRating = p[2].Any(c=>!char.IsDigit(c))?new Nullable<double>():double.Parse(p[2]),                    
                    AppReviews = string.IsNullOrWhiteSpace(p[3])?new Nullable<int>():int.Parse(p[3]),
                    AppSizeInKb = p[4] == "Varies with device" ? new Nullable<double>(): 
                        (p[4].Contains('k')?double.Parse(p[4].Replace("k","")):double.Parse(p[4].Replace("M", "")) * 1024),
                    AppInstalls = p[5],
                    AppType = (AppType)Enum.Parse(typeof(AppType),p[6]),
                    AppPrice = string.IsNullOrWhiteSpace(p[7])?new Nullable<double>():double.Parse(p[7]),                    
                    AppContentRating = p[8],
                    AppGenres = p[9],
                    AppLastUpdate = DateTime.ParseExact(p[10],"dd/MM/yyyy",CultureInfo.InvariantCulture),
                    AppVersion = p[11],
                    AppAndroidRequirement = p[12]
                })
                .Where(p=>p.AppType!=AppType.NaN)
                .ToArray();

            _logger.LogInformation("Getting statistics...");
            var contentRating = parsed.Select(p => p.AppContentRating).Distinct().ToArray();
            var categories = parsed.Select(p => p.AppCategory).Distinct().ToArray();
            var installs= parsed.Select(p => p.AppInstalls).Distinct().ToArray();
            var types= parsed.Select(p => p.AppType).Distinct().ToArray();

            var groupByType = parsed.GroupBy(p => p.AppType)
                .ToDictionary(p => p.Key.ToString(), p => p.ToArray());

            using (var ctx = new AppsContext(_connectionString))
            {
                _logger.LogInformation($"Saving {groupByType[_type].Count()} records of type {_type} on DB");
                ctx.Applications.AddRange(groupByType[_type]);
                await ctx.SaveChangesAsync();
            }

        }
    }
}