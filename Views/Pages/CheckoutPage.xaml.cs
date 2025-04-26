using Microsoft.Maui;                       
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using ChadWare.Controllers;
using ChadWare.Models;
using ChadWare.Services;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ChadWare.Views.Pages
{
    public partial class CheckoutPage : ContentPage
    {
        private readonly OrderController _orderController;
        //private long _currentUserId;
        private IList<CartItem> _cartItems;

        public CheckoutPage(long userId, IList<CartItem> items)
        {
            InitializeComponent();

            var dataService = this.Handler.MauiContext.Services
                     .GetRequiredService<IDataService>();
            _orderController = new OrderController(dataService);

            // If you need the user again:
            //var mauiApp = (App)Application.Current;
            //_currentUserId = mauiApp.CurrentUser.UserID;

            _cartItems = items;

            // pre-fill summary
            CartSummary.ItemsSource = _cartItems;
            TotalLabel.Text = _cartItems.Sum(i => i.Quantity * i.UnitPrice).ToString("C");
        }

        private async void OnCheckoutClicked(object sender, EventArgs e)
        {
            // gather shipping info from entry fields
            //var address = new Address
            //{
            //    Street = StreetEntry.Text,
            //    City = CityEntry.Text,
            //    State = StateEntry.Text,
            //    ZipCode = ZipEntry.Text
            //};

            var orderItems = _cartItems
                  .Select(ci => new OrderItem(
                      orderId: 0,                // will be set in your service
                      productId: ci.ProductID,
                      quantity: ci.Quantity,
                      unitPrice: ci.UnitPrice)).ToList();

            var order = new Order
            {
                //UserID = _currentUserId,
                UserID = 1,
                TotalPrice = _cartItems.Sum(i => i.Quantity * i.UnitPrice),
                OrderDate = DateTime.UtcNow,
                Items = orderItems,
                //ShippingAddress = address
            };

            await _orderController.CompleteOrderAsync(this, order);
        }
    }
}