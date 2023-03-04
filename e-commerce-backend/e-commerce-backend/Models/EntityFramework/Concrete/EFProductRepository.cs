using e_commerce_backend.Controllers;
using e_commerce_backend.Models.Entity;
using e_commerce_backend.Models.EntityFramework.Abstract;

namespace e_commerce_backend.Models.EntityFramework.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ILogger<EFProductRepository> logger;

        private readonly ApplicationDbContext _context;

        private readonly ICategoryRepository _categoryRepository;

        public EFProductRepository(
            ApplicationDbContext context,
            ICategoryRepository categoryRepository,
            ILogger<EFProductRepository> logger)
        {
            _context = context;
            this.logger = logger;
            _categoryRepository = categoryRepository;
        }

        public IQueryable<Product> getProducts => _context.Products.Where(i=>i.isActive == true) ;

        public void AddProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                logger.LogWarning("products couldnt added to database.");
                throw;
            }
        }

        public IQueryable<Product> getProductsByCategory(int category_id)
        {
            try
            {
                return _context.Products.Where(i => i.Category_Id == category_id && i.isActive == true);
            }
            catch (Exception)
            {
                logger.LogWarning("products by category couldnt get from database.");
                throw;
            }
        }

        public Product getProductById(int product_id)
        {
            try
            {
                var product = _context.Products.Where(i => i.Id == product_id && i.isActive == true).FirstOrDefault();
                return product;
            }
            catch (Exception)
            {
                logger.LogWarning("products by id couldnt get from database.");
                throw;
            }
            
        }

        public void softdelete(Product deleted_product)
        {
            try
            {
                var product = _context.Products.Where(i => i.Id == deleted_product.Id).FirstOrDefault();
                product.isActive = false;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                logger.LogWarning($"product with id -> {deleted_product.Id} couldnt deactive in database");
                throw;
            }
        }
        public void activeproduct(int id)
        {
            try
            {
                var product = _context.Products.Where(i => i.Id  == id).FirstOrDefault();
                product.isActive = true;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                logger.LogWarning($"product with id -> {id} couldnt active in database");
                throw;
            }
        }
    }
}
