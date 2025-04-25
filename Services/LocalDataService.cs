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
        /// <summary>
        /// Seeds the Product table with sample data if it's empty.
        /// </summary>
        public async Task SeedProductsAsync()
        {
            var count = await _db.Table<Product>().CountAsync();
            if (count == 0)
            {
                var seedData = new List<Product>
                {
                   // new Product { Name = "Black Dress", Description = "Elegant evening wear", Price = 299m, Image = "black_dress.png", Stock = 5, InStock = true, Category = "Apparel" },
                   // new Product { Name = "White Pants", Description = "Slim-fit chinos", Price = 199m, Image = "white_pants.png", Stock = 10, InStock = true, Category = "Apparel" },
                   // new Product { Name = "Grey Shirt", Description = "Casual unisex tee", Price = 199m, Image = "grey_shirt.png", Stock = 15, InStock = true, Category = "Apparel" }
                    // Add more seed products as needed
                };
                await _db.InsertAllAsync(seedData);
            }
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
