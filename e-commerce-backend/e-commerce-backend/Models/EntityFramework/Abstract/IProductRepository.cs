using e_commerce_backend.Models.Entity;

namespace e_commerce_backend.Models.EntityFramework.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Product> getProducts { get; }

        void AddProduct(Product product);

        Product getProductById(int product_id);

        IQueryable<Product> getProductsByCategory(int category_id);
        void softdelete(Product deleted_product);

        void activeproduct(int id);
    }
}
