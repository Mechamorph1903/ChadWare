using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Supabase.Gotrue;

namespace ChadWare.Models
{
    [SQLite.Table("CartItem")]
    public class CartItem
    {
        [PrimaryKey, AutoIncrement]
        public long CartItemID { get; set; }
        public long ProductID { get; set; }
        public long UserID { get; set; }

        [Ignore]
        public Product? Product { get; set; }
        public string ProductName { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public string Size { get; set; } = string.Empty;
        public decimal LineTotal => Quantity * UnitPrice;

        public CartItem()
        {

        }
        public CartItem(long userId, long productId, string productName, int quantity, string size, decimal unitPrice)
        {
            UserID = userId;
            ProductID = productId;
            ProductName = productName;
            Quantity = quantity;
            Size = size;
            UnitPrice = unitPrice;
        }
        public void UpdateQuantity()
        {
            Quantity += 1;
        }
        public void UpdateQuantity(int newQuantity)
        {
            Quantity = newQuantity ;
        }
    }
}
