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
    public class MovementLine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovementLineId { get; set; }

        [Required]
        public int MovementId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public decimal Quantity { get; set; } = decimal.Zero;

        [Required]
        public decimal UnitPrice { get; set; } = decimal.Zero;

        [NotMapped]
        public decimal TotalPrice => Quantity * UnitPrice;

        [JsonIgnore]
        [ForeignKey("MovementId")]
        public Movement? Movement { get; set; }

        [JsonIgnore]
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
    }
}
