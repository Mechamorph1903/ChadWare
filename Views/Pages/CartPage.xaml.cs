using System;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using ChadWare.Controllers;
using ChadWare.Models;
using ChadWare.Services;

namespace ChadWare.Views.Pages
{
    public partial class CartPage : ContentPage
    {
        private readonly CartController _cartController;
        private readonly ObservableCollection<CartItem> _cartItems;
        private const long DummyUserId = 1;

        public CartPage()
        {
            InitializeComponent();

            // Resolve controller via DI
            var ds = App.Services.GetRequiredService<IDataService>();
            _cartController = new CartController(ds);

            // Prepare collection
            _cartItems = new ObservableCollection<CartItem>();
            CartCollectionView.ItemsSource = _cartItems;
        }
        private void UpdateTotal()
        {
            var total = _cartItems.Sum(item => item.Quantity * item.UnitPrice);
            TotalLabel.Text = total.ToString("C");
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var ds = App.Services.GetRequiredService<IDataService>();

            // 1. Fetch cart items
            var cartItems = await _cartController.GetCartAsync(DummyUserId)
                           ?? new List<CartItem>();

            // 2. For each cart item, load the real Product by ID
            foreach (var item in cartItems)
            {
                item.Product = ProductService.Instance.GetProductById(item.ProductID);
            }

            // 3. Update the CollectionView
            _cartItems.Clear();
            foreach (var item in cartItems)
                _cartItems.Add(item);

            // 4. Update total
            UpdateTotal();
        }


        private async void OnRemoveClicked(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.CommandParameter is CartItem item)
            {
                await _cartController.RemoveFromCartAsync(DummyUserId, item.CartItemID);

                // Remove from ObservableCollection if you have one
                _cartItems.Remove(item);

                // Update total
                TotalLabel.Text = _cartItems.Sum(i => i.Product?.Price ?? 0).ToString("C");
            }
        }


        private async void OnCheckoutClicked(object sender, EventArgs e)
            => await _cartController.NavigateToCheckoutAsync(this, DummyUserId);


        private async void OnUserIconClicked(object sender, EventArgs e)
        {
            // After we have profile page
            // await Navigation.PushAsync(new ProfilePage());

            // For now
            await DisplayAlert("Coming Soon", "User profile or login screen will be here!", "OK");
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

        private async void OnMenTapped(object sender, EventArgs e)
        {
            // Navigate or show men's section
            await Navigation.PushAsync(new Views.Pages.MenProductPage());
        }

        private async void OnWomenTapped(object sender, EventArgs e)
        {
            // Navigate or show women's section
            await Navigation.PushAsync(new Views.Pages.ProductPage());
        }

    }



}