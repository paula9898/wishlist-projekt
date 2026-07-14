namespace Wishlist.Domain.Exceptions
{
    public abstract class DomainExceptions : Exception
    {
        protected DomainExceptions(string message) : base(message) { }
    }
}
