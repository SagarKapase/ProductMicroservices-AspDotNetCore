using Microsoft.EntityFrameworkCore;
using ProductMicroservices.DBContexts;
using ProductMicroservices.Models;

namespace ProductMicroservices.Repositories.impl
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context; // added product context here

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }
        public void DeleteProduct(int ProductId) //Delete a product by product id
        {
            var product = _context.Products.Find(ProductId);
            _context.Products.Remove(product);
            Save();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int ProductId)
        {
            return _context.Products.Find(ProductId);
        }

        public void InsertProduct(Product product)
        {
            var entity = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
            };

            _context.Products.Add(entity);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            Save();
        }
    }
}
