using System.Reflection.Metadata;
using static Wishlist.Domain.Entities.User;

namespace Wishlist.Domain.Entities
{
    public class Wishlist
    {
        public int WishlistId { private get; init; }
        public int UserId { private get; init; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        List<WishlistItem> _wishlistItems { get; }
        public IReadOnlyCollection<WishlistItem> WishlistItems => _wishlistItems;

        public const int MAX_SIZE_GUEST = 5;

        public const int MAX_SIZE_MEMBER = 10;

        public UserTypes UserType { get; set; } 


        public Wishlist(int userId, string Name, string Description, DateTime createdDate, UserTypes userType)
        {
            UserId = userId;
            this.Name = Name;
            this.Description = Description;
            this.CreatedDate = createdDate;
            this.UserType = userType;
            _wishlistItems = new List<WishlistItem>();
        }

        private int GetMaxItems()
        {
            if (UserType == UserTypes.Guest)
            {
                return MAX_SIZE_GUEST;

            }

            return MAX_SIZE_MEMBER;
        }

        public void AddItem(WishlistItem item)
        {
            int maxItems = GetMaxItems();
            if(_wishlistItems.Any(i => i.ProductId == item.ProductId))
            {

                throw new InvalidOperationException("This item was already in your wishlist");
            }
            else if(_wishlistItems.Count >= maxItems)
            {
                throw new InvalidOperationException("Can not add new item. Wishlist has reached maximum size");
            }
            else
            {
                _wishlistItems.Add(item);
            }
               
        }

        public void RemoveItem(int itemId)
        {
            var wishListItem = _wishlistItems.FirstOrDefault(i => i.Id == itemId);

            _wishlistItems.Remove(wishListItem);
        }

    }
}
