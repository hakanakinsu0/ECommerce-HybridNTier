using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class Order : BaseEntity
    {
        public string ShippingAddress { get; set; }
        public decimal Price { get; set; }
        public string? UserEmail { get; set; } 
        public string? UserDescription { get; set; }

        //Foreign Key
        public int? AppUserId { get; set; }

        //Relational Properties
        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
