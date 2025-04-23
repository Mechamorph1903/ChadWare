using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postgrest.Attributes;

namespace ChadWare.Models
{
    [Table("OrderItems")]
    public class OrderItem
    {
        [PrimaryKey("id", false)]
        public long Id { get; set; }

        [Column("orderID")]
        public long OrderID { get; set; }

        [Column("productID")]
        public long ProductID { get; set; }

        [Column("quantity")]
        public long Quantity { get; set; }

        // Parameterless ctor for Supabase client
        public OrderItem() { }

        // (Optional) Convenience ctor
        public OrderItem(long id, long orderID, long productID, long quantity)
        {
            Id = id;
            OrderID = orderID;
            ProductID = productID;
            Quantity = quantity;
        }
    }
}