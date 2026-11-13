using Wishlist.Domain.Entities;

namespace Wishlist.Domain.Tests.Entities
{
    public class WishlistItemTests
    {
        [Fact]
        public void CreateWishlistItemTest()
        {
            int productId = 12;
            string name = "Calculus book";
            WishlistItem wishlistItem = new WishlistItem(productId,name);

            Assert.Equal(productId, wishlistItem.ProductId);
            Assert.Equal(name, wishlistItem.Name);

        }

        [Fact]
        public void DateTimeValueTest()
        {
            int productId = 12;
            string name = "Calculus book";

            WishlistItem wishlist = new WishlistItem(productId,name);
            DateTime dateTime = wishlist.DateAdded;

            Assert.NotEqual(DateTime.MinValue, dateTime);

        }
    }
}
