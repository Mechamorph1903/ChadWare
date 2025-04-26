using System;
using Microsoft.Maui;
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
        private CartController _cartController;

        public CartPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (_cartController == null)
            {
                // Grab the IDataService from App.Services
                var ds = App.Services.GetRequiredService<IDataService>();
                _cartController = new CartController(ds);
            }

            var items = await _cartController.GetCartAsync(1);
            CartCollectionView.ItemsSource = items;
        }


        private async void OnRemoveClicked(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.CommandParameter is CartItem item)
            {
                await _cartController.RemoveFromCartAsync(1, item.CartItemID);
                CartCollectionView.ItemsSource = await _cartController.GetCartAsync(1);
            }
        }

        private async void OnCheckoutClicked(object sender, EventArgs e)
        {
            await _cartController.NavigateToCheckoutAsync(this, 1);
        }

        private async void OnMenTapped(object sender, EventArgs e)
            => await Navigation.PushAsync(new Views.Pages.MenProductPage());

        private async void OnWomenTapped(object sender, EventArgs e)
            => await Navigation.PushAsync(new Views.Pages.ProductPage());

        private async void OnUserIconClicked(object sender, EventArgs e)
            => await DisplayAlert("Coming Soon", "User profile or login screen will be here!", "OK");
    }
}
