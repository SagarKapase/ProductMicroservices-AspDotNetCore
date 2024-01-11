using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservices.DTOs;
using ProductMicroservices.Models;
using ProductMicroservices.Repositories;
using System.Transactions;

namespace ProductMicroservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpPost("addCategory")]
        public IActionResult AddCategory([FromBody] Category category)
        {
            using (var scope = new TransactionScope())
            {
                CategoryDTO newCategory = categoryRepository.AddCategory(category);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = category.Id }, newCategory);
            }
        }

        [HttpGet("GetSingleCategory/{categoryId}")]
        public IActionResult Get(int categoryId)
        {
            Category category = categoryRepository.GetCategoryById(categoryId);
            if (category == null)
            {
                return NotFound();
            }

            var categoryDto = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Products = category.Products.Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                }).ToList()
            };
            return Ok(categoryDto);
        }

        [HttpGet("GetAllCategories")]
        public IActionResult Get()
        {
            var products = categoryRepository.GetAllCategories();
            return new OkObjectResult(products);

        }

        [HttpPut("updateCategory/{id}")]
        public IActionResult updateCategory([FromBody] Category category, int id)
        {
            CategoryDTO updatedCategory = categoryRepository.UpdateCategory(category, id);

            return Ok(updatedCategory);
        }

        [HttpDelete("delete/{id}")]
        public string DeleteCategory(int categoryId)
        {
            categoryRepository.DeleteCategory(categoryId);
            return "HO gaya samadhan";
        }
    }
}
