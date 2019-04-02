using System;
using System.Collections.Generic;
using System.Text;

namespace CodeCamp2019.Models.Search
{
    public class SearchItem
    {
        public string AppId { get; set; }
        public string AppName { get; set; }
        public string AppCategory { get; set; }
        public double? AppRating { get; set; }
        public int? AppReviews { get; set; }
        public double? AppSizeInKb { get; set; }
        public string AppSize { get; set; }
        public string AppInstalls { get; set; }
        public AppType AppType { get; set; }
        public double? AppPrice { get; set; }
        public string AppContentRating { get; set; }
        public string[] AppGenres { get; set; }
        public DateTime AppLastUpdate { get; set; }
        public string AppVersion { get; set; }
        public string AppAndroidRequirement { get; set; }
    }
}
