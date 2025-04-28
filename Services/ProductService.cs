using System.Collections.ObjectModel;
using ChadWare.Models;

namespace ChadWare.Services;

public class ProductService
{
    private static ProductService _instance;
    private List<Product> _allProducts;
    private ObservableCollection<Product> _searchResults;

    public static ProductService Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ProductService();
            }
            return _instance;
        }
    }

    private ProductService()
    {
        _allProducts = new List<Product>();
        _searchResults = new ObservableCollection<Product>();
        InitializeProducts();
    }

    public ObservableCollection<Product> SearchResults => _searchResults;

    private void InitializeProducts()
    {
        _allProducts.AddRange(new List<Product> {
                    // Men (12 items)
                    new Product { Name = "Men's Cargo Denim Jeans", Description = "Premium denim jeans", Price = 249.99m, Image = "menapparel1.jpg", Stock = 7, Category = "Men Apparel" },
                    new Product { Name = "Men's Hoodie set", Description = "Comfortable everyday hoodie", Price = 89.99m, Image = "menapparel2.jpg", Stock = 20, Category = "Men Apparel" },
                    new Product { Name = "Men's Khaki Coat", Description = "Slim-fit Coat", Price = 74.99m, Image = "menapparel3.jpg", Stock = 15, Category = "Men Apparel" },
                    new Product { Name = "Men's Hoodie Set", Description = "Warm cotton hoodie", Price = 59.99m, Image = "menapparel4.jpg", Stock = 25, Category = "Men Apparel" },
                    new Product { Name = "Men's T-Shirt", Description = "Soft cotton tee", Price = 29.99m, Image = "menapparel5.jpg", Stock = 30, Category = "Men Apparel" },
                    new Product { Name = "Men's Shorts", Description = "Casual summer shorts", Price = 34.99m, Image = "menapparel6.jpg", Stock = 18, Category = "Men Apparel" },
                    new Product { Name = "Men's Shirt", Description = "Black shirt", Price = 199.99m, Image = "menapparel7.jpg", Stock = 12, Category = "Men Apparel" },
                    new Product { Name = "Men's Leather Jacket", Description = "Stylish Leather Jacket", Price = 59.99m, Image = "menapparel8.jpg", Stock = 22, Category = "Men Apparel" },
                    new Product { Name = "Men's Casual wear set", Description = "Comfortable Casual wear", Price = 49.99m, Image = "menapparel9.jpg", Stock = 28, Category = "Men Apparel" },
                    new Product { Name = "Men's Blue Blazer", Description = "Classic blazer", Price = 119.99m, Image = "menapparel10.png", Stock = 10, Category = "Men Apparel" },
                    new Product { Name = "Men's Red Blazer set", Description = "Stylish Red Formal wear", Price = 399.99m, Image = "menapparel11.jpg", Stock = 16, Category = "Men Apparel" },
                    new Product { Name = "Men's Black Blazer set", Description = "Stylish Black Formal wear", Price = 199.99m, Image = "menapparel12.jpg", Stock = 40, Category = "Men Apparel" },

                    // Women (12 items)
                    new Product { Name = "Women's Blazer", Description = "Tailored office blazer", Price = 129.99m, Image = "womenapparel1.jpg", Stock = 10, Category = "Women Apparel" },
                    new Product { Name = "Women's Heels", Description = "Classic black stiletto heels", Price = 99.99m, Image = "womenapparel2.jpg", Stock = 12, Category = "Women Apparel" },
                    new Product { Name = "Women's Handbag", Description = "Leather tote handbag", Price = 149.99m, Image = "womenapparel3.jpg", Stock = 8, Category = "Women Apparel" },
                    new Product { Name = "Women's Dress", Description = "Floral summer dress", Price = 79.99m, Image = "womenapparel4.jpg", Stock = 14, Category = "Women Apparel" },
                    new Product { Name = "Women's Jeans", Description = "High-waist skinny jeans", Price = 69.99m, Image = "womenapparel5.jpg", Stock = 20, Category = "Women Apparel" },
                    new Product { Name = "Women's Top", Description = "Silk camisole top", Price = 49.99m, Image = "womenapparel6.jpg", Stock = 18, Category = "Women Apparel" },
                    new Product { Name = "Women's Skirt", Description = "Pleated midi skirt", Price = 59.99m, Image = "womenapparel7.jpg", Stock = 15, Category = "Women Apparel" },
                    new Product { Name = "Women's Necklace", Description = "Pearl pendant necklace", Price = 89.99m, Image = "womenapparel8.jpg", Stock = 13, Category = "Women Apparel" },
                    new Product { Name = "Women's Earrings", Description = "Hoop earrings", Price = 39.99m, Image = "womenapparel9.jpg", Stock = 25, Category = "Women Apparel" },
                    new Product { Name = "Women's Bracelet", Description = "Charm bracelet", Price = 59.99m, Image = "womenapparel10.jpg", Stock = 17, Category = "Women Apparel" },
                    new Product { Name = "Women's Scarf", Description = "Silk fashion scarf", Price = 29.99m, Image = "womenapparel11.jpg", Stock = 30, Category = "Women Apparel" },
                    new Product { Name = "Women's Sunglasses", Description = "Stylish cat-eye sunglasses", Price = 69.99m, Image = "womenapparel12.jpg", Stock = 22, Category = "Women Apparel" },

                    // Accessories (12 items)
                    new Product { Name = "Sunglasses", Description = "UV-protected aviator sunglasses", Price = 59.99m, Image = "menaccessory1.jpg", Stock = 25, Category = "Men Accessories" },
                    new Product { Name = "Leather Belt", Description = "Genuine leather belt", Price = 39.99m, Image = "menaccessory2.jpg", Stock = 30, Category = "Men Accessories" },
                    new Product { Name = "Baseball Cap", Description = "Adjustable cotton cap", Price = 24.99m, Image = "menaccessory3.jpg", Stock = 40, Category = "Men Accessories" },
                    new Product { Name = "Wallet", Description = "Leather bifold wallet", Price = 49.99m, Image = "menaccessory4.jpg", Stock = 28, Category = "Men Accessories" },
                    new Product { Name = "Watch", Description = "Digital sports watch", Price = 79.99m, Image = "menaccessory5.jpg", Stock = 20, Category = "Men Accessories" },
                    new Product { Name = "Phone Case", Description = "Protective silicone case", Price = 19.99m, Image = "menaccessory6.jpg", Stock = 50, Category = "Men Accessories" },
                    new Product { Name = "Umbrella", Description = "Compact travel umbrella", Price = 29.99m, Image = "menaccessory7.jpg", Stock = 15, Category = "Men Accessories" },
                    new Product { Name = "Keychain", Description = "Metal keychain fob", Price = 9.99m, Image = "menaccessory8.jpg", Stock = 60, Category = "Men Accessories" },
                    new Product { Name = "Gloves", Description = "Leather winter gloves", Price = 49.99m, Image = "menaccessory9.jpg", Stock = 18, Category = "Men Accessories" },
                    new Product { Name = "Backpack", Description = "Canvas daypack backpack", Price = 99.99m, Image = "menaccessory10.jpg", Stock = 12, Category = "Men Accessories" },
                    new Product { Name = "Tie", Description = "Silk neck tie", Price = 29.99m, Image = "menaccessory11.jpg", Stock = 25, Category = "Men Accessories" },
                    new Product { Name = "Socks", Description = "Pack of 5 dress socks", Price = 19.99m, Image = "menaccessory12.jpg", Stock = 40, Category = "Men Accessories" },
                    // Jewellery (12 items)
                    new Product { Name = "Gold Necklace", Description = "18k gold chain necklace", Price = 199.99m, Image = "womenjewellery1.jpg", Stock = 5, Category = "Women Jewellery" },
                    new Product { Name = "Silver Ring", Description = "Sterling silver ring", Price = 49.99m, Image = "womenjewellery2.jpg", Stock = 18, Category = "Women Jewellery" },
                    new Product { Name = "Diamond Earrings", Description = "Stud diamond earrings", Price = 299.99m, Image = "womenjewellery3.jpg", Stock = 4, Category = "Women Jewellery" },
                    new Product { Name = "Pearl Bracelet", Description = "Freshwater pearl bracelet", Price = 99.99m, Image = "womenjewellery4.jpg", Stock = 10, Category = "Women Jewellery" },
                    new Product { Name = "Gold Bracelet", Description = "14k gold bracelet", Price = 149.99m, Image = "womenjewellery5.jpg", Stock = 7, Category = "Women Jewellery" },
                    new Product { Name = "Silver Necklace", Description = "Sterling silver necklace", Price = 89.99m, Image = "womenjewellery6.jpg", Stock = 12, Category = "Women Jewellery" },
                    new Product { Name = "Diamond Ring", Description = "Solitaire diamond ring", Price = 399.99m, Image = "womenjewellery7.jpg", Stock = 3, Category = "Women Jewellery" },
                    new Product { Name = "Gold Earrings", Description = "Hoop gold earrings", Price = 129.99m, Image = "womenjewellery8.jpg", Stock = 8, Category = "Women Jewellery" },
                    new Product { Name = "Silver Earrings", Description = "Teardrop silver earrings", Price = 59.99m, Image = "womenjewellery9.jpg", Stock = 14, Category = "Women Jewellery" },
                    new Product { Name = "Diamond Bracelet", Description = "Tennis diamond bracelet", Price = 499.99m, Image = "womenjewellery10.jpg", Stock = 2, Category = "Women Jewellery" },
                    new Product { Name = "Platinum Ring", Description = "Platinum wedding band", Price = 299.99m, Image = "womenjewellery11.jpg", Stock = 6, Category = "Women Jewellery" },
                    new Product { Name = "Gold Watch", Description = "Luxury gold watch", Price = 999.99m, Image = "womenjewellery12.jpg", Stock = 4, Category = "Women Jewellery" },
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

                });
    }
    public Product GetProductById(long id)
    {
        return _allProducts.FirstOrDefault(p => p.ProductID == id);
    }

    /// <summary>
    /// Returns all products whose Category exactly matches the given category (case-insensitive).
    /// </summary>
    public List<Product> GetProductsByCategory(string category)
    {
        if (string.IsNullOrWhiteSpace(category))
            return new List<Product>(_allProducts);

        return _allProducts
            .Where(p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
    public void SearchProducts(string searchQuery, string category = null)
    {
        if (string.IsNullOrWhiteSpace(searchQuery))
        {
            _searchResults.Clear();
            return;
        }

        var query = searchQuery.ToLower();
        var filteredProducts = _allProducts.Where(p => 
            p.Name.ToLower().Contains(query) &&
            (category == null || p.Image.StartsWith(category.ToLower()))
        ).ToList();

        _searchResults.Clear();
        foreach (var product in filteredProducts)
        {
            _searchResults.Add(product);
        }
    }
} 