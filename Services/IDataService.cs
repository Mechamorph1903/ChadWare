using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChadWare.Services
{
    public interface IDataService
    {
        // --- Products ---
        Task<List<Product>> FetchProductsAsync();
        Task<Product> FetchProductByIdAsync(long id);

        // --- Cart ---
        Task<List<CartItem>> GetCartAsync(long userId);
        Task AddToCartAsync(long userId, CartItem item);
        Task RemoveFromCartAsync(long userId, long cartItemId);

        // --- Orders ---
        Task PlaceOrderAsync(Order order);

        // --- Users ---
        Task<User> AuthenticateAsync(string email, string password);
    }
}
