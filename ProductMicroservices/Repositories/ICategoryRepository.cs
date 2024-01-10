using ProductMicroservices.Models;

namespace ProductMicroservices.Repositories
{
    public interface ICategoryRepository
    {
        void AddCategory(Category category);
        Category GetProductById(int categoryId);
    }
}
