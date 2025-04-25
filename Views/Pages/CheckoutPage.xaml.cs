using Microsoft.Maui.Controls;
using ChadWare.Controllers;
using ChadWare.Models;
using ChadWare.Services;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System;

namespace ChadWare.Views.Pages
{
    public partial class CheckoutPage : ContentPage
    {
        private readonly OrderController _orderController;
        private long _currentUserId;
        private IList<CartItem> _cartItems;

        public CheckoutPage(long userId, IList<CartItem> items)
        {
            InitializeComponent();
            var dataService = Application.Current.Services.GetService<IDataService>();
            _orderController = new OrderController(dataService);

            _currentUserId = userId;
            _cartItems = items;

            // pre-fill summary
            CartSummary.ItemsSource = _cartItems;
            TotalLabel.Text = _cartItems.Sum(i => i.Quantity * i.UnitPrice).ToString("C");
        }

        private async void OnPlaceOrderClicked(object sender, EventArgs e)
        {
            // gather shipping info from entry fields
            var address = new Address
            {
                Street = StreetEntry.Text,
                City = CityEntry.Text,
                State = StateEntry.Text,
                ZipCode = ZipEntry.Text
            };

            var order = new Order
            {
                UserID = _currentUserId,
                TotalPrice = _cartItems.Sum(i => i.Quantity * i.UnitPrice),
                OrderDate = DateTime.UtcNow,
                Items = _cartItems.ToList(),
                ShippingAddress = address
            };

            await _orderController.CompleteOrderAsync(this, order);
        }
    }
}