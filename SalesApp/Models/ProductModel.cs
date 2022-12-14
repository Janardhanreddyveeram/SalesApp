using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SalesApp.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string ModelName { get; set; }
        
        public string Description { get; set; }
        [Required]
        [Display(Name = "Receiving Price")]
        public decimal ReceivingPrice { get; set; }
        [Required]
        [Display(Name = "Selling Price")]
        public decimal Price { get; set; }
        [Required]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        [ValidateNever]
        public string ImageUrl { get; set; }

    }
}
