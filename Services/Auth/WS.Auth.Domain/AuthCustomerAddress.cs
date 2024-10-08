﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Constant.Database;

namespace WS.Auth.Domain
{
    [Table(nameof(AuthCustomerAddress), Schema = DbSchema.Auth)]
    public class AuthCustomerAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        [MaxLength(100)]
        public string IsDefault { get; set; }
    }
}
