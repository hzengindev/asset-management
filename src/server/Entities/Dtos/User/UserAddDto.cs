using Core.Entities;

namespace Entities.Dtos.User
{
    public class UserAddDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}