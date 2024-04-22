using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Part3RazorPages.Models
{
    public class Product
    {
        
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string Name { get; set; } = String.Empty;

        [Range(1,10000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Display(Name = "Quantity")]
        public int Qty { get; set; }


    }
}
