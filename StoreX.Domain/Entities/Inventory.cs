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
    public class Inventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InventoryId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public decimal QuantityAvailable { get; set; } = 0;

        [Required]
        public decimal QuantityReserverd { get; set; } = decimal.Zero;

        [Required]
        public decimal AverageCost { get; set; } = decimal.Zero;

        [JsonIgnore]
        [Required]
        public DateTime LastUpdate { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
    }
}
