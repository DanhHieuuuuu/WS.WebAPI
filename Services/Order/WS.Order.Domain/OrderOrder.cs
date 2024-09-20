using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Constant.Database;

namespace WS.Order.Domain
{
    [Table(nameof(OrderOrder), Schema = DbSchema.Order)]
    public class OrderOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
        public int ProductId { get; set; }
        public int Quantiy { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
