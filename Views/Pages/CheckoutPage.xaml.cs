using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using ChadWare.Models;

namespace ChadWare.Views.Pages
{
    public partial class CheckoutPage : ContentPage
    {
        private readonly IList<CartItem> _cartItems;

        public CheckoutPage(IList<CartItem> cartItems)
        {
            InitializeComponent();
            _cartItems = cartItems;
        }

        private async void OnCheckoutClicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Confirm Order", "Are you sure you want to place the order?", "Yes", "No");

            if (confirm)
            {
                await DisplayAlert("Billing", "Using billing method on file...", "OK");

                string receiptContent = "Receipt\n\n";
                foreach (var item in _cartItems)
                {
                    receiptContent += $"{item.ProductName} - ${item.UnitPrice:F2}\n";
                }
                receiptContent += $"\nTotal: {_cartItems.Sum(i => i.UnitPrice):C}";

                // Prompt user to select a location to save the file
                var filePath = Path.Combine(FileSystem.AppDataDirectory, $"Receipt_{DateTime.Now:yyyyMMddHHmmss}.txt");

                try
                {
                    // Save the file directly to the specified path
                    using (var stream = File.Open(filePath, FileMode.Create, FileAccess.Write))
                    using (var writer = new StreamWriter(stream))
                    {
                        await writer.WriteAsync(receiptContent);
                    }

                    await DisplayAlert("Success", $"Receipt saved successfully at {filePath}.", "OK");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", $"Failed to save receipt: {ex.Message}", "OK");
                }
            }
        }
    }
}
