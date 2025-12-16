using Wishlist.Domain.Entities;

namespace Wishlist.Infrastructure
{
    public class WishlistRepository : IWishlistRepository
    {
        public void Delete(int wishlistId)
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.Wishlist GetWishlistByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.Entities.Wishlist wishlist)
        {
            throw new NotImplementedException();
        }
    }
}
