using System.ComponentModel.DataAnnotations;

namespace magazin.Model
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }      // Идентификатор детали заказа
        public int OrderId { get; set; }            // Идентификатор заказа
        public int ProductId { get; set; }          // Идентификатор товара
        public int Quantity { get; set; }           // Количество товаров в заказе
        public decimal TotalAmount { get; set; }    // Общая сумма для каждого товара в заказе

        // Внешние ключи для связи с заказом и товаром
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
