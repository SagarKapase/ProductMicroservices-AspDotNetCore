using System.ComponentModel.DataAnnotations.Schema;

namespace ProductMicroservices.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        [NotMapped]
        public Category Category { get;}
    }
}
