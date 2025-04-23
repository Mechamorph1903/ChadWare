using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Postgrest.Attributes;

namespace ChadWare.Models
{
    [Table("Orders")]
    public class Order
    {
        [PrimaryKey("orderID", false)]
        public long OrderID { get; set; }

        [Column("userID")]
        public long UserID { get; set; }

        [Column("totalPrice")]
        public decimal TotalPrice { get; set; }

        [Column("orderDate")]
        public DateTime OrderDate { get; set; }

        // These two aren’t stored in the Orders row directly:
        [Ignore]
        public List<OrderItem> Items { get; set; }

        [Ignore]
        public Address ShippingAddress { get; set; }

        public Order()
        {
            Items = new List<OrderItem>();
        }
    }
}

