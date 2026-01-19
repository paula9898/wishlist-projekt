namespace Wishlist.Domain.Exceptions
{
    public sealed class WishlistItemAlreadyExistsException : DomainExceptions
    {
        public WishlistItemAlreadyExistsException() : base("The item is already in the wishlsit")
        {
        }
    }
}
