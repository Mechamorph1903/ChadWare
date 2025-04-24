using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ChadWare.Models
{
    [Table("Orders")]
    public class Order
    {
        [PrimaryKey, AutoIncrement]
        // PK column, auto-incremented
        public long OrderID { get; set; }

        // FK to your User table
        public long UserID { get; set; }

        // Total amount for the order
        public decimal TotalPrice { get; set; }

        // Timestamp when the order was created
        public DateTime OrderDate { get; set; }

        // These two properties are NOT stored in the "Order" table
        [Ignore]
        public List<OrderItem> Items { get; set; }

        [Ignore]
        public Address ShippingAddress { get; set; }

        // Parameterless ctor required by sqlite-net
        public Order()
        {
            Items = new List<OrderItem>();
            OrderDate = DateTime.UtcNow;
        }
    }
}
