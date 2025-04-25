using System.Collections.ObjectModel;
using ChadWare.Models;

namespace ChadWare.Views.Pages
{
    public partial class ItemsPage : ContentPage
    {
        public ObservableCollection<Product> Products { get; set; }

        public ItemsPage()
        {
            InitializeComponent();

            Products = new ObservableCollection<Product>
            {
                new Product { Name = "Cargo Jeans", Price = 129.00m, Image = "menapparel1.jpg" },
                new Product { Name = "Black Jeans", Price = 99.00m, Image = "menapparel2.jpg" },
                new Product { Name = "Coat", Price = 899.00m, Image = "menapparel3.jpg" },
                new Product { Name = "Hoodie Set", Price = 199.00m, Image = "menapparel4.jpg" },
                new Product { Name = "Beach Wear", Price = 60.00m, Image = "menapparel5.jpg" },
                new Product { Name = "T-Shirt set", Price = 599.00m, Image = "menapparel6.jpg" },
                new Product { Name = "Black Shirt", Price = 99.00m, Image = "menapparel7.jpg" },
                new Product { Name = "Funky Jeans", Price = 1599.00m, Image = "menapparel8.jpg" },
            };

            BindingContext = this;
        }

        private async void OnMenTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenProductPage());
        }

        private async void OnCartClicked(object sender, EventArgs e)
        {
            // Navigate to Cart
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
