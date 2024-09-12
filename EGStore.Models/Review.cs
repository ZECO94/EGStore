using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGStore.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Range(1,5)]
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime PostedOn { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public Product Product { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
