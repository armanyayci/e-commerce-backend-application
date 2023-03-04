using e_commerce_backend.Models.Entity;
using e_commerce_backend.Models.EntityFramework.Abstract;

namespace e_commerce_backend.Models.EntityFramework.Concrete
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EFCategoryRepository> logger;
        public EFCategoryRepository(ApplicationDbContext context, ILogger<EFCategoryRepository> logger) {
            
            _context = context;
            this.logger = logger;
        }

        IQueryable<Category> ICategoryRepository.findAll => _context.Categories;



        public void createCategory(Category category)
        {

            try
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                logger.LogWarning("category couldnt add to database in repository.");
                throw;
            }
        }

        public Category findById(int id)
        {
            try
            {
                IQueryable<Category> query = _context.Categories.Where(i => i.Id == id);
                Category category = query.FirstOrDefault();

                return category;
            }
            catch (Exception)
            {
                logger.LogWarning($"category repository couldnt find category with id -> {id} in database.");
                throw;
            }

        }
    }
}
