using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace HybridAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActorsController : ControllerBase
    {
        

        private readonly ILogger<ActorsController> _logger;

        public ActorsController(ILogger<ActorsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ActorModel> Get()
        {
            var connStr = "Server=LAPTOP; Database=sakila; Uid=root; Pwd=root;";
            using (var conn=new MySqlConnection(connStr))
            {   
                conn.Open();
                var command = new MySqlCommand("SELECT * FROM sakila.actor", conn);
                //command.CommandType = System.Data.CommandType.Text;
                //command.CommandText = "SELECT * FROM sakila.actor";
                var result = command.ExecuteReader();
                var list = new List<ActorModel>();
                while (result.Read())
                {
                    list.Add(new ActorModel()
                    {
                        Firstname = result.GetString(1),
                        Lastname = result.GetString(2)
                    });                    
                }
                return list;
            }
        }
    }

    public class ActorModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
