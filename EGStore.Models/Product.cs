using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string Image { get; set; }
        public double Rate { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set;}
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        
        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public Category? Category { get; set; }
        public Brand? Brand { get; set;}
        public IEnumerable<Review>? Reviews { get; set;}
    }
}
