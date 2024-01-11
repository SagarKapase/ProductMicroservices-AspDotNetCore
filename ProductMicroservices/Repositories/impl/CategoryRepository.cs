using ProductMicroservices.DBContexts;
using ProductMicroservices.Models;

namespace ProductMicroservices.Repositories.impl
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly ProductContext _context; // added product context here

        public CategoryRepository(ProductContext context)
        {
            _context = context;
        }
        public void AddCategory(Category category)
        {
            var categoryEntity = new Category
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };

            _context.categories.Add(categoryEntity);
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.categories.ToList();
        }

        public Category GetProductById(int categoryId)
        {
            return _context.categories.Find(categoryId);
        }
    }
}
