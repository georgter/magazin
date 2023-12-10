
using magazin;
using magazin.Data;
using magazin.Model;
using magazin.ModelDto.User;
using Microsoft.EntityFrameworkCore;

namespace magazin.Repositories
{
    public class AuthorizationRepository : IAuthorizationRepository
    {
        private readonly  ApplicationDbContext _context;
        public AuthorizationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        

        public async Task<UserClaimsDTO> AuthenticateUser(string username, string passwordHash)
        {
            var us = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username && x.PasswordHash == passwordHash);
            UserClaimsDTO claims = new UserClaimsDTO();
            if (us != null)
            {
                claims = new UserClaimsDTO()
                {
                    UserName = us.UserName,
                    Role = us.Role,
                };
            }

            claims.Message = "Invalid username or password.";
            return claims;
        }

        public async Task<UserClaimsDTO> RegisterUser(User user)
        {
            UserClaimsDTO claims = new UserClaimsDTO();
            if (await _context.Users.AnyAsync(u => u.UserName == user.UserName))
            {
                claims.Message = "User already exists";
                return claims; 
            }
            _context.Users.Add(user);
            _context.SaveChanges();

            claims = new UserClaimsDTO()
            {
                UserName = user.UserName,
                Role = "1",
            };

            return claims;
        }
    }
}
