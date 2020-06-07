using Core.Entities;

namespace Entities.Dtos.Auth
{
    public class SignInDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}