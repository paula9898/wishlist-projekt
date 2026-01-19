using System;
using Wishlist.Domain.Entities;
using Wishlist.Domain.Repository;

public class WishlistInMemoryRepository : IWishlistRepository
{
    private readonly Dictionary<int, WishlistBase> _wishlistStorage = new Dictionary<int, WishlistBase>();
	public WishlistInMemoryRepository()
	{
	}

    public void Delete(int wishlistId)
    {
        throw new NotImplementedException();
    }

    public WishlistBase GetWishlistForUser(User user)
    {
        
        if(_wishlistStorage.TryGetValue(user.Id, out var wishlist))
        {
            return wishlist;
        }

        throw new Exception("List not found");
    }

    public void Update(WishlistBase wishlist)
    {
        throw new NotImplementedException();
    }
}
