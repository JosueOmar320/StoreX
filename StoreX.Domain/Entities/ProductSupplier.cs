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
    public class ProductSupplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductSupplierId { get; set; } //test

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int SupplierId { get; set; }

        public decimal? PurchasePrice { get; set; }

        [JsonIgnore]
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        [JsonIgnore]
        [ForeignKey("SupplierId")]
        public Supplier? Supplier { get; set; }
    }
}
