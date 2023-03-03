using e_commerce_backend.Controllers;
using e_commerce_backend.Models.Entity;
using e_commerce_backend.Models.EntityFramework.Abstract;

namespace e_commerce_backend.Models.EntityFramework.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ILogger<EFProductRepository> logger;

        private readonly ApplicationDbContext _context;

        public EFProductRepository(ApplicationDbContext context, ILogger<EFProductRepository> logger)
        {
            _context = context;
            this.logger = logger;
        }

        public IQueryable<Product> getProducts => _context.Products.Where(i=>i.isActive == true) ;

        public void AddProduct(Product product)
        {
            try
            {
                _context.Add(product);
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
                return _context.Products.Where(i => i.Category.Id == category_id && i.isActive == true);
            }
            catch (Exception)
            {
                logger.LogWarning("products by category couldnt get from database.");
                throw;
            }
        }

        public IQueryable<Product> getProductsById(int product_id)
        {
            try
            {
                return _context.Products.Where(i => i.Id == product_id && i.isActive == true);
            }
            catch (Exception)
            {
                logger.LogWarning("products by id couldnt get from database.");
                throw;
            }
            
        }
    }
}
