using System;
using System.Collections.Generic;
using System.Text;

namespace SentimentAnalysis
{
    public partial class Reviews
    {
        public string ID { get; set; }
        public string ProductID { get; set; }
        public string ProductBrand { get; set; }
        public int ProductReviews { get; set; }
        public string Language { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Body { get; set; }
        public byte Rating { get; set; }
    }
}
