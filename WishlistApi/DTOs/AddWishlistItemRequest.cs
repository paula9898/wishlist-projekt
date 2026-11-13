using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WishlistApi.DTOs
{
    public class AddWishlistItemRequest
    {
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
