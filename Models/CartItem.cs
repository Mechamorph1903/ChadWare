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
    internal class CartItem
    {
        [PrimaryKey, AutoIncrement]
        public long CartItemID { get; set; }
        public long ProductID { get; set; }
        public long UserID { get; set; }

        [Ignore]
        public Product Product { get; set; }
       
        public int Quantity { get; set; }

        public string Size { get; set; }
        public decimal TotalPrice => Product.Price * Quantity;

        public CartItem()
        {

        }
        public CartItem(long userId, long productId, int quantity, string size)
        {
            UserID = userId;
            ProductID = productId;
            Quantity = quantity;
            Size = size;
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
