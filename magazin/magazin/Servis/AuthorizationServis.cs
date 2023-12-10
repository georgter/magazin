using System.Security.Cryptography;
using magazin.ModelDto.User;
using magazin.Repositories;
using System.Text;
using magazin.Model;

namespace magazin.Servis
{
    public class AuthorizationServis: IAuthorizationServis
    {
        private readonly IAuthorizationRepository _repository;
        public AuthorizationServis(IAuthorizationRepository repository)
        {
            _repository = repository;
        }
        public  async Task<UserClaimsDTO> AuthenticateUser(string username, string password)
        {
            UserClaimsDTO claim = new UserClaimsDTO();

            if (username != null && password != null)
            {
                claim = await _repository.AuthenticateUser(username, HashPassword(password));
            }

            return claim;
        }

        public async Task<UserClaimsDTO> RegisterUser(RegistrationUserDTO user)
        {
            var newUser = new User
            {
                UserName = user.UserName,
                PasswordHash = HashPassword(user.Password),
                Role = "1",
                Password = user.Password,
                Email = user.Email,
                Address = user.Address,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };

            UserClaimsDTO claim = new UserClaimsDTO();

            claim = await _repository.RegisterUser(newUser);

            return claim;
        }

        // Метод для хеширования пароля
        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                // Преобразование пароля в байты
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Преобразование хеша в строку
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        
    }
}
