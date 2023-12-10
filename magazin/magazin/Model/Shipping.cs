using System.ComponentModel.DataAnnotations;

namespace magazin.Model
{
    public class Shipping
    {
        [Key]
        public int Id { get; set; }           // Идентификатор доставки
        public int OrderId { get; set; }              // Идентификатор заказа
        public string Status { get; set; }            // Статус доставки
        public DateTime DeliveryDate { get; set; }    // Дата и время доставки

        // Внешний ключ для связи с заказом
        public Order Order { get; set; }
    }
}
