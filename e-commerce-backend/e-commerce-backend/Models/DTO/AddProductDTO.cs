using e_commerce_backend.Models.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace e_commerce_backend.Models.DTO
{
    public class AddProductDTO
    {
        [Required]
        public string? name { get; set; }
        [Required]
        public string? description { get; set; }
        [Required]
        public double price { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        public int category_id { get; set; }




    }
}
