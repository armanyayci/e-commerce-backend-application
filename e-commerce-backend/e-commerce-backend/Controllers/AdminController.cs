using e_commerce_backend.Identity;
using e_commerce_backend.Models.DTO;
using e_commerce_backend.Models.Entity;
using e_commerce_backend.Models.EntityFramework.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_backend.Controllers
{

    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AdminController(ILogger<AdminController> logger
            ,UserManager<ApplicationUser> userManager
            ,RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            this.logger = logger;
        }   

        public  IActionResult getUsers()
        {
            try
            {
                List<ApplicationUser> users = new List<ApplicationUser>();

                users = _userManager.Users.ToList();
                return Ok(users);
            }
            catch (Exception)
            {
                logger.LogWarning("users couldnt get from db in api");
                throw;
            }  
        }

        public async Task <IActionResult> deleteUser([FromBody] deleteUserDTO dTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (dTO.agreed)
                    {
                        ApplicationUser user = await _userManager.FindByNameAsync(dTO.userName);
                        await _userManager.DeleteAsync(user);
                        return Ok(user);
                    }
                    return BadRequest("Agree must be true.");
                   
                }

                return Ok("ModelStateIsNotValid");
            }
            catch (Exception)
            {
                logger.LogWarning("delete user has crushed.");
                throw;
            }
        }
        
        public async Task<IActionResult>getUser(int id)
        {
            try
            {
                ApplicationUser user = await _userManager.FindByIdAsync(id.ToString());
               
                return Ok(user);
            }
            catch (Exception)
            {
                logger.LogWarning("getuser has crushed");
                throw;
            }
        }


        [HttpPost]
        public async Task<IActionResult> assignRole([FromBody] assignUserDto dTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindByNameAsync(dTO.userName);
                    var userroles = await _userManager.GetRolesAsync(user);

                    if (await _roleManager.RoleExistsAsync(dTO.newRole))
                    {
                        if (!await _userManager.IsInRoleAsync(user, dTO.newRole))
                        {
                            await _userManager.RemoveFromRolesAsync(user, userroles);

                            await _userManager.AddToRoleAsync(user, dTO.newRole);
                            return Ok(dTO);
                        }

                        return BadRequest("User already has this role");
                    }

                    return BadRequest($"There is no role with this name {dTO.newRole}");
                }

                return BadRequest("ModelStateIsNotValid");
            }
            catch (Exception)
            {
                logger.LogWarning("assing role has crushed.");
                throw;
            }          
        }
    }
}
