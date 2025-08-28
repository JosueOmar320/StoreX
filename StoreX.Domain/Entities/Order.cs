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
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public int? CustomerId { get; set; }

        //public status status { get; set; } = status.Pending;

        [Required]
        public decimal SubTotal { get; set; } = 0;

        public decimal Discount { get; set; } = 0;

        [Required]
        public decimal Total { get; set; } = 0;

        public int? CashSessionId { get; set; }

        [Required]
        public int CreatedBy { get; set; }

        [JsonIgnore]
        [ForeignKey("CreatedBy")]
        public User? User { get; set; }

        [JsonIgnore]
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }

        [JsonIgnore]
        [ForeignKey("CashSessionId")]
        public CashSession? CashSession { get; set; }
    }
}
