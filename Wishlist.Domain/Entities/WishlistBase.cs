using System.Xml.Linq;
using Wishlist.Domain.Common.Errors;
using Wishlist.Domain.Common.Results;
using Wishlist.Domain.Exceptions;
using static Wishlist.Domain.Entities.User;

namespace Wishlist.Domain.Entities
{
    public abstract class WishlistBase
    {
        public Guid WishlistId { private get; init; }
        public User User { private get; init; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        List<WishlistItem> _wishlistItems { get; }
        public IReadOnlyCollection<WishlistItem> WishlistItems => _wishlistItems;

        protected abstract int MaxItems { get; }


        public WishlistBase(User user, string name, string Description, DateTime createdDate) 
        {
            this.User = user;
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Description = Description;
            this.CreatedDate = createdDate;
            _wishlistItems = new List<WishlistItem>();
        }

        public void AddItem(WishlistItem item)
        {
            if(_wishlistItems.Any(i => i.isTheSameProductId(item.ProductId)))
            {
                throw new WishlistItemAlreadyExistsException();
            }

            if(_wishlistItems.Count > MaxItems)
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
