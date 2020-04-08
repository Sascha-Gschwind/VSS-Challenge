using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using ShoppingListApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public ShoppingListController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // GET api/shoppinglist
        [HttpGet]
        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            var items = new List<Item>();
            await using (var connection = new NpgsqlConnection(configuration["ConnectionString"]))
            {
                await connection.OpenAsync();
                await using (var cmd = new NpgsqlCommand("SELECT * FROM items", connection))
                {
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            items.Add(new Item { Id = reader.GetInt32(0), Description = reader.GetString(1) });
                        }
                    }
                }
                await connection.CloseAsync();
            }
            return items;
        }

        // GET api/shoppinglist/id
        [HttpGet("{id}")]
        public async Task<Item> GetItemAsync(int id)
        {
            Item item = null;
            await using (var connection = new NpgsqlConnection(configuration["ConnectionString"]))
            {
                await connection.OpenAsync();
                await using (var cmd = new NpgsqlCommand("SELECT * FROM items WHERE id = (@p)", connection))
                {
                    cmd.Parameters.AddWithValue("p", id);
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        await reader.ReadAsync();
                        if (reader.HasRows)
                        {
                            item = new Item { Id = reader.GetInt32(0), Description = reader.GetString(1) };
                        }
                    }
                }
                await connection.CloseAsync();
            }
            return item;
        }

        // POST api/shoppinglist
        [HttpPost]
        public async Task<IActionResult> AddItemAsync([FromBody]string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return BadRequest();
            }
            await using (var connection = new NpgsqlConnection(configuration["ConnectionString"]))
            {
                await connection.OpenAsync();
                await using (var cmd = new NpgsqlCommand("INSERT INTO items VALUES(DEFAULT, (@p))", connection))
                {
                    cmd.Parameters.AddWithValue("p", value);
                    await cmd.ExecuteNonQueryAsync();
                }
                await connection.CloseAsync();
            }
            return Ok();
        }

        // PUT api/shoppinglist
        [HttpPut]
        public async Task<IActionResult> UpdateItemAsync(Item item)
        {
            if (item == null || item.Id == 0 || item.Description == null)
            {
                return BadRequest();
            }
            await using (var connection = new NpgsqlConnection(configuration["ConnectionString"]))
            {
                await connection.OpenAsync();
                await using (var cmd = new NpgsqlCommand("UPDATE items SET description = (@p) WHERE id = (@i)", connection))
                {
                    cmd.Parameters.AddWithValue("i", item.Id);
                    cmd.Parameters.AddWithValue("p", item.Description);
                    await cmd.ExecuteNonQueryAsync();
                }
                await connection.CloseAsync();
            }
            return Ok();
        }

        // DELETE api/shoppinglist/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await using (var connection = new NpgsqlConnection(configuration["ConnectionString"]))
            {
                await connection.OpenAsync();
                await using (var cmd = new NpgsqlCommand("DELETE FROM items WHERE id = (@i)", connection))
                {
                    cmd.Parameters.AddWithValue("i", id);
                    await cmd.ExecuteNonQueryAsync();
                }
                await connection.CloseAsync();
            }
            return Ok();
        }
    }
}