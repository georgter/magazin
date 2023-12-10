using System.ComponentModel.DataAnnotations;

namespace magazin.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }

    
}
