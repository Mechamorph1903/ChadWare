using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ChadWare.Models
{
    // Maps to the "OrderItem" table in SQLite
    [Table("OrderItem")]
    public class OrderItem
    {
        // Primary key, auto-incrementing
        [PrimaryKey, AutoIncrement]
        public long OrderItemID { get; set; }

        // Foreign key back to Order.OrderID
        public long OrderID { get; set; }

        // Which product
        public long ProductID { get; set; }

        // How many units
        public int Quantity { get; set; }

        // (Optional) Price per unit at time of purchase
        public decimal UnitPrice { get; set; }

        // Parameterless ctor required by sqlite-net
        public OrderItem() { }

        // Convenience ctor
        public OrderItem(long orderId, long productId, int quantity, decimal unitPrice)
        {
            OrderID = orderId;
            ProductID = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}
