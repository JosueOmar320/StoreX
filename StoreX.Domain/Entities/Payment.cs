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
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public required string Method { get; set; } // "Cash", "Card", "Transfer"

        [Required]
        public decimal Amount { get; set; }

        public int? CashMovementId { get; set; } // Solo si es efectivo

        [JsonIgnore]
        [ForeignKey("OrderId")]
        public Order? Order { get; set; }

        [JsonIgnore]
        [ForeignKey("CashMovementId")]
        public CashMovement? CashMovement { get; set; }
    }
}
