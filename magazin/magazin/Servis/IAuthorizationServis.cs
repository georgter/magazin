using magazin.Model;
using magazin.ModelDto.User;

namespace magazin.Servis
{
    public interface IAuthorizationServis
    {
        public Task<UserClaimsDTO> AuthenticateUser(string username, string password);
        public Task<UserClaimsDTO> RegisterUser(RegistrationUserDTO user);
    }
}
