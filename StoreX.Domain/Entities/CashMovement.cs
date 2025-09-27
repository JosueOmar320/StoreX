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
    public class CashMovement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CashMovementId { get; set; }

        [Required]
        public int CashSessionId { get; set; }

        [Required]
        public CashMovementType CashMovementType { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public string? Description { get; set; }

        [JsonIgnore]
        [ForeignKey("CashSessionId")]
        public CashSession? CashSession { get; set; }
    }
}
