using System;
using System.Collections.Generic;
using System.Text;

namespace Wishlist.Domain.Exceptions
{
    public sealed class WishlistMaxItemsReachedException : DomainExceptions
    {
        public WishlistMaxItemsReachedException(int maxItems) : base($"Cannot add new item. Wishlist has reached the maximum size({maxItems}).")
        {

        }

    }
}
