using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Dtos
{
    public class CreateProductDto
    {
        [Required, StringLength(56, MinimumLength = 4)]
        public string Name { get; set; }
        [Required, StringLength(56, MinimumLength = 4)]
        public string Brand { get; set; }
        [Required, Range(1, 50000)]
        public double Price { get; set; }
    }
}
