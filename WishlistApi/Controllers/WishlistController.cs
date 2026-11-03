using Application_Layer.WishlistServices;
using Microsoft.AspNetCore.Mvc;
using Wishlist.Domain.Entities;
using Wishlist.Domain.Repository;
using WishlistApi.DTOs;

namespace WishlistApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistRepository _wishlistRepository;
        private readonly AddItemToWishlistHandler addItemToWishlistHandler;

        public WishlistController(IWishlistRepository wishlistRepository, AddItemToWishlistHandler addItemToWishlistHandler)
        {
            this._wishlistRepository = wishlistRepository;
            this.addItemToWishlistHandler = addItemToWishlistHandler;
        }

        [HttpGet("{id}")]
        public ActionResult<WishlistBase> GetWishlistByUser(int id) 
        {
            var wishlist = _wishlistRepository.GetWishlistByUserId(id);

            if(wishlist == null) 
            {
                return NotFound();
            }

            return Ok(wishlist);
        }

        [HttpPost("{userId}")]
        public ActionResult<WishlistBase> AddNewItem(int userId, [FromBody] AddWishlistItemRequest addWishlistItemRequest)
        {
            var user = new User(userId, UserType.Guest);
            WishlistItem wishlistItem = new WishlistItem(addWishlistItemRequest.ProductId, addWishlistItemRequest.Name);
          
            addItemToWishlistHandler.AddItemToWishlist(user,wishlistItem );

            return Ok();

        }
    }
}
