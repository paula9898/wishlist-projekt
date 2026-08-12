using Wishlist.Domain.Entities;
using Wishlist.Domain.Repository;

public class WishlistInMemoryRepository : IWishlistRepository
{
    private readonly Dictionary<int, WishlistBase> _wishlistStorage = new Dictionary<int, WishlistBase>();

    public bool Delete(int userId)
    {
        
       bool removed = _wishlistStorage.Remove(userId);

        return removed;
    }

    public WishlistBase? GetWishlistByUserId(int userId)
    {
        
        if(_wishlistStorage.TryGetValue(userId, out var wishlist))
        {
            return wishlist;
        }

        return null;
    }

    public void Update(WishlistBase wishlist)
    {
        var key = wishlist.User.Id;
        
        _wishlistStorage[key] = wishlist;
    }
}
