using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Order.Dtos.OrderManagerModule
{
    public class OrderOrderDtos
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
        public int ProductId { get; set; }
        public int Quantiy { get; set; }
    }
}
