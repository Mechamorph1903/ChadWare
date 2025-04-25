using Microsoft.Maui;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.Maui.Controls;
using ChadWare.Controllers;
using ChadWare.Models;
using ChadWare.Services;
using System;

namespace ChadWare.Views.Pages
{
    public partial class CartPage : ContentPage
    {
        //private readonly CartController _cartController;
        //private long _currentUserId;

        public CartPage()
        {
            InitializeComponent();
            
            // 2) Resolve your IDataService
            //var dataService = this.Handler.MauiContext.Services
            //         .GetRequiredService<IDataService>();
            //_cartController = new CartController(dataService);
            // 4) Get the current user from your App subclass
            //var mauiApp = (App)Application.Current;
            //_currentUserId = mauiApp.CurrentUser.UserID;

            // wire up selection or remove button
            //CartCollectionView.SelectionChanged += OnItemSelected;
        }

        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();
        //    // fetch cart items
        //    //var items = await _cartController.GetCartAsync(_currentUserId);
        //    var items = await _cartController.GetCartAsync(1);
        //    CartCollectionView.ItemsSource = items;
        //}

        //private async void OnRemoveClicked(object sender, EventArgs e)
        //{
        //    if (sender is Button btn && btn.CommandParameter is CartItem item)
        //    {
        //        //await _cartController.RemoveFromCartAsync(_currentUserId, item.CartItemID);
        //        await _cartController.RemoveFromCartAsync(1, item.CartItemID);
        //        // refresh
        //        //CartCollectionView.ItemsSource = await _cartController.GetCartAsync(_currentUserId);
        //        CartCollectionView.ItemsSource = await _cartController.GetCartAsync(1);
        //    }
        //}

        //private async void OnCheckoutClicked(object sender, EventArgs e)
        //{
        //    // navigate to checkout, passing cart items
        //    //await _cartController.NavigateToCheckoutAsync(this, _currentUserId);
        //    await _cartController.NavigateToCheckoutAsync(this, 1);
        //}
    }
}