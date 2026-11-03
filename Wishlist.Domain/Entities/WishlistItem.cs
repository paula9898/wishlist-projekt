using System.ComponentModel.DataAnnotations;

namespace Wishlist.Domain.Entities
{
    public record WishlistItem
    {
        public int Id { get; init; }
        public int ProductId { get; init; }
        public string Name { get; init; }
        public DateTime DateAdded { get; init; } = DateTime.UtcNow;

        public WishlistItem(int productId, string name)
        {
            this.ProductId = productId;
            this.Name = name;
        }

        public bool IsSameProductId(WishlistItem wishlistItem) {

            return wishlistItem.ProductId == ProductId;
           
        }

    }
}
