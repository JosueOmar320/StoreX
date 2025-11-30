using StoreX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StoreX.Application.Dtos
{
    public class InventoryDto
    {
        public int InventoryId { get; set; }

        public int ProductId { get; set; }

        public decimal QuantityAvailable { get; set; } = 0;

        public decimal QuantityReserverd { get; set; } = decimal.Zero;

        public decimal AverageCost { get; set; } = decimal.Zero;

        public DateTime LastUpdate { get; set; } = DateTime.UtcNow;


        public string ProductName { get; set; }
    }
}
