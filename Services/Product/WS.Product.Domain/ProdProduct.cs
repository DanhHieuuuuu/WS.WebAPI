﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WS.Constant.Database;
namespace WS.Product.Domain
{
    [Table(nameof(ProdProduct), Schema = DbSchema.Product)]
    public class ProdProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        public int  Quantity { get; set; }

        public int CreatedBy { get; set; }

    }
}
