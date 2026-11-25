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
            
            if (productId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(productId),"Product ID must be greater than zero");
            }
            this.ProductId = productId;

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"{name} cannot be null or empty");
            }

            this.Name = name;
        }

        public bool IsSameProductId(WishlistItem wishlistItem) {

            return wishlistItem.ProductId == ProductId;
           
        }

    }
}
