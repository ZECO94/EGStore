using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGStore.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int ProductsQuantity { get; set; }
        public double UnitPrice { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Product? Product { get; set; }
        public Order? Order { get; set; }
    }
}
