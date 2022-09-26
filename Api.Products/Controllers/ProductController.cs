using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Products.Controllers
{
    [Route("product")]
    [Authorize]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = new List<object>
            {
                new {id = 1, name = "Laptop Gaming Gen4", category = "Laptop", price = "50.00"},
                new {id = 2, name = "Iphone12", category = "Phone", price = "12.00"},
                new {id = 3, name = "TVPanasonic", category = "TV", price = "8.50"}
            };
            return Ok(products);
        }
    }
}
