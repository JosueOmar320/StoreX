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
    public class PurchaseOrderLine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PurchaseOrderLineId { get; set; }

        [Required]
        public int PurchaseOrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public decimal QuantityOrdered { get; set; }

        public decimal? QuantityReceived { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        //[NotMapped]
        //public decimal? TotalPrice => Quantity * UnitPrice;

        [JsonIgnore]
        [ForeignKey("PurchaseOrderId")]
        public PurchaseOrder? PurchaseOrder { get; set; }

        [JsonIgnore]
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
    }
}
