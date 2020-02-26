using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingListApi.Models;
using System.Collections.Generic;

namespace ShoppingListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        // GET api/shoppinglist
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new List<string>
            {
                "Tomaten",
                "Brot"
            };
        }

        // GET api/shoppinglist/id
        [HttpGet("{id}")]
        public string GetItem(int id)
        {
            return "Brot";
        }

        // POST api/shoppinglist
        [HttpPost]
        public IActionResult AddItem([FromBody]string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return Ok();
            } else
            {
                return BadRequest();
            }
        }

        // PUT api/shoppinglist
        [HttpPut]
        public IActionResult UpdateItem(Item item)
        {
            if (item != null && item.Id != 0 && item.Value != null)
            {
                return Ok();
            } else
            {
                return BadRequest();
            }
        }

        // DELETE api/shoppinglist/id
        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            if (id != 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}