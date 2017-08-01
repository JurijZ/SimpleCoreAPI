using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        // GET api/Tomatos
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            using (DB db = new DB())
            {
                return db.Products.ToList();
            }
        }

        // GET api/Tomatos/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            using (DB db = new DB())
            {
                return db.Products.First(t => t.Id == id);
            }
        }

        // POST api/Tomatos
        [HttpPost]
        public void Post([FromBody]JObject value)
        {
            Product posted = value.ToObject<Product>();
            using (DB db = new DB())
            {
                db.Products.Add(posted);
                db.SaveChanges();
            }
        }

        // PUT api/Tomatos/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]JObject value)
        {
            Product posted = value.ToObject<Product>();
            posted.Id = id; // Ensure an id is attached
            using (DB db = new DB())
            {
                db.Products.Update(posted);
                db.SaveChanges();
            }
        }

        // DELETE api/Tomatos/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (DB db = new DB())
            {
                if (db.Products.Where(t => t.Id == id).Count() > 0) // Check if element exists
                    db.Products.Remove(db.Products.First(t => t.Id == id));
                db.SaveChanges();
            }
        }
    }
}
