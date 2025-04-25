using System.Linq;
using Microsoft.Maui.Controls;
using ChadWare.Controllers;
using ChadWare.Models;
using ChadWare.Services;
using static System.Net.Mime.MediaTypeNames;
using System;

namespace ChadWare.Views.Pages
{
    public partial class CartPage : ContentPage
    {
        private readonly CartController _cartController;
        private long _currentUserId;

        public CartPage()
        {
            InitializeComponent();
            var dataService = Application.Current.Services.GetService<IDataService>();
            _cartController = new CartController(dataService);
            //for current user's cart
            _currentUserId = ((App)Application.Current).CurrentUser.UserID;

            // wire up selection or remove button
            CartCollectionView.SelectionChanged += OnItemSelected;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            // fetch cart items
            var items = await _cartController.GetCartAsync(_currentUserId);
            CartCollectionView.ItemsSource = items;
        }

        private async void OnRemoveClicked(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.CommandParameter is CartItem item)
            {
                await _cartController.RemoveFromCartAsync(_currentUserId, item.CartItemID);
                // refresh
                CartCollectionView.ItemsSource = await _cartController.GetCartAsync(_currentUserId);
            }
        }

        private async void OnCheckoutClicked(object sender, EventArgs e)
        {
            // navigate to checkout, passing cart items
            await _cartController.NavigateToCheckoutAsync(this, _currentUserId);
        }
    }
}