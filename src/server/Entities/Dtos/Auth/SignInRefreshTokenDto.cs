using Core.Entities;

namespace Entities.Dtos.Auth
{
    public class SignInRefreshTokenDto : IDto
    {
        public string RefreshToken { get; set; }
    }
}