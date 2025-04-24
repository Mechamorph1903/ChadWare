using System.Collections.Generic;
using System.Threading.Tasks;
using ChadWare.Models;

namespace ChadWare.Services
{
    public interface IDataService
    {
        // ─── Products ─────────────────────────────────────────

        /// <summary>
        /// Fetch all products from the store.
        /// </summary>
        Task<List<Product>> FetchProductsAsync();

        /// <summary>
        /// Fetch a single product by its ID.
        /// </summary>
        Task<Product> FetchProductByIdAsync(long id);


        // ─── Cart ───────────────────────────────────────────────

        /// <summary>
        /// Get the current cart items for a given user.
        /// </summary>
        Task<List<CartItem>> GetCartAsync(long userId);

        /// <summary>
        /// Add one item to the user’s cart.
        /// </summary>
        Task AddToCartAsync(long userId, CartItem item);

        /// <summary>
        /// Remove one item from the user’s cart.
        /// </summary>
        Task RemoveFromCartAsync(long userId, long cartItemId);


        // ─── Orders ────────────────────────────────────────────

        /// <summary>
        /// Place an order (inserts the Order, its Address, and its OrderItems).
        /// </summary>
        Task PlaceOrderAsync(Order order);


        // ─── Users ─────────────────────────────────────────────

        /// <summary>
        /// Authenticate with email/password and return the matching User (or null).
        /// </summary>
        Task<User> AuthenticateAsync(string email, string password);
    }
}
