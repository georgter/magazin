using magazin.Model;
using magazin.ModelDto.User;

namespace magazin.Repositories
{
    public interface IAuthorizationRepository
    {
        
        public Task<UserClaimsDTO> AuthenticateUser(string username, string passwordHash);
        public Task<UserClaimsDTO> RegisterUser( User user);

    }
}
