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
                    // Men (12 items)
                    new Product { Name = "Men's Leather Jacket", Description = "Premium leather biker jacket", Price = 249.99m, Image = "mens_leather_jacket.png", Stock = 7, Category = "Men" },
                    new Product { Name = "Men's Sneakers", Description = "Comfortable everyday sneakers", Price = 89.99m, Image = "mens_sneakers.png", Stock = 20, Category = "Men" },
                    new Product { Name = "Men's Denim Jeans", Description = "Slim-fit blue jeans", Price = 74.99m, Image = "mens_denim_jeans.png", Stock = 15, Category = "Men" },
                    new Product { Name = "Men's Hoodie", Description = "Warm cotton hoodie", Price = 59.99m, Image = "mens_hoodie.png", Stock = 25, Category = "Men" },
                    new Product { Name = "Men's T-Shirt", Description = "Soft cotton tee", Price = 29.99m, Image = "mens_tshirt.png", Stock = 30, Category = "Men" },
                    new Product { Name = "Men's Shorts", Description = "Casual summer shorts", Price = 34.99m, Image = "mens_shorts.png", Stock = 18, Category = "Men" },
                    new Product { Name = "Men's Watch", Description = "Stainless steel wristwatch", Price = 199.99m, Image = "mens_watch.png", Stock = 12, Category = "Men" },
                    new Product { Name = "Men's Sunglasses", Description = "UV-protected sunglasses", Price = 59.99m, Image = "mens_sunglasses.png", Stock = 22, Category = "Men" },
                    new Product { Name = "Men's Belt", Description = "Leather dress belt", Price = 49.99m, Image = "mens_belt.png", Stock = 28, Category = "Men" },
                    new Product { Name = "Men's Boots", Description = "Classic leather boots", Price = 119.99m, Image = "mens_boots.png", Stock = 10, Category = "Men" },
                    new Product { Name = "Men's Hat", Description = "Stylish fedora hat", Price = 39.99m, Image = "mens_hat.png", Stock = 16, Category = "Men" },
                    new Product { Name = "Men's Socks", Description = "Pack of 5 cotton socks", Price = 19.99m, Image = "mens_socks.png", Stock = 40, Category = "Men" },
                    // Women (12 items)
                    new Product { Name = "Women's Blazer", Description = "Tailored office blazer", Price = 129.99m, Image = "womens_blazer.png", Stock = 10, Category = "Women" },
                    new Product { Name = "Women's Heels", Description = "Classic black stiletto heels", Price = 99.99m, Image = "womens_heels.png", Stock = 12, Category = "Women" },
                    new Product { Name = "Women's Handbag", Description = "Leather tote handbag", Price = 149.99m, Image = "womens_handbag.png", Stock = 8, Category = "Women" },
                    new Product { Name = "Women's Dress", Description = "Floral summer dress", Price = 79.99m, Image = "womens_dress.png", Stock = 14, Category = "Women" },
                    new Product { Name = "Women's Jeans", Description = "High-waist skinny jeans", Price = 69.99m, Image = "womens_jeans.png", Stock = 20, Category = "Women" },
                    new Product { Name = "Women's Top", Description = "Silk camisole top", Price = 49.99m, Image = "womens_top.png", Stock = 18, Category = "Women" },
                    new Product { Name = "Women's Skirt", Description = "Pleated midi skirt", Price = 59.99m, Image = "womens_skirt.png", Stock = 15, Category = "Women" },
                    new Product { Name = "Women's Necklace", Description = "Pearl pendant necklace", Price = 89.99m, Image = "womens_necklace.png", Stock = 13, Category = "Women" },
                    new Product { Name = "Women's Earrings", Description = "Hoop earrings", Price = 39.99m, Image = "womens_earrings.png", Stock = 25, Category = "Women" },
                    new Product { Name = "Women's Bracelet", Description = "Charm bracelet", Price = 59.99m, Image = "womens_bracelet.png", Stock = 17, Category = "Women" },
                    new Product { Name = "Women's Scarf", Description = "Silk fashion scarf", Price = 29.99m, Image = "womens_scarf.png", Stock = 30, Category = "Women" },
                    new Product { Name = "Women's Sunglasses", Description = "Stylish cat-eye sunglasses", Price = 69.99m, Image = "womens_sunglasses.png", Stock = 22, Category = "Women" },
                    // Accessories (12 items)
                    new Product { Name = "Sunglasses", Description = "UV-protected aviator sunglasses", Price = 59.99m, Image = "sunglasses.png", Stock = 25, Category = "Accessories" },
                    new Product { Name = "Leather Belt", Description = "Genuine leather belt", Price = 39.99m, Image = "leather_belt.png", Stock = 30, Category = "Accessories" },
                    new Product { Name = "Baseball Cap", Description = "Adjustable cotton cap", Price = 24.99m, Image = "baseball_cap.png", Stock = 40, Category = "Accessories" },
                    new Product { Name = "Wallet", Description = "Leather bifold wallet", Price = 49.99m, Image = "wallet.png", Stock = 28, Category = "Accessories" },
                    new Product { Name = "Watch", Description = "Digital sports watch", Price = 79.99m, Image = "sports_watch.png", Stock = 20, Category = "Accessories" },
                    new Product { Name = "Phone Case", Description = "Protective silicone case", Price = 19.99m, Image = "phone_case.png", Stock = 50, Category = "Accessories" },
                    new Product { Name = "Umbrella", Description = "Compact travel umbrella", Price = 29.99m, Image = "umbrella.png", Stock = 15, Category = "Accessories" },
                    new Product { Name = "Keychain", Description = "Metal keychain fob", Price = 9.99m, Image = "keychain.png", Stock = 60, Category = "Accessories" },
                    new Product { Name = "Gloves", Description = "Leather winter gloves", Price = 49.99m, Image = "gloves.png", Stock = 18, Category = "Accessories" },
                    new Product { Name = "Backpack", Description = "Canvas daypack backpack", Price = 99.99m, Image = "backpack.png", Stock = 12, Category = "Accessories" },
                    new Product { Name = "Tie", Description = "Silk neck tie", Price = 29.99m, Image = "silk_tie.png", Stock = 25, Category = "Accessories" },
                    new Product { Name = "Socks", Description = "Pack of 5 dress socks", Price = 19.99m, Image = "dress_socks.png", Stock = 40, Category = "Accessories" },
                    // Jewellery (12 items)
                    new Product { Name = "Gold Necklace", Description = "18k gold chain necklace", Price = 199.99m, Image = "gold_necklace.png", Stock = 5, Category = "Jewellry" },
                    new Product { Name = "Silver Ring", Description = "Sterling silver ring", Price = 49.99m, Image = "silver_ring.png", Stock = 18, Category = "Jewellry" },
                    new Product { Name = "Diamond Earrings", Description = "Stud diamond earrings", Price = 299.99m, Image = "diamond_earrings.png", Stock = 4, Category = "Jewellry" },
                    new Product { Name = "Pearl Bracelet", Description = "Freshwater pearl bracelet", Price = 99.99m, Image = "pearl_bracelet.png", Stock = 10, Category = "Jewellry" },
                    new Product { Name = "Gold Bracelet", Description = "14k gold bracelet", Price = 149.99m, Image = "gold_bracelet.png", Stock = 7, Category = "Jewellry" },
                    new Product { Name = "Silver Necklace", Description = "Sterling silver necklace", Price = 89.99m, Image = "silver_necklace.png", Stock = 12, Category = "Jewellry" },
                    new Product { Name = "Diamond Ring", Description = "Solitaire diamond ring", Price = 399.99m, Image = "diamond_ring.png", Stock = 3, Category = "Jewellry" },
                    new Product { Name = "Gold Earrings", Description = "Hoop gold earrings", Price = 129.99m, Image = "gold_earrings.png", Stock = 8, Category = "Jewellry" },
                    new Product { Name = "Silver Earrings", Description = "Teardrop silver earrings", Price = 59.99m, Image = "silver_earrings.png", Stock = 14, Category = "Jewellry" },
                    new Product { Name = "Diamond Bracelet", Description = "Tennis diamond bracelet", Price = 499.99m, Image = "diamond_bracelet.png", Stock = 2, Category = "Jewellry" },
                    new Product { Name = "Platinum Ring", Description = "Platinum wedding band", Price = 299.99m, Image = "platinum_ring.png", Stock = 6, Category = "Jewellry" },
                    new Product { Name = "Gold Watch", Description = "Luxury gold watch", Price = 999.99m, Image = "gold_watch.png", Stock = 4, Category = "Jewellry" }
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
