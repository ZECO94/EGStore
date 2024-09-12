using EGStore.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        [ForeignKey("Shipping")]
        public int ShippingId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Shipping Shipping { get; set; }
        public IEnumerable<OrderDetails> OrderDetails { get; set; }
    }
}
