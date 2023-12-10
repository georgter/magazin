using System.ComponentModel.DataAnnotations;

namespace magazin.Model
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }               // Идентификатор корзины
        public int UserId { get; set; }               // Идентификатор пользователя

        // Навигационные свойства
        public User User { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
