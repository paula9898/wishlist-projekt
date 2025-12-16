namespace Wishlist.Domain.Entities
{
    public class User
    {
        public enum UserTypes
        {
            Member,
            Guest
        }
        public int Id { get; set; }

    }

}
