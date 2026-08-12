using Microsoft.AspNetCore.Mvc;
using WishlistApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WishlistApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistItemController : ControllerBase
    {
        private static List<WishlistItem> items = new List<WishlistItem>
        {
            new WishlistItem
            {
                Id = 1,
                ProductId = 1,
                Name = "Introduction to Algorithms 2e",
                //DateAdded = DateTime.Now,

            },
            new WishlistItem
            {
                Id = 2,
                ProductId = 4,
                Name = "Laptop Bag",
                //DateAdded = new DateTime(2025,12,10)
            }
        };

        // GET: api/<WishlistItemController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<WishlistItemController>/5
        [HttpGet("{id}")]
        public ActionResult<WishlistItem> Get(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            return Ok(item);
        }

        // POST api/<WishlistItemController>
        [HttpPost]
        public async Task<ActionResult<WishlistItem>>CreateWishlistItem([FromBody] WishlistItem wishlistItem)
        {
            try
            {
                if (items.Any(i => i.Id == wishlistItem.Id))
                {
                    return BadRequest("This item was already wishlist");
                }

                

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            items.Add(wishlistItem);

            return CreatedAtAction(nameof(Get), new { id = wishlistItem.Id }, wishlistItem);


        }

        // PUT api/<WishlistItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WishlistItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
