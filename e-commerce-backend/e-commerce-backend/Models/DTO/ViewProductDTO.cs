using e_commerce_backend.Models.Entity;
using Microsoft.Identity.Client;

namespace e_commerce_backend.Models.DTO
{
    public class ViewProductDTO
    {
        public string name { get; set; }
        public string description { get; set; } 
        public double price { get;set; }
        public int quantity { get; set; }
        public String category { get; set; }


        public static ViewProductDTO Convert (Product product) 
        {
            ViewProductDTO dto = new ViewProductDTO()
            {
                name = product.name,
                description = product.description,
                price = product.price,
                quantity = product.quantity 
            };

            return dto;
        }


    }
}
