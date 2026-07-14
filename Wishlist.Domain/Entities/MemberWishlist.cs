using System;
using System.Collections.Generic;
using System.Text;

namespace Wishlist.Domain.Entities
{
    public class MemberWishlist : WishlistBase
    {
        public MemberWishlist(User user) : base(user)
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
