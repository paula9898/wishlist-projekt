using Wishlist.Domain.Entities;

namespace Wishlist.Domain.Repository
{
    public interface IWishlistRepository
    {
        WishlistBase GetWishlistForUser(User user);
        void Update(WishlistBase wishlist);
        void Delete(int wishlistId);
    }
}
