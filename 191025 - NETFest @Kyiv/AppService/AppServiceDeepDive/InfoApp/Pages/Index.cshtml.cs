using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace InfoApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;


        public Dictionary<string,string> Variables { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Variables = Environment.GetEnvironmentVariables().Keys.OfType<string>()
                .Select(p => new { Key = p, Value = Environment.GetEnvironmentVariable(p) })
                .ToDictionary(p => p.Key, p => p.Value);
        }
    }
}
