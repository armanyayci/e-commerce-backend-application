using e_commerce_backend.Identity;
using e_commerce_backend.Models.DTO;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;



namespace e_commerce_backend.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;



        public AccountController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            ILogger<AccountController> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            this.logger = logger;
        }



        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return Ok();
        }




        [HttpPost]
        public async Task <IActionResult>Register([FromBody] RegisterDTO dTO)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    ApplicationUser user = new ApplicationUser()
                    {
                        name = dTO.name,
                        surname = dTO.surname,
                        UserName = dTO.username,
                        Email = dTO.email
                    };
                    var result = await _userManager.CreateAsync(user,dTO.password);


                    if ( await _roleManager.RoleExistsAsync("User")) 
                    {
                        await _userManager.AddToRoleAsync(user, "User");
                    }
                    else
                    {
                        logger.LogWarning("role is not exist");
                    }
                    

                    if (result.Succeeded)
                    {
                        return Ok(dTO);
                    }

                    return BadRequest(result.Errors);
                }
                logger.LogWarning("modelstate is not valid in register.");
                return BadRequest();

            }
            catch (Exception)
            {
                logger.LogWarning("register operation has crushed.");
                throw;
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto dTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(dTO.username,dTO.password,false,true);

                    if (result.Succeeded)
                    {
                        return Ok(dTO);
                    }
                    return BadRequest("Invalid user information");

                }
                else
                {
                    logger.LogWarning("modelstate is not valid.");
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                logger.LogWarning("login operation has crushed in api");
                throw;
            }
        }

        public async Task<IActionResult> LogOut()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return Ok();
            }
            catch (Exception)
            {
                logger.LogWarning("logout operation has crushed in api");
                throw;
            }
        }
    }
}
