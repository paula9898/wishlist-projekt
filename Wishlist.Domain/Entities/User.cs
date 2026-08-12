using FluentValidation;

namespace Wishlist.Domain.Entities
{
    public class User
    {
        public int Id { get; }
        public UserType UserType { get; }
        public User(int id, UserType userType)
        {
            
            if (!Enum.IsDefined(typeof(UserType), userType))
                throw new ArgumentException("Invalid user type.", nameof(userType));

            if(id < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be positive.");
                
            }

            this.Id = id;
        }


    }
}
