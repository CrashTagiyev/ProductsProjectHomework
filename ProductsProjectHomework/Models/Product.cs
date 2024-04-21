using System.ComponentModel.DataAnnotations;

namespace ProductsProjectHomework.Models
{
   
    public class Product
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public double Price { get; set; }

        public Product()
        {
        }
    }

 
    
}
