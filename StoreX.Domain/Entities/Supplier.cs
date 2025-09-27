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
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierId { get; set; }

        [Required]
        [MaxLength(150)]
        public required string Name { get; set; }

        [MaxLength(100)]
        public string? ContactName { get; set; }

        [MaxLength(250)]
        [EmailAddress]
        public string? Email { get; set; }

        [MaxLength(50)]
        public string? PhoneNumber { get; set; }

        [Required]
        [JsonIgnore]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [JsonIgnore]
        public bool IsActive { get; set; } = true;

        [JsonIgnore]
        public ICollection<Product>? Products { get; set; }
    }
}
