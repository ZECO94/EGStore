using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGStore.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int Count { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public Product? Product { get; set; }

    }
}
