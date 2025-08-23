using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StoreX.Domain.Entities
{
    public class ProductPrice
    {
        [Key]
        public int ProductPriceId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        public DateTime? EndDate { get; set; } // null = precio actual

        //public string? PriceType { get; set; } // "Retail", "Wholesale", "Promo"
        [JsonIgnore]
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
    }
}
