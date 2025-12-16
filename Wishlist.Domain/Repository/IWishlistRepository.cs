
namespace Wishlist.Domain.Entities
{
    public interface IWishlistRepository
    {
        Wishlist GetWishlistByUserId(int userId);
        void Update(Wishlist wishlist);
        void Delete(int wishlistId);
    }
}
