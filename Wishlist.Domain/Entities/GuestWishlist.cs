using System;
using System.Collections.Generic;
using System.Text;

namespace Wishlist.Domain.Entities
{
    public class GuestWishlist : WishlistBase
    {
        public GuestWishlist(User User) : base(User)
        {
        }
        protected override int MaxItems => 5;
    }
}
