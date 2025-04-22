using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChadWare.Models
{
    internal class CartItem
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => Product.Price * Quantity;
        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
        public void UpdateQuantity(int newQuantity)
        {
            Quantity = newQuantity;
        }
    }
}
