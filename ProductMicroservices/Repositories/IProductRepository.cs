using ProductMicroservices.Models;

namespace ProductMicroservices.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById (int ProductId);
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int ProductId);
        void Save();

    }
}
