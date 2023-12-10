using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace magazin.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int UsertId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }

        // Внешний ключ для связи с пользователем
        public User User { get; set; }

        // Навигационные свойства
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Payment Payment { get; set; }
        public Shipping Shipping { get; set; }
    }
}
