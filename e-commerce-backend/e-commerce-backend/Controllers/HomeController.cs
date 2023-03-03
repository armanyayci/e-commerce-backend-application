using e_commerce_backend.Models;
using e_commerce_backend.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace e_commerce_backend.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }

        public IActionResult Index()
        {
            logger.LogInformation("index sayfasına gidildi");
            return View();
        }


























        [HttpGet]
        public List<Product> getProducts()
        {
            try
            {
                var products = ProductRepository.products;
                return products;
            }
            catch (Exception e)
            {
                logger.LogWarning("home controller getproducts method has issue");
                throw e;
            }
        }

        [HttpPost]
        public IActionResult postProducts( [FromBody] Product product)
        {
            try
            {
                ProductRepository.AddProduct(product);
                return Ok(product);
            }
            catch (Exception e )
            {
                logger.LogWarning("home controller postproducts has issue");
                throw e;
            }      
        }

    }
}