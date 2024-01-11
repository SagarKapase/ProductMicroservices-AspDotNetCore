using ProductMicroservices.Models;

namespace ProductMicroservices.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}
