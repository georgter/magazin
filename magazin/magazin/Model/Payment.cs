using System.ComponentModel.DataAnnotations;

namespace magazin.Model
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }            // Идентификатор транзакции
        public int OrderId { get; set; }              // Идентификатор заказа
        public decimal Amount { get; set; }           // Сумма оплаты
        public DateTime TransactionDate { get; set; } // Дата и время проведения транзакции

        // Внешний ключ для связи с заказом
        public Order Order { get; set; }
    }
}
