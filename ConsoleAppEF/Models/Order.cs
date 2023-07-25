using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace ConsoleAppEF.Models
{
    [Table("Orders")]
    internal class Order
    {
        [Key]
        [DefaultValue(true)]
        public Guid Id { get; set; }

        [Required]
        [Column("Date")]
        public DateTime OrderDate { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderNumber { get; set; }

        private int _quantity;
        [Required]
        public int Quantity { 
            get { return _quantity; }
            set { if (value < 0) throw new Exception(""); else _quantity = value; } }

        [Required]
        [ForeignKey("OrderId")]
        public IList<Product> Products { get; set; }

        [MaxLength(255)]
        [Column(TypeName = "varchar")]
        public string? Description { get; set; }

        [NotMapped]
        public double Total { get 
            {
                return Products.Sum(x => x.Price);
            } 
        }
    }
}
