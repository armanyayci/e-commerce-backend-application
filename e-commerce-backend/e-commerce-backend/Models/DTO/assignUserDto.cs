using System.ComponentModel.DataAnnotations;

namespace e_commerce_backend.Models.DTO
{
    public class assignUserDto
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public string newRole { get; set; }




    }
}