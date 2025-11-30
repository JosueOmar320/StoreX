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
    public class ProductPriceDto
    {
        public int ProductPriceId { get; set; }

        public int ProductId { get; set; }

        public decimal Price { get; set; }

        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        public DateTime? EndDate { get; set; } // null = precio actual

        public string ProductName { get; set; }
    }
}
