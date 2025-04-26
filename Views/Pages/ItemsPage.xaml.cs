using System.Collections.ObjectModel;
using ChadWare.Models;

namespace ChadWare.Views.Pages
{
    public partial class ItemsPage : ContentPage
    {
        public ObservableCollection<Product> Products { get; set; }
        private string _category;
        public string CategoryTitle { get; private set; }
        public string CategoryPath { get; private set; }

        public ItemsPage(string category = "Men")
        {
            InitializeComponent();
            _category = category;
            SetCategoryInfo();
            LoadProducts();
            BindingContext = this;
        }

        private void SetCategoryInfo()
        {
            switch (_category)
            {
                case "Men":
                    CategoryTitle = "Men's Clothing";
                    CategoryPath = "Home/Men's Clothing";
                    break;
                case "Men Bags":
                    CategoryTitle = "Men's Bags";
                    CategoryPath = "Home/Men's Bags";
                    break;
                case "Men Shoes":
                    CategoryTitle = "Men's Shoes";
                    CategoryPath = "Home/Men's Shoes";
                    break;
                case "Accessories":
                    CategoryTitle = "Men's Accessories";
                    CategoryPath = "Home/Men's Accessories";
                    break;
                case "Women Apparel":
                    CategoryTitle = "Women's Clothing";
                    CategoryPath = "Home/Women's Clothing";
                    break;
                case "Women Bags":
                    CategoryTitle = "Women's Bags";
                    CategoryPath = "Home/Women's Bags";
                    break;
                case "Women Shoes":
                    CategoryTitle = "Women's Shoes";
                    CategoryPath = "Home/Women's Shoes";
                    break;
                case "Women Jewelry":
                    CategoryTitle = "Women's Jewelry";
                    CategoryPath = "Home/Women's Jewelry";
                    break;
            }
        }

        private void LoadProducts()
        {
            Products = new ObservableCollection<Product>();

            switch (_category)
            {
                case "Men":
                    Products.Add(new Product { Name = "Cargo Jeans", Price = 129.00m, Image = "menapparel1.jpg" });
                    Products.Add(new Product { Name = "Black Jeans", Price = 99.00m, Image = "menapparel2.jpg" });
                    Products.Add(new Product { Name = "Coat", Price = 899.00m, Image = "menapparel3.jpg" });
                    Products.Add(new Product { Name = "Hoodie Set", Price = 199.00m, Image = "menapparel4.jpg" });
                    Products.Add(new Product { Name = "Beach Wear", Price = 60.00m, Image = "menapparel5.jpg" });
                    Products.Add(new Product { Name = "T-Shirt set", Price = 599.00m, Image = "menapparel6.jpg" });
                    Products.Add(new Product { Name = "Black Shirt", Price = 99.00m, Image = "menapparel7.jpg" });
                    Products.Add(new Product { Name = "Funky Jeans", Price = 1599.00m, Image = "menapparel8.jpg" });
                    Products.Add(new Product { Name = "Casual Jacket", Price = 149.00m, Image = "menapparel9.jpg" });
                    Products.Add(new Product { Name = "Winter Coat", Price = 299.00m, Image = "menapparel10.png" });
                    Products.Add(new Product { Name = "Formal Suit", Price = 799.00m, Image = "menapparel11.jpg" });
                    Products.Add(new Product { Name = "Leather Jacket", Price = 399.00m, Image = "menapparel12.jpg" });
                    break;

                case "Men Bags":
                    Products.Add(new Product { Name = "Men's Messenger Bag", Price = 149.99m, Image = "menbag1.jpg" });
                    Products.Add(new Product { Name = "Men's Backpack", Price = 129.99m, Image = "menbag2.jpg" });
                    Products.Add(new Product { Name = "Men's Briefcase", Price = 199.99m, Image = "menbag3.jpg" });
                    Products.Add(new Product { Name = "Men's Duffle Bag", Price = 179.99m, Image = "menbag4.jpg" });
                    Products.Add(new Product { Name = "Men's Crossbody Bag", Price = 99.99m, Image = "menbag5.jpg" });
                    Products.Add(new Product { Name = "Men's Laptop Bag", Price = 159.99m, Image = "menbag6.jpg" });
                    Products.Add(new Product { Name = "Men's Travel Bag", Price = 189.99m, Image = "menbag7.jpg" });
                    Products.Add(new Product { Name = "Men's Gym Bag", Price = 89.99m, Image = "menbag8.jpg" });
                    Products.Add(new Product { Name = "Men's Weekend Bag", Price = 139.99m, Image = "menbag9.jpg" });
                    Products.Add(new Product { Name = "Men's Sports Bag", Price = 119.99m, Image = "menbag10.jpg" });
                    Products.Add(new Product { Name = "Men's Business Bag", Price = 169.99m, Image = "menbag11.jpg" });
                    Products.Add(new Product { Name = "Men's Casual Bag", Price = 109.99m, Image = "menbag12.jpg" });
                    break;

                case "Men Shoes":
                    Products.Add(new Product { Name = "Men's Running Shoes", Price = 99.99m, Image = "menshoe1.jpg" });
                    Products.Add(new Product { Name = "Men's Formal Shoes", Price = 149.99m, Image = "menshoe2.jpg" });
                    Products.Add(new Product { Name = "Men's Sneakers", Price = 89.99m, Image = "menshoe3.jpg" });
                    Products.Add(new Product { Name = "Men's Loafers", Price = 129.99m, Image = "menshoe4.jpg" });
                    Products.Add(new Product { Name = "Men's Sandals", Price = 49.99m, Image = "menshoe5.jpg" });
                    Products.Add(new Product { Name = "Men's Boots", Price = 159.99m, Image = "menshoe6.jpg" });
                    Products.Add(new Product { Name = "Men's Casual Shoes", Price = 79.99m, Image = "menshoe7.jpg" });
                    Products.Add(new Product { Name = "Men's Sports Shoes", Price = 119.99m, Image = "menshoe8.jpg" });
                    Products.Add(new Product { Name = "Men's Walking Shoes", Price = 89.99m, Image = "menshoe9.jpg" });
                    Products.Add(new Product { Name = "Men's Hiking Boots", Price = 179.99m, Image = "menshoe10.jpg" });
                    Products.Add(new Product { Name = "Men's Dress Shoes", Price = 139.99m, Image = "menshoe11.jpg" });
                    Products.Add(new Product { Name = "Men's Athletic Shoes", Price = 129.99m, Image = "menshoe12.jpg" });
                    break;

                case "Accessories":
                    Products.Add(new Product { Name = "Sunglasses", Price = 59.99m, Image = "menaccessory1.jpg" });
                    Products.Add(new Product { Name = "Leather Belt", Price = 39.99m, Image = "menaccessory2.jpg" });
                    Products.Add(new Product { Name = "Baseball Cap", Price = 24.99m, Image = "menaccessory3.jpg" });
                    Products.Add(new Product { Name = "Wallet", Price = 49.99m, Image = "menaccessory4.jpg" });
                    Products.Add(new Product { Name = "Watch", Price = 79.99m, Image = "menaccessory5.jpg" });
                    Products.Add(new Product { Name = "Phone Case", Price = 19.99m, Image = "menaccessory6.jpg" });
                    Products.Add(new Product { Name = "Leather Gloves", Price = 45.99m, Image = "menaccessory7.jpg" });
                    Products.Add(new Product { Name = "Scarf", Price = 29.99m, Image = "menaccessory8.jpg" });
                    Products.Add(new Product { Name = "Tie Set", Price = 49.99m, Image = "menaccessory9.jpg" });
                    break;

                case "Women Apparel":
                    Products.Add(new Product { Name = "Summer Dress", Price = 89.99m, Image = "womenapparel1.jpg" });
                    Products.Add(new Product { Name = "Blazer Set", Price = 129.99m, Image = "womenapparel2.jpg" });
                    Products.Add(new Product { Name = "Casual Jeans", Price = 79.99m, Image = "womenapparel3.jpg" });
                    Products.Add(new Product { Name = "Evening Gown", Price = 299.99m, Image = "womenapparel4.jpg" });
                    Products.Add(new Product { Name = "Business Suit", Price = 199.99m, Image = "womenapparel5.jpg" });
                    Products.Add(new Product { Name = "Casual Top", Price = 49.99m, Image = "womenapparel6.jpg" });
                    Products.Add(new Product { Name = "Party Dress", Price = 159.99m, Image = "womenapparel7.jpg" });
                    Products.Add(new Product { Name = "Winter Coat", Price = 189.99m, Image = "womenapparel8.jpg" });
                    Products.Add(new Product { Name = "Casual Dress", Price = 69.99m, Image = "womenapparel9.jpg" });
                    Products.Add(new Product { Name = "Formal Suit", Price = 249.99m, Image = "womenapparel10.jpg" });
                    Products.Add(new Product { Name = "Evening Dress", Price = 279.99m, Image = "womenapparel11.jpg" });
                    Products.Add(new Product { Name = "Casual Set", Price = 89.99m, Image = "womenapparel12.jpg" });
                    break;

                case "Women Bags":
                    Products.Add(new Product { Name = "Designer Handbag", Price = 199.99m, Image = "womenbag1.jpg" });
                    Products.Add(new Product { Name = "Tote Bag", Price = 89.99m, Image = "womenbag2.jpg" });
                    Products.Add(new Product { Name = "Clutch", Price = 69.99m, Image = "womenbag3.jpg" });
                    Products.Add(new Product { Name = "Shoulder Bag", Price = 119.99m, Image = "womenbag4.jpg" });
                    Products.Add(new Product { Name = "Crossbody Bag", Price = 79.99m, Image = "womenbag5.jpg" });
                    Products.Add(new Product { Name = "Travel Bag", Price = 149.99m, Image = "womenbag6.jpg" });
                    Products.Add(new Product { Name = "Evening Bag", Price = 129.99m, Image = "womenbag7.jpg" });
                    Products.Add(new Product { Name = "Weekend Bag", Price = 139.99m, Image = "womenbag8.jpg" });
                    Products.Add(new Product { Name = "Business Bag", Price = 169.99m, Image = "womenbag9.jpg" });
                    Products.Add(new Product { Name = "Beach Bag", Price = 59.99m, Image = "womenbag10.jpg" });
                    Products.Add(new Product { Name = "Laptop Bag", Price = 159.99m, Image = "womenbag11.jpg" });
                    Products.Add(new Product { Name = "Casual Bag", Price = 99.99m, Image = "womenbag12.jpg" });
                    break;

                case "Women Shoes":
                    Products.Add(new Product { Name = "High Heels", Price = 129.99m, Image = "womenshoe1.jpg" });
                    Products.Add(new Product { Name = "Ankle Boots", Price = 159.99m, Image = "womenshoe2.jpg" });
                    Products.Add(new Product { Name = "Sneakers", Price = 89.99m, Image = "womenshoe3.jpg" });
                    Products.Add(new Product { Name = "Sandals", Price = 59.99m, Image = "womenshoe4.jpg" });
                    Products.Add(new Product { Name = "Flats", Price = 79.99m, Image = "womenshoe5.jpg" });
                    Products.Add(new Product { Name = "Wedges", Price = 99.99m, Image = "womenshoe6.jpg" });
                    Products.Add(new Product { Name = "Pumps", Price = 119.99m, Image = "womenshoe7.jpg" });
                    Products.Add(new Product { Name = "Booties", Price = 139.99m, Image = "womenshoe8.jpg" });
                    Products.Add(new Product { Name = "Casual Shoes", Price = 89.99m, Image = "womenshoe9.jpg" });
                    Products.Add(new Product { Name = "Formal Shoes", Price = 149.99m, Image = "womenshoe10.jpg" });
                    Products.Add(new Product { Name = "Party Shoes", Price = 169.99m, Image = "womenshoe11.jpg" });
                    Products.Add(new Product { Name = "Athletic Shoes", Price = 129.99m, Image = "womenshoe12.jpg" });
                    break;

                case "Women Jewelry":
                    Products.Add(new Product { Name = "Diamond Necklace", Price = 299.99m, Image = "womenjewellery1.jpg" });
                    Products.Add(new Product { Name = "Pearl Earrings", Price = 89.99m, Image = "womenjewellery2.jpg" });
                    Products.Add(new Product { Name = "Gold Bracelet", Price = 199.99m, Image = "womenjewellery3.jpg" });
                    Products.Add(new Product { Name = "Silver Ring", Price = 69.99m, Image = "womenjewellery4.jpg" });
                    Products.Add(new Product { Name = "Crystal Pendant", Price = 79.99m, Image = "womenjewellery5.jpg" });
                    Products.Add(new Product { Name = "Fashion Watch", Price = 149.99m, Image = "womenjewellery6.jpg" });
                    Products.Add(new Product { Name = "Diamond Ring", Price = 399.99m, Image = "womenjewellery7.jpg" });
                    Products.Add(new Product { Name = "Gold Necklace", Price = 249.99m, Image = "womenjewellery8.jpg" });
                    Products.Add(new Product { Name = "Pearl Bracelet", Price = 119.99m, Image = "womenjewellery9.jpg" });
                    Products.Add(new Product { Name = "Silver Earrings", Price = 59.99m, Image = "womenjewellery10.jpg" });
                    Products.Add(new Product { Name = "Crystal Necklace", Price = 89.99m, Image = "womenjewellery11.jpg" });
                    Products.Add(new Product { Name = "Gold Watch", Price = 279.99m, Image = "womenjewellery12.jpg" });
                    break;
            }
        }

        private async void OnMenTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenProductPage());
        }

        private async void OnCartClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Pages.CartPage());
        }

        private async void OnHomeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Pages.HomePage());
        }

        private async void OnWomenTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductPage());
        }

        private async void OnUserIconClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Coming Soon", "User profile or login screen will be here!", "OK");
        }

        private void OnAddToCartClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var product = button?.CommandParameter as Product;
            if (product != null)
            {
                DisplayAlert("Cart", $"{product.Name} added to cart!", "OK");
            }
        }
    }
}
