using Wishlist.Domain.Entities;

namespace Wishlist.Domain.Repository
{
    public interface IWishlistRepository
    {
        WishlistBase? GetWishlistByUserId(int userId);
        void Update(WishlistBase wishlist);
        bool Delete(int userId);
    }
}
