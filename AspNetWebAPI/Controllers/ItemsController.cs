using AspNetWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspNetWebAPI.Controllers
{
    public class ItemsController : ApiController
    {
        Item[] items = new Item[]
        {
            new Item { Id = 1, Title = "Compass Jeep", Category = "Buy"},
            new Item { Id = 2, Title = "MBA", Category = "Education"},
            new Item { Id = 3, Title = "WeightGain", Category = "Health"}
        };

        public IEnumerable<Item> GetAllItems()
        {
            return items;
        }

        public IHttpActionResult GetItem(int id)
        {
            var product = items.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
