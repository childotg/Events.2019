using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullTextSearch.Models.Search;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Search;

namespace FullTextSearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<SearchItem> Get()
        {
            var cl = new SearchIndexClient("searchdemos", "applications",
                new SearchCredentials("[removed]"));
            var res = cl.Documents.Search<SearchItem>("free",
                new Microsoft.Azure.Search.Models.SearchParameters()
                {
                    Filter = "AppCategory eq 'GAME' and AppSizeInKb gt 30000"
                }).Results.Select(p => p.Document).ToArray();
            return res;

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
