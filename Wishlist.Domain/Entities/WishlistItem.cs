using System.ComponentModel.DataAnnotations;

namespace Wishlist.Domain.Entities
{
    public record WishlistItem
    {
        public int Id { get; init; }
        public int ProductId { get; init; }
        public required string Name { get; init; }
        public DateTime DateAdded { get; init; }

        public WishlistItem(int productId, string name, DateTime dateAdded)
        {
            this.ProductId = productId;
            this.Name = name;
            this.DateAdded = dateAdded;
        }

        public bool IsSameProductId(WishlistItem wishlistItem) {

            return wishlistItem.ProductId == ProductId;
           
        }

    }
}
