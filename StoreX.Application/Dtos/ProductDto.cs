using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Application.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        public required string Name { get; set; }

        public required string BrandName { get; set; }
    }
}
