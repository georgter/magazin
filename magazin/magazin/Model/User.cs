using System.ComponentModel.DataAnnotations;

namespace magazin.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public  string PasswordHash { get; set; }
        public string FirstName { get; set; }         // Имя
        public string LastName { get; set; }          // Фамилия
        public string Address { get; set; }           // Адрес

        // Навигационные свойства
        public ICollection<Order> Orders { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public Cart Cart { get; set; }
    }
}
