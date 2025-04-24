using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ChadWare.Models;
using SQLite;
using Microsoft.Maui.Storage;

namespace ChadWare.Services
{
    public class LocalDataService : IDataService
    {
        private readonly SQLiteAsyncConnection _db;

        public LocalDataService()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "store.db3");
            _db = new SQLiteAsyncConnection(dbPath);

            // Create tables for each model
            _db.CreateTableAsync<User>().Wait();
            _db.CreateTableAsync<Product>().Wait();
            _db.CreateTableAsync<CartItem>().Wait();
            _db.CreateTableAsync<Order>().Wait();
            _db.CreateTableAsync<OrderItem>().Wait();
            _db.CreateTableAsync<Address>().Wait();
        }

        // Products
        public Task<List<Product>> FetchProductsAsync()
            => _db.Table<Product>().ToListAsync();

        public Task<Product> FetchProductByIdAsync(long id)
            => _db.Table<Product>()
                 .Where(p => p.ProductID == id)
                 .FirstOrDefaultAsync();

        // Cart
        public Task<List<CartItem>> GetCartAsync(long userId)
            => _db.Table<CartItem>()
                 .Where(ci => ci.UserID == userId)
                 .ToListAsync();

        public Task AddToCartAsync(long userId, CartItem item)
        {
            item.UserID = userId;
            return _db.InsertAsync(item);
        }

        public async Task RemoveFromCartAsync(long userId, long cartItemId)
        {
            var toRemove = await _db.Table<CartItem>()
                                   .Where(ci => ci.UserID == userId && ci.CartItemID == cartItemId)
                                   .FirstOrDefaultAsync();
            if (toRemove != null)
                await _db.DeleteAsync(toRemove);
        }

        // Orders
        public async Task PlaceOrderAsync(Order order)
        {
            // Insert order header
            await _db.InsertAsync(order);

            // Insert shipping address
            order.ShippingAddress.OrderID = order.OrderID;
            await _db.InsertAsync(order.ShippingAddress);

            // Insert each line item
            foreach (var it in order.Items)
            {
                it.OrderID = order.OrderID;
                await _db.InsertAsync(it);
            }
        }

        // Users
        public Task<User> AuthenticateAsync(string email, string password)
            => _db.Table<User>()
                 .Where(u => u.Email == email && u.Password == password)
                 .FirstOrDefaultAsync();
    }
}
