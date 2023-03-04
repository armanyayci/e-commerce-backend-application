using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerce_backend.Models.Entity
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public double price { get; set; }
        [Required]
        public int quantity { get; set; }

        [Required]
        public Boolean isActive { get; set; }

        //[ForeignKey("CategoryId")]

        public int Category_Id;
        public virtual Category Category { get; set; }



    }
}
