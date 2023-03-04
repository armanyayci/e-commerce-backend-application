using e_commerce_backend.Models.DTO;
using e_commerce_backend.Models.Entity;
using e_commerce_backend.Models.EntityFramework.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_backend.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> logger;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public AdminController(IProductRepository productRepository, ICategoryRepository categoryRepository, ILogger<AdminController> logger)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            this.logger = logger;
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
                //var active_product = _productRepository.getProductById(id);
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
