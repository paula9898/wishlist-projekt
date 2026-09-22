namespace Wishlist.Domain.Exceptions
{
    public sealed class WishlistItemNotFoundException : DomainExceptions
    {
        public WishlistItemNotFoundException() : base("The item was not found")
        {
        }
    }
}
