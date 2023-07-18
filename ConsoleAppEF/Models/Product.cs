using System.ComponentModel.DataAnnotations;

namespace ConsoleAppEF.Models
{
    public enum PRODUCT_CATEGORY { Sumos, Aguas, Chocolates }

    internal class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
 
        public string? Description { get; set; }

        public PRODUCT_CATEGORY Category { get; set; }

        public double Price { get; set; }
    }
}
