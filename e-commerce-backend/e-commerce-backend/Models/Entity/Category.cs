using System.ComponentModel.DataAnnotations;

namespace e_commerce_backend.Models.Entity
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public List<Product> Products { get; set; }



    }
}
