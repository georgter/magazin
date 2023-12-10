using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace magazin.Data
{
    public class AuthOptions
    {
        public const string ISSUER = "IssuerMagazin"; // издатель токена
        public const string AUDIENCE = "AudienceMagazin"; // потребитель токена
        const string KEY = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";   // ключ для шифрации
        public const int LIFETIME = 50; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
        }
    }
}
