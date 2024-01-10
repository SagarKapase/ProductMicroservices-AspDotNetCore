using System.ComponentModel.DataAnnotations.Schema;

namespace ProductMicroservices.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        /*[NotMapped]*/
        //public List<Product> Products { get; }
    }
}
