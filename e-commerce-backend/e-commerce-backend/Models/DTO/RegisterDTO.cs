using System.ComponentModel.DataAnnotations;

namespace e_commerce_backend.Models.DTO
{
    public class RegisterDTO
    {

        [Required]
        public string name { get; set; }
        [Required]
        public string surname { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }

        [Compare("password")]
        public string comfirmPassword { get; set; }

    }
}
