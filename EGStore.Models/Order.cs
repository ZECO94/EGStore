using EGStore.Utility;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
        public DateTime ShippingDate { get; set; }
        public double TotalPrice { get; set; }
        [ForeignKey("ApplicationUser")]
        [ValidateNever]
        public string ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string? TrackingNumber { get; set; }
        public string? DeliveringAgent {  get; set; }
        public DateTime PaymentDate { get; set; }
        public DateOnly PaymentDueDate { get; set; }
        public string? PaymentId { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}
