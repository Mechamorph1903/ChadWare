using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChadWare.Models
{
    internal class Order
    {
        public int Id { get; set; }
        public User User { get; set; }
        public List<CartItem> CartItems { get; set; }
        public decimal TotalPrice => CartItems.Sum(item => item.TotalPrice);
        public Address ShippingAddress { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public Order(User user, List<CartItem> cartItems, Address address)
        {
            User = user;
            CartItems = cartItems;
            ShippingAddress = address;
            

           

        }
    }
}
