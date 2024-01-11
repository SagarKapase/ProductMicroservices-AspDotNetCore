using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductMicroservices.DBContexts;
using ProductMicroservices.DTOs;
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
        public string DeleteProduct(int ProductId) //Delete a product by product id
        {
            var product = _context.Products.Find(ProductId);
            _context.Products.Remove(product);
            Save();

            return "Product Successfully Deleted...";
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int ProductId)
        {
            return _context.Products.Find(ProductId);
        }

        public ProductDTO InsertProduct(Product product)
        {
            var entity = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
            };

            _context.Products.Add(entity);
            Save();

            var CreatedProduct = new ProductDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                CategoryId = entity.CategoryId
            };

            return CreatedProduct;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public ProductDTO UpdateProduct(Product product, int id)
        {
            /*_context.Entry(product).State = EntityState.Modified;
            Save();*/
            var getProduct = GetProductById(id);

            if (getProduct == null)
            {
                return null;
            }

            getProduct.Name = product.Name;
            getProduct.Description = product.Description;
            getProduct.Price = product.Price;
            getProduct.CategoryId = product.CategoryId;

            _context.Entry(getProduct).State = EntityState.Modified;
            Save();

            var updatedUser = new ProductDTO
            {
                Id = getProduct.Id,
                Name = getProduct.Name,
                Description = getProduct.Description,
                Price = getProduct.Price,
                CategoryId = product.CategoryId
            };

            return updatedUser;


        }
    }
}
