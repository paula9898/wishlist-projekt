using System;
using System.Collections.Generic;
using System.Text;

namespace Wishlist.Domain.Entities
{
    public class GuestWishlist : WishlistBase
    {
        public GuestWishlist(User User, string Name, string Description, DateTime createdDate, User.UserType userType) : base(User, Name, Description, createdDate)
        {
        }
        protected override int MaxItems => 5;
    }
}
