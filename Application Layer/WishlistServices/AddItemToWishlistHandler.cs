using Wishlist.Domain.Entities;
using Wishlist.Domain.Repository;

namespace Application_Layer.WishlistServices
{
    public class AddItemToWishlistHandler
    {
        private readonly IWishlistRepository _repo;

        public void AddItemToWishlist(User user, WishlistItem item)
        {
            
            var wishlist= _repo.GetWishlistForUser(user);

        }
    }
}
