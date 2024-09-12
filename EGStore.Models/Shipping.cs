using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Models
{
    public class Shipping
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string AgentName { get; set; }
        public string AgentPhoneNumber { get; set; }
        public IEnumerable<Order> Orders { get; set; }

    }
}
