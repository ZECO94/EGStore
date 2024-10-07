using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGStore.Models
{
    public class WishList
    {
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        [ValidateNever]
        public string ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        [ForeignKey("Product")]
        [ValidateNever]
        public int ProductId { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual Product Product { get; set; }
        
        

    }
}
