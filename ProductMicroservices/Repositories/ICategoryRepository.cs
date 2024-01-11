using ProductMicroservices.DTOs;
using ProductMicroservices.Models;

namespace ProductMicroservices.Repositories
{
    public interface ICategoryRepository
    {
        CategoryDTO AddCategory(Category category);
        Category GetCategoryById(int categoryId);
        IEnumerable<CategoryDTO> GetAllCategories();

        CategoryDTO UpdateCategory(Category category, int id);

        string DeleteCategory(int categoryId);
    }
}
