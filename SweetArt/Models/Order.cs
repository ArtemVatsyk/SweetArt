using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SweetArt.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime Date { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
