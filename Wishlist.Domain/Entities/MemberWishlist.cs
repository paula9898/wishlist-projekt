using System;
using System.Collections.Generic;
using System.Text;

namespace Wishlist.Domain.Entities
{
    public class MemberWishlist : WishlistBase
    {
        public MemberWishlist(User user,string Name, string Description, DateTime createdDate, User.UserType userType) : base(user,Name, Description, createdDate)
        {
        }

        protected override int MaxItems => 10;

        public void MergeWishlist(GuestWishlist guesttWishlist)
        {
            foreach(var item in guesttWishlist.WishlistItems)
            {
                this.AddItem(item);
            }
        }
    }
}
