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
    public class OrderLine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderLineId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public decimal Quantity { get; set; } 

        [Required]
        public decimal UnitPrice { get; set; }

        public decimal Discount { get; set; } = 0;

        [NotMapped]
        public decimal TotalLine => (Quantity * UnitPrice) - Discount;

        [JsonIgnore]
        [ForeignKey("OrderId")]
        public Order? Order { get; set; }

        [JsonIgnore]    
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
    }
}
