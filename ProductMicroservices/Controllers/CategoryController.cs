using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservices.Models;
using ProductMicroservices.Repositories;

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
            categoryRepository.AddCategory(category);
            return CreatedAtAction(nameof(GetSingleCategory),new { id = category.Id }, category);
        }

        [HttpGet("GetSingleCategory/{categoryId}")]
        public IActionResult GetSingleCategory(int categoryId)
        {
            var category = categoryRepository.GetProductById(categoryId);
            return new OkObjectResult(category);
        }
    }
}
