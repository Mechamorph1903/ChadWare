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
                new Product { Name = "Ring", Price = 1299.00m, Image = "menapparel1.jpg" },
                new Product { Name = "T-shirt", Price = 499.00m, Image = "menapparel2.jpg" },
                new Product { Name = "Sunglasses", Price = 899.00m, Image = "menapparel3.jpg" },
                new Product { Name = "Jeans", Price = 1599.00m, Image = "menapparel4.jpg" },
                new Product { Name = "Jeans", Price = 1599.00m, Image = "menapparel5.jpg" },
                new Product { Name = "Jeans", Price = 1599.00m, Image = "menapparel6.jpg" },
                new Product { Name = "Jeans", Price = 1599.00m, Image = "menapparel7.jpg" },
                new Product { Name = "Jeans", Price = 1599.00m, Image = "menapparel8.jpg" },
            };

            BindingContext = this;
        }

        private async void OnMenTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenProductPage());
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
