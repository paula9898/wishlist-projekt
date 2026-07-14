using Wishlist.Domain.Exceptions;

namespace Wishlist.Domain.Entities
{
    public abstract class WishlistBase
    {
        public Guid WishlistId { private get; init; }
        public User User { get; init; }
        public DateTime CreatedDate { get; } = DateTime.Now;
        List<WishlistItem> _wishlistItems { get; }
        public IReadOnlyCollection<WishlistItem> WishlistItems => _wishlistItems;

        protected abstract int MaxItems { get; }


        public WishlistBase(User user) 
        {
            this.User = user;
            _wishlistItems = new List<WishlistItem>();
        }

        public void AddItem(WishlistItem item)
        {
            if(_wishlistItems.Any(i => i.IsSameProductId(item)))
            {
                throw new WishlistItemAlreadyExistsException();
            }

            if(_wishlistItems.Count >= MaxItems)
            {
               throw new WishlistMaxItemsReachedException(MaxItems);
            }

            _wishlistItems.Add(item);
        }

        public void RemoveItem(int itemId)
        {
            var wishListItem = _wishlistItems.FirstOrDefault(i => i.Id == itemId);

            _wishlistItems.Remove(wishListItem);
        }

    }
}
