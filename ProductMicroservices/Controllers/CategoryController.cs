using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            using(var scope = new TransactionScope())
            {
                categoryRepository.AddCategory(category);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
            }
        }

        [HttpGet("GetSingleCategory/{categoryId}")]
        public IActionResult Get(int categoryId)
        {
            var category = categoryRepository.GetProductById(categoryId);
            return new OkObjectResult(category);
        }

        [HttpGet("GetAllCategories")]
        public IActionResult Get()
        {
            var products = categoryRepository.GetAllCategories();
            return new OkObjectResult(products);

        }

        /*[HttpPut("updateCategory/{categoryId}")]
        public IActionResult updateCategory([FromBody] Category category)
        {
            
        }*/
    }
}
