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
                    new Product { Name = "Men's Leather Jacket", Description = "Premium leather biker jacket", Price = 249.99m, Image = "menapparel1.png", Stock = 7, Category = "Men" },
                    new Product { Name = "Men's Sneakers", Description = "Comfortable everyday sneakers", Price = 89.99m, Image = "menapparel2.png", Stock = 20, Category = "Men" },
                    new Product { Name = "Men's Denim Jeans", Description = "Slim-fit blue jeans", Price = 74.99m, Image = "menapparel3.png", Stock = 15, Category = "Men" },
                    new Product { Name = "Men's Hoodie", Description = "Warm cotton hoodie", Price = 59.99m, Image = "menapparel4.png", Stock = 25, Category = "Men" },
                    new Product { Name = "Men's T-Shirt", Description = "Soft cotton tee", Price = 29.99m, Image = "menapparel5.png", Stock = 30, Category = "Men" },
                    new Product { Name = "Men's Shorts", Description = "Casual summer shorts", Price = 34.99m, Image = "menapparel6.png", Stock = 18, Category = "Men" },
                    new Product { Name = "Men's Watch", Description = "Stainless steel wristwatch", Price = 199.99m, Image = "menapparel7.png", Stock = 12, Category = "Men" },
                    new Product { Name = "Men's Sunglasses", Description = "UV-protected sunglasses", Price = 59.99m, Image = "menapparel8.png", Stock = 22, Category = "Men" },
                    new Product { Name = "Men's Belt", Description = "Leather dress belt", Price = 49.99m, Image = "menapparel9.png", Stock = 28, Category = "Men" },
                    new Product { Name = "Men's Boots", Description = "Classic leather boots", Price = 119.99m, Image = "menapparel10.png", Stock = 10, Category = "Men" },
                    new Product { Name = "Men's Hat", Description = "Stylish fedora hat", Price = 39.99m, Image = "menapparel11.png", Stock = 16, Category = "Men" },
                    new Product { Name = "Men's Socks", Description = "Pack of 5 cotton socks", Price = 19.99m, Image = "menapparel12.png", Stock = 40, Category = "Men" },

                    // Women (12 items)
                    new Product { Name = "Women's Blazer", Description = "Tailored office blazer", Price = 129.99m, Image = "womenapparel1.png", Stock = 10, Category = "Women" },
                    new Product { Name = "Women's Heels", Description = "Classic black stiletto heels", Price = 99.99m, Image = "womenapparel2.png", Stock = 12, Category = "Women" },
                    new Product { Name = "Women's Handbag", Description = "Leather tote handbag", Price = 149.99m, Image = "womenapparel3.png", Stock = 8, Category = "Women" },
                    new Product { Name = "Women's Dress", Description = "Floral summer dress", Price = 79.99m, Image = "womenapparel4.png", Stock = 14, Category = "Women" },
                    new Product { Name = "Women's Jeans", Description = "High-waist skinny jeans", Price = 69.99m, Image = "womenapparel5.png", Stock = 20, Category = "Women" },
                    new Product { Name = "Women's Top", Description = "Silk camisole top", Price = 49.99m, Image = "womenapparel6.png", Stock = 18, Category = "Women" },
                    new Product { Name = "Women's Skirt", Description = "Pleated midi skirt", Price = 59.99m, Image = "womenapparel7.png", Stock = 15, Category = "Women" },
                    new Product { Name = "Women's Necklace", Description = "Pearl pendant necklace", Price = 89.99m, Image = "womenapparel8.png", Stock = 13, Category = "Women" },
                    new Product { Name = "Women's Earrings", Description = "Hoop earrings", Price = 39.99m, Image = "womenapparel9.png", Stock = 25, Category = "Women" },
                    new Product { Name = "Women's Bracelet", Description = "Charm bracelet", Price = 59.99m, Image = "womenapparel10.png", Stock = 17, Category = "Women" },
                    new Product { Name = "Women's Scarf", Description = "Silk fashion scarf", Price = 29.99m, Image = "womenapparel11.png", Stock = 30, Category = "Women" },
                    new Product { Name = "Women's Sunglasses", Description = "Stylish cat-eye sunglasses", Price = 69.99m, Image = "womenapparel12.png", Stock = 22, Category = "Women" },

                    // Accessories (12 items)
                    new Product { Name = "Sunglasses", Description = "UV-protected aviator sunglasses", Price = 59.99m, Image = "menaccessory1.png", Stock = 25, Category = "Accessories" },
                    new Product { Name = "Leather Belt", Description = "Genuine leather belt", Price = 39.99m, Image = "menaccessory2.png", Stock = 30, Category = "Accessories" },
                    new Product { Name = "Baseball Cap", Description = "Adjustable cotton cap", Price = 24.99m, Image = "menaccessory3.png", Stock = 40, Category = "Accessories" },
                    new Product { Name = "Wallet", Description = "Leather bifold wallet", Price = 49.99m, Image = "menaccessory4.png", Stock = 28, Category = "Accessories" },
                    new Product { Name = "Watch", Description = "Digital sports watch", Price = 79.99m, Image = "menaccessory5.png", Stock = 20, Category = "Accessories" },
                    new Product { Name = "Phone Case", Description = "Protective silicone case", Price = 19.99m, Image = "menaccessory6.png", Stock = 50, Category = "Accessories" },
                    new Product { Name = "Umbrella", Description = "Compact travel umbrella", Price = 29.99m, Image = "menaccessory7.png", Stock = 15, Category = "Accessories" },
                    new Product { Name = "Keychain", Description = "Metal keychain fob", Price = 9.99m, Image = "menaccessory8.png", Stock = 60, Category = "Accessories" },
                    new Product { Name = "Gloves", Description = "Leather winter gloves", Price = 49.99m, Image = "menaccessory9.png", Stock = 18, Category = "Accessories" },
                    new Product { Name = "Backpack", Description = "Canvas daypack backpack", Price = 99.99m, Image = "menaccessory10.png", Stock = 12, Category = "Accessories" },
                    new Product { Name = "Tie", Description = "Silk neck tie", Price = 29.99m, Image = "menaccessory11.png", Stock = 25, Category = "Accessories" },
                    new Product { Name = "Socks", Description = "Pack of 5 dress socks", Price = 19.99m, Image = "menaccessory12.png", Stock = 40, Category = "Accessories" },
                    // Jewellery (12 items)
                    new Product { Name = "Gold Necklace", Description = "18k gold chain necklace", Price = 199.99m, Image = "womenjewellery1.png", Stock = 5, Category = "Jewellry" },
                    new Product { Name = "Silver Ring", Description = "Sterling silver ring", Price = 49.99m, Image = "womenjewellery2.png", Stock = 18, Category = "Jewellry" },
                    new Product { Name = "Diamond Earrings", Description = "Stud diamond earrings", Price = 299.99m, Image = "womenjewellery3.png", Stock = 4, Category = "Jewellry" },
                    new Product { Name = "Pearl Bracelet", Description = "Freshwater pearl bracelet", Price = 99.99m, Image = "womenjewellery4.png", Stock = 10, Category = "Jewellry" },
                    new Product { Name = "Gold Bracelet", Description = "14k gold bracelet", Price = 149.99m, Image = "womenjewellery5.png", Stock = 7, Category = "Jewellry" },
                    new Product { Name = "Silver Necklace", Description = "Sterling silver necklace", Price = 89.99m, Image = "womenjewellery6.png", Stock = 12, Category = "Jewellry" },
                    new Product { Name = "Diamond Ring", Description = "Solitaire diamond ring", Price = 399.99m, Image = "womenjewellery7.png", Stock = 3, Category = "Jewellry" },
                    new Product { Name = "Gold Earrings", Description = "Hoop gold earrings", Price = 129.99m, Image = "womenjewellery8.png", Stock = 8, Category = "Jewellry" },
                    new Product { Name = "Silver Earrings", Description = "Teardrop silver earrings", Price = 59.99m, Image = "womenjewellery9.png", Stock = 14, Category = "Jewellry" },
                    new Product { Name = "Diamond Bracelet", Description = "Tennis diamond bracelet", Price = 499.99m, Image = "womenjewellery10.png", Stock = 2, Category = "Jewellry" },
                    new Product { Name = "Platinum Ring", Description = "Platinum wedding band", Price = 299.99m, Image = "womenjewellery11.png", Stock = 6, Category = "Jewellry" },
                    new Product { Name = "Gold Watch", Description = "Luxury gold watch", Price = 999.99m, Image = "womenjewellery12.png", Stock = 4, Category = "Jewellry" },
                    // Women's Bags (12 items)
                    new Product { Name = "Women's Tote Bag", Description = "Spacious leather tote bag", Price = 149.99m, Image = "womenbag1.png", Stock = 10, Category = "Women Bags" },
                    new Product { Name = "Women's Crossbody Bag", Description = "Stylish crossbody bag", Price = 99.99m, Image = "womenbag2.png", Stock = 15, Category = "Women Bags" },
                    new Product { Name = "Women's Clutch", Description = "Elegant evening clutch", Price = 79.99m, Image = "womenbag3.png", Stock = 12, Category = "Women Bags" },
                    new Product { Name = "Women's Backpack", Description = "Casual leather backpack", Price = 129.99m, Image = "womenbag4.png", Stock = 8, Category = "Women Bags" },
                    new Product { Name = "Women's Satchel", Description = "Classic satchel bag", Price = 139.99m, Image = "womenbag5.png", Stock = 10, Category = "Women Bags" },
                    new Product { Name = "Women's Hobo Bag", Description = "Soft leather hobo bag", Price = 119.99m, Image = "womenbag6.png", Stock = 9, Category = "Women Bags" },
                    new Product { Name = "Women's Shoulder Bag", Description = "Chic shoulder bag", Price = 109.99m, Image = "womenbag7.png", Stock = 14, Category = "Women Bags" },
                    new Product { Name = "Women's Mini Bag", Description = "Compact mini bag", Price = 89.99m, Image = "womenbag8.png", Stock = 20, Category = "Women Bags" },
                    new Product { Name = "Women's Bucket Bag", Description = "Trendy bucket bag", Price = 99.99m, Image = "womenbag9.png", Stock = 11, Category = "Women Bags" },
                    new Product { Name = "Women's Laptop Bag", Description = "Professional laptop bag", Price = 159.99m, Image = "womenbag10.png", Stock = 7, Category = "Women Bags" },
                    new Product { Name = "Women's Messenger Bag", Description = "Casual messenger bag", Price = 119.99m, Image = "womenbag11.png", Stock = 13, Category = "Women Bags" },
                    new Product { Name = "Women's Travel Bag", Description = "Large travel bag", Price = 179.99m, Image = "womenbag12.png", Stock = 6, Category = "Women Bags" },

                    // Men's Bags (12 items)
                    new Product { Name = "Men's Messenger Bag", Description = "Classic leather messenger bag", Price = 149.99m, Image = "menbag1.png", Stock = 10, Category = "Men Bags" },
                    new Product { Name = "Men's Backpack", Description = "Durable canvas backpack", Price = 129.99m, Image = "menbag2.png", Stock = 12, Category = "Men Bags" },
                    new Product { Name = "Men's Briefcase", Description = "Professional leather briefcase", Price = 199.99m, Image = "menbag3.png", Stock = 8, Category = "Men Bags" },
                    new Product { Name = "Men's Duffle Bag", Description = "Spacious duffle bag", Price = 179.99m, Image = "menbag4.png", Stock = 9, Category = "Men Bags" },
                    new Product { Name = "Men's Crossbody Bag", Description = "Compact crossbody bag", Price = 99.99m, Image = "menbag5.png", Stock = 15, Category = "Men Bags" },
                    new Product { Name = "Men's Laptop Bag", Description = "Stylish laptop bag", Price = 159.99m, Image = "menbag6.png", Stock = 7, Category = "Men Bags" },
                    new Product { Name = "Men's Tote Bag", Description = "Casual tote bag", Price = 119.99m, Image = "menbag7.png", Stock = 11, Category = "Men Bags" },
                    new Product { Name = "Men's Gym Bag", Description = "Lightweight gym bag", Price = 89.99m, Image = "menbag8.png", Stock = 20, Category = "Men Bags" },
                    new Product { Name = "Men's Travel Bag", Description = "Large travel bag", Price = 199.99m, Image = "menbag9.png", Stock = 6, Category = "Men Bags" },
                    new Product { Name = "Men's Shoulder Bag", Description = "Stylish shoulder bag", Price = 109.99m, Image = "menbag10.png", Stock = 14, Category = "Men Bags" },
                    new Product { Name = "Men's Sling Bag", Description = "Compact sling bag", Price = 79.99m, Image = "menbag11.png", Stock = 18, Category = "Men Bags" },
                    new Product { Name = "Men's Belt Bag", Description = "Trendy belt bag", Price = 69.99m, Image = "menbag12.png", Stock = 16, Category = "Men Bags" },

                    // Men's Shoes (12 items)
                    new Product { Name = "Men's Running Shoes", Description = "Lightweight running shoes", Price = 99.99m, Image = "menshoe1.png", Stock = 20, Category = "Men Shoes" },
                    new Product { Name = "Men's Formal Shoes", Description = "Classic leather formal shoes", Price = 149.99m, Image = "menshoe2.png", Stock = 10, Category = "Men Shoes" },
                    new Product { Name = "Men's Sneakers", Description = "Casual everyday sneakers", Price = 89.99m, Image = "menshoe3.png", Stock = 25, Category = "Men Shoes" },
                    new Product { Name = "Men's Loafers", Description = "Comfortable leather loafers", Price = 129.99m, Image = "menshoe4.png", Stock = 12, Category = "Men Shoes" },
                    new Product { Name = "Men's Sandals", Description = "Durable summer sandals", Price = 49.99m, Image = "menshoe5.png", Stock = 18, Category = "Men Shoes" },
                    new Product { Name = "Men's Boots", Description = "Stylish leather boots", Price = 159.99m, Image = "menshoe6.png", Stock = 8, Category = "Men Shoes" },
                    new Product { Name = "Men's Slip-Ons", Description = "Easy-to-wear slip-ons", Price = 79.99m, Image = "menshoe7.png", Stock = 15, Category = "Men Shoes" },
                    new Product { Name = "Men's Hiking Shoes", Description = "Rugged hiking shoes", Price = 139.99m, Image = "menshoe8.png", Stock = 9, Category = "Men Shoes" },
                    new Product { Name = "Men's Dress Shoes", Description = "Elegant dress shoes", Price = 169.99m, Image = "menshoe9.png", Stock = 7, Category = "Men Shoes" },
                    new Product { Name = "Men's Moccasins", Description = "Comfortable moccasins", Price = 119.99m, Image = "menshoe10.png", Stock = 11, Category = "Men Shoes" },
                    new Product { Name = "Men's Oxfords", Description = "Classic oxford shoes", Price = 149.99m, Image = "menshoe11.png", Stock = 10, Category = "Men Shoes" },
                    new Product { Name = "Men's Trainers", Description = "Versatile trainers", Price = 99.99m, Image = "menshoe12.png", Stock = 20, Category = "Men Shoes" },

                    // Women's Shoes (12 items)
                    new Product { Name = "Women's Heels", Description = "Elegant stiletto heels", Price = 99.99m, Image = "womenshoe1.png", Stock = 12, Category = "Women Shoes" },
                    new Product { Name = "Women's Flats", Description = "Comfortable ballet flats", Price = 59.99m, Image = "womenshoe2.png", Stock = 18, Category = "Women Shoes" },
                    new Product { Name = "Women's Sandals", Description = "Stylish summer sandals", Price = 49.99m, Image = "womenshoe3.png", Stock = 20, Category = "Women Shoes" },
                    new Product { Name = "Women's Boots", Description = "Chic leather boots", Price = 139.99m, Image = "womenshoe4.png", Stock = 10, Category = "Women Shoes" },
                    new Product { Name = "Women's Sneakers", Description = "Casual everyday sneakers", Price = 89.99m, Image = "womenshoe5.png", Stock = 25, Category = "Women Shoes" },
                    new Product { Name = "Women's Wedges", Description = "Comfortable wedge heels", Price = 79.99m, Image = "womenshoe6.png", Stock = 15, Category = "Women Shoes" },
                    new Product { Name = "Women's Loafers", Description = "Stylish loafers", Price = 99.99m, Image = "womenshoe7.png", Stock = 12, Category = "Women Shoes" },
                    new Product { Name = "Women's Running Shoes", Description = "Lightweight running shoes", Price = 99.99m, Image = "womenshoe8.png", Stock = 20, Category = "Women Shoes" },
                    new Product { Name = "Women's Hiking Shoes", Description = "Durable hiking shoes", Price = 129.99m, Image = "womenshoe9.png", Stock = 8, Category = "Women Shoes" },
                    new Product { Name = "Women's Slip-Ons", Description = "Easy-to-wear slip-ons", Price = 69.99m, Image = "womenshoe10.png", Stock = 16, Category = "Women Shoes" },
                    new Product { Name = "Women's Espadrilles", Description = "Trendy espadrilles", Price = 79.99m, Image = "womenshoe11.png", Stock = 14, Category = "Women Shoes" },
                    new Product { Name = "Women's Dress Shoes", Description = "Elegant dress shoes", Price = 119.99m, Image = "womenshoe12.png", Stock = 11, Category = "Women Shoes" },

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
