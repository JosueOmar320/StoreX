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
    public class CashSession
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CashSessionId { get; set; }

        [Required]
        public int UserId { get; set; }   // Cajero

        [Required]
        public DateTime OpenedAt { get; set; }

        public DateTime? ClosedAt { get; set; }

        [Required]
        public decimal OpeningBalance { get; set; } = decimal.Zero;

        public decimal? ClosingBalance { get; set; }

        [JsonIgnore]
        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
