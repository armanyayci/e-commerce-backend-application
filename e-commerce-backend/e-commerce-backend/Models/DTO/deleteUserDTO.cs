using System.ComponentModel.DataAnnotations;

namespace e_commerce_backend.Models.DTO
{
    public class deleteUserDTO
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public bool agreed { get; set; }

    }
}