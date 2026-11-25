using Wishlist.Domain.Entities;
using Wishlist.Domain.Repository;
using MongoDB.Driver;

namespace Wishlist.Infrastructure.Repositories
{
    public class WishlistMongoRepository : IWishlistRepository
    {
        
        private readonly IMongoCollection<WishlistBase> _wishlistsCollection;

        public WishlistMongoRepository(IMongoCollection<WishlistBase> wishlistsCollection)
        {
            _wishlistsCollection = wishlistsCollection;
        }

        public bool Delete(int userId)
        {
            throw new NotImplementedException();
        }

        public WishlistBase? GetWishlistByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public void Update(WishlistBase wishlist)
        {
            throw new NotImplementedException();
        }
    }
}
