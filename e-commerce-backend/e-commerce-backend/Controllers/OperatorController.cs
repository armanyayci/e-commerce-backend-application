using e_commerce_backend.Identity;
using e_commerce_backend.Models.DTO;
using e_commerce_backend.Models.Entity;
using e_commerce_backend.Models.EntityFramework.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_backend.Controllers
{
    [Authorize(Roles ="Admin,Operator")]
    public class OperatorController : Controller
    {

        private readonly ILogger<OperatorController> logger;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public OperatorController(IProductRepository productRepository
            , ICategoryRepository categoryRepository
            , ILogger<OperatorController> logger
            , UserManager<ApplicationUser> userManager
            , RoleManager<ApplicationRole> roleManager)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _userManager = userManager;
            _roleManager = roleManager;
            this.logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] Category category)
        {
            try
            {
                _categoryRepository.createCategory(category);
                return Ok(category);
            }
            catch (Exception)
            {
                logger.LogWarning("category couldnt post in api.");
                throw;
            }
        }

        [HttpPost]
        public IActionResult postProduct([FromBody] AddProductDTO dTO)
        {
            try
            {
                Product product = new Product
                {
                    name = dTO.name,
                    price = dTO.price,
                    description = dTO.description,
                    quantity = dTO.quantity,
                    Category = _categoryRepository.findById(dTO.category_id),
                    isActive = true
                };
                _productRepository.AddProduct(product);
                return Ok(product);
            }
            catch (Exception)
            {
                logger.LogWarning("product couldnt post in api with dto");
                throw;
            }
        }

        public IActionResult deleteProduct(int id)
        {

            try
            {
                var deleted_product = _productRepository.getProductById(id);
                _productRepository.softdelete(deleted_product);
                return Ok(deleted_product);
            }
            catch (Exception)
            {
                logger.LogWarning($"product couldnt deactive by id -> {id} in api");
                throw;
            }
        }

        public IActionResult activeProduct(int id)
        {
            try
            {
                _productRepository.activeproduct(id);
                return Ok(_productRepository.getProductById(id));
            }
            catch (Exception)
            {
                logger.LogWarning($"product with id -> {id} couldnt active in api");
                throw;
            }
        }















    }
}
