using e_commerce_backend.Models;
using e_commerce_backend.Models.DTO;
using e_commerce_backend.Models.Entity;
using e_commerce_backend.Models.EntityFramework.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace e_commerce_backend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public HomeController(IProductRepository productRepository,ICategoryRepository categoryRepository ,ILogger<HomeController> logger)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            this.logger = logger;
        }


        public IActionResult Index()
        {
            logger.LogInformation("Index page has shown");
            return View();
        }

        public IActionResult getProducts()
        {
            try
            {
                var x = _productRepository.getProducts.ToList();
                return Ok(x);
            }
            catch (Exception)
            {
                logger.LogWarning("products couldnt get in api ");
                throw ;
            }
        }

        public IActionResult productDetail(int id) 
        {
            try
            {
                var x = _productRepository.getProductById(id);
                return Ok(x);
            }
            catch (Exception)
            {
                logger.LogWarning($"productdetail by id -> {id} couldnt get the detail in api ");
                throw;
            }
        }

        public IActionResult productsByCategory(int category_id) 
        
        {
            try
            {
                logger.LogWarning($"Products by category id -> {category_id} couldnt list in api");
                var x = _productRepository.getProductsByCategory(category_id).ToList();
                return Ok(x);
            }
            catch (Exception)
            {
                logger.LogWarning($"Products by category {category_id} couldnt get in api");
                throw;
            }
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
        public IActionResult postProducts( [FromBody] AddProductDTO dTO)
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
            catch (Exception )
            {
                logger.LogWarning("product couldnt post in api with dto");
                throw;
            }      
        }

    }
}