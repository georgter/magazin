using System.ComponentModel.DataAnnotations;

namespace magazin.Model
{
    /// <summary>
    /// Отзывы
    /// </summary>
    public class Review
    {
        [Key]
        public int Id { get; set; }               // Идентификатор корзины
        public int UserId { get; set; }               // Идентификатор пользователя, оставившего отзыв
        public int ProductId { get; set; }            // Идентификатор товара, к которому относится отзыв
        public string Text { get; set; }              // Текст отзыва
        public int Rating { get; set; }               // Рейтинг отзыва

        // Внешние ключи для связи с пользователем и товаром
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
