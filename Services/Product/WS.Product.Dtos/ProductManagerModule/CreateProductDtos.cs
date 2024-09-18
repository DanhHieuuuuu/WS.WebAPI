using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Product.Dtos.ProductManagerModule
{
    public class CreateProductDtos
    {
        [MaxLength(255)]
        public string Name { get; set; }
        public int Quantity { get; set; }

        public int CreatedBy { get; set; }
    }
}
