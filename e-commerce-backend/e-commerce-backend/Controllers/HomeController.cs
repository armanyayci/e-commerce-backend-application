using e_commerce_backend.Models;
using e_commerce_backend.Models.DTO;
using e_commerce_backend.Models.Entity;
using e_commerce_backend.Models.EntityFramework.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

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
                var products = _productRepository.getProducts.ToList();

                List<ViewProductDTO> productsDTO = new List<ViewProductDTO>();

                foreach (var item in products)
                {
                    var dto = ViewProductDTO.Convert(item);
                    var category = _categoryRepository.findById(item.Category_Id);
                    dto.category = category.Name;
                    productsDTO.Add(dto);
                }

                return Ok(productsDTO);
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
                var product = _productRepository.getProductById(id);
                var dto = ViewProductDTO.Convert(product);
                var category = _categoryRepository.findById(product.Category_Id);
                dto.category = category.Name;
                return Ok(dto);
            }
            catch (Exception)
            {
                logger.LogWarning($"productdetail by id -> {id} couldnt get the detail in api ");
                throw;
            }
        }
            public IActionResult productsByCategory(int id) 
        {
            try
            {
                var products = _productRepository.getProductsByCategory(id).ToList();
                List<ViewProductDTO> productsDTO = new List<ViewProductDTO>();

                foreach (var item in products)
                {
                    var dto = ViewProductDTO.Convert(item);
                    var category = _categoryRepository.findById(item.Category_Id);
                    dto.category = category.Name;
                    productsDTO.Add(dto);
                }

                return Ok(productsDTO);
            }
            catch (Exception)
            {
                logger.LogWarning($"Products by category {id} couldnt get in api");
                throw;
            }
        }
    }
}