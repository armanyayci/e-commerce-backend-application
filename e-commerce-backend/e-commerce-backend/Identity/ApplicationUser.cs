using Microsoft.AspNetCore.Identity;

namespace e_commerce_backend.Identity
{
    public class ApplicationUser: IdentityUser<int>
    {
        public string name { get; set; }

        public string surname { get; set; }


    }
}
