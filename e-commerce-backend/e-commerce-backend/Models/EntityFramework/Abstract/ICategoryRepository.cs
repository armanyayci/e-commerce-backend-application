using e_commerce_backend.Models.Entity;

namespace e_commerce_backend.Models.EntityFramework.Abstract
{
    public interface ICategoryRepository
    {
        Category findById(int id);

        IQueryable<Category> findAll { get; }

        void createCategory(Category category);

    }
}
