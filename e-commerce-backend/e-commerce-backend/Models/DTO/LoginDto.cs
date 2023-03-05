using System.ComponentModel.DataAnnotations;

namespace e_commerce_backend.Models.DTO
{
    public class LoginDto
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }

        public bool RememberMe { get; set; }
    }
}
