using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SweetArt.Models
{
    public class OrderItem
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
