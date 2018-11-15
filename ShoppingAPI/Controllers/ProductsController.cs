using ShoppingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        Product[] products = new Product[]
        {
            new Product {Id = 1, Name = "Mechanical Keyboard", Category = "Electronics", Price = 60},
            new Product {Id = 2, Name = "Aesop's Fables", Category = "Books", Price = 29.99M},
            new Product {Id = 3, Name = "Stand Mixer", Category = "Electronics", Price = 49.99M}
        };

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return products;
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return Ok(product);
        }
    }
}