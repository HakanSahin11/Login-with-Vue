using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using API_Test.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Core;
using MongoDB.Bson;
using System.Net.Http;
using System.Net;
using System.IO;
using API_Test.HelperClasses;

namespace API_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private static readonly HttpClient client = new HttpClient();
        public List<DataClass> customer = new List<DataClass>();
        public List<Login> LoginCustomer = new List<Login>();

        public string result;
        public string testGet;
        public int currentCustomer { get; set; }
        public IMongoCollection<DataClass> collection;
        public static IMongoDatabase db;
        public static IMongoCollection<BsonDocument> bsonCollection;
        public MainController()
        {
            var connectionString = "mongodb://userAdmin:silvereye@localhost:27017";
            IMongoClient client = new MongoClient(connectionString);
            db = client.GetDatabase("bankAppData");
            collection = db.GetCollection<DataClass>(DataClass.Name);
            
        }
        public IMongoQueryable<DataClass> MongoQueryableConverter(IMongoCollection<DataClass> input)
        {
            var query = from c in input.AsQueryable<DataClass>()
                        select c;
            return query;

        }
        
        public void collectionSetup()
        {
            foreach (var item in MongoQueryableConverter(collection))
            {
                var login = new Login(null, item.cpr, item.password, item.customer_number, item.loginBan, item.loginStatusBanTimer);
                LoginCustomer.Add(login);
            }
        }

        // GET: api/Main
        [HttpGet]
        public ActionResult Get()
        {
            collectionSetup();
            return Ok(LoginCustomer);
        }

        // GET: api/Main/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Main
        [HttpPost]
        public ActionResult Post([FromBody] DataClass value)
        {
            bool match = false;
            collectionSetup();
            foreach (var item in LoginCustomer)
            {
                if (value.cpr == item.cpr) 
                {
                    if(Convert.ToDateTime(item.loginStatusBanTimer) < DateTime.Now)
                    {
                        if (Hashing.HashSalt(value.password, item.password) == true)
                         {
                            currentCustomer = item.customer_number;
                            match = true;
                         }
                    }
                    else
                    {
                        return Ok(item.loginStatusBanTimer);
                    }
                }
            }

            if (value.loginBan == true)
            {
                string banTimer = $"{ DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year} {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}";
                bsonCollection = db.GetCollection<BsonDocument>("bankAppData");
                DateTime NewBanTimer = Convert.ToDateTime(banTimer).AddMinutes(2);
                bsonSec.bsonSection(value.customer_number, $"{NewBanTimer}", "loginStatusBanTimer", bsonCollection);

                return Ok(NewBanTimer);
            }
                if (match == true)
                {
                     return Ok("Success");
                }

                else
                {
                     return Ok("Failed");
                }
        }

        // PUT: api/Main/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
