using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ChadWare.Models;
using SQLite;
using Microsoft.Maui.Storage;
using System;
using System.Linq;

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

            // Initialize demo user if none exists
            InitializeDemoUserAsync().Wait();
        }

        private async Task InitializeDemoUserAsync()
        {
            var userCount = await _db.Table<User>().CountAsync();
            if (userCount == 0)
            {
                var demoUser = new User
                {
                    FirstName = "Sarah",
                    LastName = "Smith",
                    Email = "SarahSmith45@gmail.com",
                    Password = "demo123", // In a real app, this should be hashed
                    PhoneNumber = "(123)-456-7890",
                    EmailNotifications = true,
                    SmsNotifications = false,
                    MailNotifications = true,
                    IsVerified = true
                };
                await _db.InsertAsync(demoUser);
            }
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
                    // Men (12 items)
                    new Product { Name = "Men's Leather Jacket", Description = "Premium leather biker jacket", Price = 249.99m, Image = "menapparel1.jpg", Stock = 7, Category = "Men" },
                    new Product { Name = "Men's Sneakers", Description = "Comfortable everyday sneakers", Price = 89.99m, Image = "menapparel2.jpg", Stock = 20, Category = "Men" },
                    new Product { Name = "Men's Denim Jeans", Description = "Slim-fit blue jeans", Price = 74.99m, Image = "menapparel3.jpg", Stock = 15, Category = "Men" },
                    new Product { Name = "Men's Hoodie", Description = "Warm cotton hoodie", Price = 59.99m, Image = "menapparel4.jpg", Stock = 25, Category = "Men" },
                    new Product { Name = "Men's T-Shirt", Description = "Soft cotton tee", Price = 29.99m, Image = "menapparel5.jpg", Stock = 30, Category = "Men" },
                    new Product { Name = "Men's Shorts", Description = "Casual summer shorts", Price = 34.99m, Image = "menapparel6.jpg", Stock = 18, Category = "Men" },
                    new Product { Name = "Men's Watch", Description = "Stainless steel wristwatch", Price = 199.99m, Image = "menapparel7.jpg", Stock = 12, Category = "Men" },
                    new Product { Name = "Men's Sunglasses", Description = "UV-protected sunglasses", Price = 59.99m, Image = "menapparel8.jpg", Stock = 22, Category = "Men" },
                    new Product { Name = "Men's Belt", Description = "Leather dress belt", Price = 49.99m, Image = "menapparel9.jpg", Stock = 28, Category = "Men" },
                    new Product { Name = "Men's Boots", Description = "Classic leather boots", Price = 119.99m, Image = "menapparel10.png", Stock = 10, Category = "Men" },
                    new Product { Name = "Men's Hat", Description = "Stylish fedora hat", Price = 39.99m, Image = "menapparel11.jpg", Stock = 16, Category = "Men" },
                    new Product { Name = "Men's Socks", Description = "Pack of 5 cotton socks", Price = 19.99m, Image = "menapparel12.jpg", Stock = 40, Category = "Men" },

                    // Women (12 items)
                    new Product { Name = "Women's Blazer", Description = "Tailored office blazer", Price = 129.99m, Image = "womenapparel1.jpg", Stock = 10, Category = "Women" },
                    new Product { Name = "Women's Heels", Description = "Classic black stiletto heels", Price = 99.99m, Image = "womenapparel2.jpg", Stock = 12, Category = "Women" },
                    new Product { Name = "Women's Handbag", Description = "Leather tote handbag", Price = 149.99m, Image = "womenapparel3.jpg", Stock = 8, Category = "Women" },
                    new Product { Name = "Women's Dress", Description = "Floral summer dress", Price = 79.99m, Image = "womenapparel4.jpg", Stock = 14, Category = "Women" },
                    new Product { Name = "Women's Jeans", Description = "High-waist skinny jeans", Price = 69.99m, Image = "womenapparel5.jpg", Stock = 20, Category = "Women" },
                    new Product { Name = "Women's Top", Description = "Silk camisole top", Price = 49.99m, Image = "womenapparel6.jpg", Stock = 18, Category = "Women" },
                    new Product { Name = "Women's Skirt", Description = "Pleated midi skirt", Price = 59.99m, Image = "womenapparel7.jpg", Stock = 15, Category = "Women" },
                    new Product { Name = "Women's Necklace", Description = "Pearl pendant necklace", Price = 89.99m, Image = "womenapparel8.jpg", Stock = 13, Category = "Women" },
                    new Product { Name = "Women's Earrings", Description = "Hoop earrings", Price = 39.99m, Image = "womenapparel9.jpg", Stock = 25, Category = "Women" },
                    new Product { Name = "Women's Bracelet", Description = "Charm bracelet", Price = 59.99m, Image = "womenapparel10.jpg", Stock = 17, Category = "Women" },
                    new Product { Name = "Women's Scarf", Description = "Silk fashion scarf", Price = 29.99m, Image = "womenapparel11.jpg", Stock = 30, Category = "Women" },
                    new Product { Name = "Women's Sunglasses", Description = "Stylish cat-eye sunglasses", Price = 69.99m, Image = "womenapparel12.jpg", Stock = 22, Category = "Women" },

                    // Accessories (12 items)
                    new Product { Name = "Sunglasses", Description = "UV-protected aviator sunglasses", Price = 59.99m, Image = "menaccessory1.jpg", Stock = 25, Category = "Accessories" },
                    new Product { Name = "Leather Belt", Description = "Genuine leather belt", Price = 39.99m, Image = "menaccessory2.jpg", Stock = 30, Category = "Accessories" },
                    new Product { Name = "Baseball Cap", Description = "Adjustable cotton cap", Price = 24.99m, Image = "menaccessory3.jpg", Stock = 40, Category = "Accessories" },
                    new Product { Name = "Wallet", Description = "Leather bifold wallet", Price = 49.99m, Image = "menaccessory4.jpg", Stock = 28, Category = "Accessories" },
                    new Product { Name = "Watch", Description = "Digital sports watch", Price = 79.99m, Image = "menaccessory5.jpg", Stock = 20, Category = "Accessories" },
                    new Product { Name = "Phone Case", Description = "Protective silicone case", Price = 19.99m, Image = "menaccessory6.jpg", Stock = 50, Category = "Accessories" },
                    new Product { Name = "Umbrella", Description = "Compact travel umbrella", Price = 29.99m, Image = "menaccessory7.jpg", Stock = 15, Category = "Accessories" },
                    new Product { Name = "Keychain", Description = "Metal keychain fob", Price = 9.99m, Image = "menaccessory8.jpg", Stock = 60, Category = "Accessories" },
                    new Product { Name = "Gloves", Description = "Leather winter gloves", Price = 49.99m, Image = "menaccessory9.jpg", Stock = 18, Category = "Accessories" },
                    new Product { Name = "Backpack", Description = "Canvas daypack backpack", Price = 99.99m, Image = "menaccessory10.jpg", Stock = 12, Category = "Accessories" },
                    new Product { Name = "Tie", Description = "Silk neck tie", Price = 29.99m, Image = "menaccessory11.jpg", Stock = 25, Category = "Accessories" },
                    new Product { Name = "Socks", Description = "Pack of 5 dress socks", Price = 19.99m, Image = "menaccessory12.jpg", Stock = 40, Category = "Accessories" },
                    // Jewellery (12 items)
                    new Product { Name = "Gold Necklace", Description = "18k gold chain necklace", Price = 199.99m, Image = "womenjewellery1.jpg", Stock = 5, Category = "Jewellry" },
                    new Product { Name = "Silver Ring", Description = "Sterling silver ring", Price = 49.99m, Image = "womenjewellery2.jpg", Stock = 18, Category = "Jewellry" },
                    new Product { Name = "Diamond Earrings", Description = "Stud diamond earrings", Price = 299.99m, Image = "womenjewellery3.jpg", Stock = 4, Category = "Jewellry" },
                    new Product { Name = "Pearl Bracelet", Description = "Freshwater pearl bracelet", Price = 99.99m, Image = "womenjewellery4.jpg", Stock = 10, Category = "Jewellry" },
                    new Product { Name = "Gold Bracelet", Description = "14k gold bracelet", Price = 149.99m, Image = "womenjewellery5.jpg", Stock = 7, Category = "Jewellry" },
                    new Product { Name = "Silver Necklace", Description = "Sterling silver necklace", Price = 89.99m, Image = "womenjewellery6.jpg", Stock = 12, Category = "Jewellry" },
                    new Product { Name = "Diamond Ring", Description = "Solitaire diamond ring", Price = 399.99m, Image = "womenjewellery7.jpg", Stock = 3, Category = "Jewellry" },
                    new Product { Name = "Gold Earrings", Description = "Hoop gold earrings", Price = 129.99m, Image = "womenjewellery8.jpg", Stock = 8, Category = "Jewellry" },
                    new Product { Name = "Silver Earrings", Description = "Teardrop silver earrings", Price = 59.99m, Image = "womenjewellery9.jpg", Stock = 14, Category = "Jewellry" },
                    new Product { Name = "Diamond Bracelet", Description = "Tennis diamond bracelet", Price = 499.99m, Image = "womenjewellery10.jpg", Stock = 2, Category = "Jewellry" },
                    new Product { Name = "Platinum Ring", Description = "Platinum wedding band", Price = 299.99m, Image = "womenjewellery11.jpg", Stock = 6, Category = "Jewellry" },
                    new Product { Name = "Gold Watch", Description = "Luxury gold watch", Price = 999.99m, Image = "womenjewellery12.jpg", Stock = 4, Category = "Jewellry" },
                    // Women's Bags (12 items)
                    new Product { Name = "Women's Tote Bag", Description = "Spacious leather tote bag", Price = 149.99m, Image = "womenbag1.jpg", Stock = 10, Category = "Women Bags" },
                    new Product { Name = "Women's Crossbody Bag", Description = "Stylish crossbody bag", Price = 99.99m, Image = "womenbag2.jpg", Stock = 15, Category = "Women Bags" },
                    new Product { Name = "Women's Clutch", Description = "Elegant evening clutch", Price = 79.99m, Image = "womenbag3.jpg", Stock = 12, Category = "Women Bags" },
                    new Product { Name = "Women's Backpack", Description = "Casual leather backpack", Price = 129.99m, Image = "womenbag4.jpg", Stock = 8, Category = "Women Bags" },
                    new Product { Name = "Women's Satchel", Description = "Classic satchel bag", Price = 139.99m, Image = "womenbag5.jpg", Stock = 10, Category = "Women Bags" },
                    new Product { Name = "Women's Hobo Bag", Description = "Soft leather hobo bag", Price = 119.99m, Image = "womenbag6.jpg", Stock = 9, Category = "Women Bags" },
                    new Product { Name = "Women's Shoulder Bag", Description = "Chic shoulder bag", Price = 109.99m, Image = "womenbag7.jpg", Stock = 14, Category = "Women Bags" },
                    new Product { Name = "Women's Mini Bag", Description = "Compact mini bag", Price = 89.99m, Image = "womenbag8.jpg", Stock = 20, Category = "Women Bags" },
                    new Product { Name = "Women's Bucket Bag", Description = "Trendy bucket bag", Price = 99.99m, Image = "womenbag9.jpg", Stock = 11, Category = "Women Bags" },
                    new Product { Name = "Women's Laptop Bag", Description = "Professional laptop bag", Price = 159.99m, Image = "womenbag10.jpg", Stock = 7, Category = "Women Bags" },
                    new Product { Name = "Women's Messenger Bag", Description = "Casual messenger bag", Price = 119.99m, Image = "womenbag11.jpg", Stock = 13, Category = "Women Bags" },
                    new Product { Name = "Women's Travel Bag", Description = "Large travel bag", Price = 179.99m, Image = "womenbag12.jpg", Stock = 6, Category = "Women Bags" },

                    // Men's Bags (12 items)
                    new Product { Name = "Men's Messenger Bag", Description = "Classic leather messenger bag", Price = 149.99m, Image = "menbag1.jpg", Stock = 10, Category = "Men Bags" },
                    new Product { Name = "Men's Backpack", Description = "Durable canvas backpack", Price = 129.99m, Image = "menbag2.jpg", Stock = 12, Category = "Men Bags" },
                    new Product { Name = "Men's Briefcase", Description = "Professional leather briefcase", Price = 199.99m, Image = "menbag3.jpg", Stock = 8, Category = "Men Bags" },
                    new Product { Name = "Men's Duffle Bag", Description = "Spacious duffle bag", Price = 179.99m, Image = "menbag4.jpg", Stock = 9, Category = "Men Bags" },
                    new Product { Name = "Men's Crossbody Bag", Description = "Compact crossbody bag", Price = 99.99m, Image = "menbag5.jpg", Stock = 15, Category = "Men Bags" },
                    new Product { Name = "Men's Laptop Bag", Description = "Stylish laptop bag", Price = 159.99m, Image = "menbag6.jpg", Stock = 7, Category = "Men Bags" },
                    new Product { Name = "Men's Tote Bag", Description = "Casual tote bag", Price = 119.99m, Image = "menbag7.jpg", Stock = 11, Category = "Men Bags" },
                    new Product { Name = "Men's Gym Bag", Description = "Lightweight gym bag", Price = 89.99m, Image = "menbag8.jpg", Stock = 20, Category = "Men Bags" },
                    new Product { Name = "Men's Travel Bag", Description = "Large travel bag", Price = 199.99m, Image = "menbag9.jpg", Stock = 6, Category = "Men Bags" },
                    new Product { Name = "Men's Shoulder Bag", Description = "Stylish shoulder bag", Price = 109.99m, Image = "menbag10.jpg", Stock = 14, Category = "Men Bags" },
                    new Product { Name = "Men's Sling Bag", Description = "Compact sling bag", Price = 79.99m, Image = "menbag11.jpg", Stock = 18, Category = "Men Bags" },
                    new Product { Name = "Men's Belt Bag", Description = "Trendy belt bag", Price = 69.99m, Image = "menbag12.jpg", Stock = 16, Category = "Men Bags" },

                    // Men's Shoes (12 items)
                    new Product { Name = "Men's Running Shoes", Description = "Lightweight running shoes", Price = 99.99m, Image = "menshoe1.jpg", Stock = 20, Category = "Men Shoes" },
                    new Product { Name = "Men's Formal Shoes", Description = "Classic leather formal shoes", Price = 149.99m, Image = "menshoe2.jpg", Stock = 10, Category = "Men Shoes" },
                    new Product { Name = "Men's Sneakers", Description = "Casual everyday sneakers", Price = 89.99m, Image = "menshoe3.jpg", Stock = 25, Category = "Men Shoes" },
                    new Product { Name = "Men's Loafers", Description = "Comfortable leather loafers", Price = 129.99m, Image = "menshoe4.jpg", Stock = 12, Category = "Men Shoes" },
                    new Product { Name = "Men's Sandals", Description = "Durable summer sandals", Price = 49.99m, Image = "menshoe5.jpg", Stock = 18, Category = "Men Shoes" },
                    new Product { Name = "Men's Boots", Description = "Stylish leather boots", Price = 159.99m, Image = "menshoe6.jpg", Stock = 8, Category = "Men Shoes" },
                    new Product { Name = "Men's Slip-Ons", Description = "Easy-to-wear slip-ons", Price = 79.99m, Image = "menshoe7.jpg", Stock = 15, Category = "Men Shoes" },
                    new Product { Name = "Men's Hiking Shoes", Description = "Rugged hiking shoes", Price = 139.99m, Image = "menshoe8.jpg", Stock = 9, Category = "Men Shoes" },
                    new Product { Name = "Men's Dress Shoes", Description = "Elegant dress shoes", Price = 169.99m, Image = "menshoe9.jpg", Stock = 7, Category = "Men Shoes" },
                    new Product { Name = "Men's Moccasins", Description = "Comfortable moccasins", Price = 119.99m, Image = "menshoe10.jpg", Stock = 11, Category = "Men Shoes" },
                    new Product { Name = "Men's Oxfords", Description = "Classic oxford shoes", Price = 149.99m, Image = "menshoe11.jpg", Stock = 10, Category = "Men Shoes" },
                    new Product { Name = "Men's Trainers", Description = "Versatile trainers", Price = 99.99m, Image = "menshoe12.jpg", Stock = 20, Category = "Men Shoes" },

                    // Women's Shoes (12 items)
                    new Product { Name = "Women's Heels", Description = "Elegant stiletto heels", Price = 99.99m, Image = "womenshoe1.jpg", Stock = 12, Category = "Women Shoes" },
                    new Product { Name = "Women's Flats", Description = "Comfortable ballet flats", Price = 59.99m, Image = "womenshoe2.jpg", Stock = 18, Category = "Women Shoes" },
                    new Product { Name = "Women's Sandals", Description = "Stylish summer sandals", Price = 49.99m, Image = "womenshoe3.jpg", Stock = 20, Category = "Women Shoes" },
                    new Product { Name = "Women's Boots", Description = "Chic leather boots", Price = 139.99m, Image = "womenshoe4.jpg", Stock = 10, Category = "Women Shoes" },
                    new Product { Name = "Women's Sneakers", Description = "Casual everyday sneakers", Price = 89.99m, Image = "womenshoe5.jpg", Stock = 25, Category = "Women Shoes" },
                    new Product { Name = "Women's Wedges", Description = "Comfortable wedge heels", Price = 79.99m, Image = "womenshoe6.jpg", Stock = 15, Category = "Women Shoes" },
                    new Product { Name = "Women's Loafers", Description = "Stylish loafers", Price = 99.99m, Image = "womenshoe7.jpg", Stock = 12, Category = "Women Shoes" },
                    new Product { Name = "Women's Running Shoes", Description = "Lightweight running shoes", Price = 99.99m, Image = "womenshoe8.jpg", Stock = 20, Category = "Women Shoes" },
                    new Product { Name = "Women's Hiking Shoes", Description = "Durable hiking shoes", Price = 129.99m, Image = "womenshoe9.jpg", Stock = 8, Category = "Women Shoes" },
                    new Product { Name = "Women's Slip-Ons", Description = "Easy-to-wear slip-ons", Price = 69.99m, Image = "womenshoe10.jpg", Stock = 16, Category = "Women Shoes" },
                    new Product { Name = "Women's Espadrilles", Description = "Trendy espadrilles", Price = 79.99m, Image = "womenshoe11.jpg", Stock = 14, Category = "Women Shoes" },
                    new Product { Name = "Women's Dress Shoes", Description = "Elegant dress shoes", Price = 119.99m, Image = "womenshoe12.jpg", Stock = 11, Category = "Women Shoes" },

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

        public Task<User?> GetUserAsync(string userId)
        {
            if (!long.TryParse(userId, out long userIdLong))
                return Task.FromResult<User?>(null);

            return _db.Table<User>()
                     .Where(u => u.UserID == userIdLong)
                     .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            try
            {
                var result = await _db.UpdateAsync(user);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            try
            {
                var result = await _db.InsertAsync(user);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            if (!long.TryParse(userId, out long userIdLong))
                return false;

            try
            {
                var user = await GetUserAsync(userId);
                if (user == null) return false;
                
                var result = await _db.DeleteAsync(user);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        public Task<User?> GetUserByEmailAsync(string email)
            => _db.Table<User>()
                 .Where(u => u.Email == email)
                 .FirstOrDefaultAsync();

        // Implement other interface methods
        public Task<List<Product>> GetProductsAsync() => FetchProductsAsync();
        public Task<Product?> GetProductAsync(string productId) 
        {
            if (!long.TryParse(productId, out long id))
                return Task.FromResult<Product?>(null);
            return FetchProductByIdAsync(id);
        }
        public Task<bool> UpdateProductAsync(Product product) => Task.FromResult(false);
        public Task<bool> CreateProductAsync(Product product) => Task.FromResult(false);
        public Task<bool> DeleteProductAsync(string productId) => Task.FromResult(false);
        public Task<List<Order>> GetOrdersForUserAsync(string userId) => Task.FromResult(new List<Order>());
        public Task<Order?> GetOrderAsync(string orderId) => Task.FromResult<Order?>(null);
        public Task<bool> CreateOrderAsync(Order order) => Task.FromResult(false);
        public Task<bool> UpdateOrderAsync(Order order) => Task.FromResult(false);
        public Task<List<CartItem>> GetCartItemsAsync(string userId) => Task.FromResult(new List<CartItem>());
        public Task<bool> AddToCartAsync(CartItem item) => Task.FromResult(false);
        public Task<bool> UpdateCartItemAsync(CartItem item) => Task.FromResult(false);
        public Task<bool> RemoveFromCartAsync(string userId, string productId) => Task.FromResult(false);
        public Task<bool> ClearCartAsync(string userId) => Task.FromResult(false);
    }
}
