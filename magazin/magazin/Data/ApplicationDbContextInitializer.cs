using System.Security.Cryptography;
using magazin.Model;
using System.Text;

namespace magazin.Data
{
    public static class ApplicationDbContextInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            var user = new User
            {
                UserName = "admin",
                Email = "admin@admin.ru",
                Address = "отсутствует",
                FirstName = "admin",
                LastName = "admin",
                Password = "123",
                Role = "2",
                PasswordHash = HashPassword("123")
            };
            context.Users.Add(user);
            context.SaveChanges();
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
