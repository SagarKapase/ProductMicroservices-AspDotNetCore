using Microsoft.EntityFrameworkCore;
using ProductMicroservices.DBContexts;
using ProductMicroservices.DTOs;
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
        public CategoryDTO AddCategory(Category category)
        {
            var categoryEntity = new Category
            {
                Name = category.Name,
                Description = category.Description
            };

            _context.categories.Add(categoryEntity);
            _context.SaveChanges();

            var createdCategory = new CategoryDTO
            {
                Id = categoryEntity.Id,
                Name = categoryEntity.Name,
                Description = categoryEntity.Description
            };

            return createdCategory;
        }

        public string DeleteCategory(int categoryId)
        {
            var category = GetCategoryById(categoryId);
            if (category == null)
            {
                return null;
            }
            _context.categories.Remove(category);

            return "Ho gaya Samadhan...";
        }

        public IEnumerable<CategoryDTO> GetAllCategories()
        {
            //return _context.categories.ToList();
            var categories = _context.categories.Include(category => category.Products).ToList();

            //Mapping entities to dto
            var categoryDto = categories.Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Products = c.Products.Select(p => new ProductDTO
                {

                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                }).ToList()


            });

            return categoryDto;
        }

        public Category GetCategoryById(int categoryId)
        {
            //return _context.categories.Find(categoryId);
            return _context.categories
            .Include(c => c.Products)
            .SingleOrDefault(c => c.Id == categoryId);
        }

        public CategoryDTO UpdateCategory(Category category, int id)
        {
            var getCategory = GetCategoryById(id);

            if (getCategory == null)
            {
                return null;
            }

            getCategory.Name = category.Name;
            getCategory.Description = category.Description;

            _context.Entry(getCategory).State = EntityState.Modified;
            _context.SaveChanges();

            var updatedCategory = new CategoryDTO
            {
                Id = getCategory.Id,
                Name = getCategory.Name,
                Description = getCategory.Description
            };
            return updatedCategory;
        }
    }
}
