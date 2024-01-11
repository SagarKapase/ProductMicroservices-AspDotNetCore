using ProductMicroservices.DTOs;
using ProductMicroservices.Models;

namespace ProductMicroservices.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById (int ProductId);
        ProductDTO InsertProduct(Product product);
        ProductDTO UpdateProduct(Product product,int id);
        string DeleteProduct(int ProductId);
        void Save();

    }
}
