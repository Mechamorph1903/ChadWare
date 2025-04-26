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

            if (!confirm)
                return;

            await DisplayAlert("Billing", "Using billing method on file...", "OK");

            // Build the receipt text
            string receiptContent = "Receipt\n\n";
            foreach (var item in _cartItems)
            {
                receiptContent += $"{item.ProductName} - ${item.UnitPrice:F2}\n";
            }
            receiptContent += $"\nTotal: {_cartItems.Sum(i => i.UnitPrice):C}";

            try
            {
                // Let user pick a folder (simulate by picking a file first)
                var picked = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "Select a file to overwrite (or pick any file in target folder)"
                });

                if (picked != null)
                {
                    // Get the directory path from the picked file
                    var folderPath = Path.GetDirectoryName(picked.FullPath);

                    // Create a receipt filename inside that directory
                    var receiptFileName = $"Receipt_{DateTime.Now:yyyyMMddHHmmss}.txt";
                    var fullReceiptPath = Path.Combine(folderPath, receiptFileName);

                    // Write the receipt file
                    File.WriteAllText(fullReceiptPath, receiptContent);

                    await DisplayAlert("Success", $"Receipt saved successfully at {fullReceiptPath}.", "OK");
                }
                else
                {
                    await DisplayAlert("Cancelled", "No location selected.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to save receipt: {ex.Message}", "OK");
            }
        }

    }
}
