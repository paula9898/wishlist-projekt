using Wishlist.Domain.Entities;
using Wishlist.Domain.Repository;

namespace Application_Layer.WishlistServices
{
    public class AddItemToWishlistHandler
    {
        private readonly IWishlistRepository _repo;

        public AddItemToWishlistHandler(IWishlistRepository repo)
        {
            _repo = repo;
        }

        public void AddItemToWishlist(User user, WishlistItem item)
        {

            var wishlist = _repo.GetWishlistByUserId(user.Id);

            if (wishlist == null)
            {
                UserType type = user.UserType;

                if (type == UserType.Guest)
                {
                    wishlist = new GuestWishlist(user);
                }
                else
                {
                    wishlist = new MemberWishlist(user);
                }

            }

            wishlist.AddItem(item);

            _repo.Update(wishlist);
        }
    }
}
