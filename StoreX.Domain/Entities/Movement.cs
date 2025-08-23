using StoreX.Domain.Enums;
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
    public class Movement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovementId { get; set; }
        //public required string SourceType { get; set; } // "PurchaseOrder", "SalesOrder", "Adjustment", etc.
        //public long SourceId { get; set; }
        public int? PurchaseOrderId { get; set; }
        public int? OrderId { get; set; }

        [Required]
        public MovementType MovementType { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        [Required]
        public int CreatedBy { get; set; }

        [JsonIgnore]
        [ForeignKey("CreatedBy")]
        public User? User { get; set; }

        [JsonIgnore]
        [ForeignKey("PurchaseOrderId")]
        public PurchaseOrder? PurchaseOrder { get; set; }

        [JsonIgnore]
        [ForeignKey("OrderId")]
        public Order? Order { get; set; }
    }
}
