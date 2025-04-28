using System.Collections.ObjectModel;
using ChadWare.Controllers;
using ChadWare.Models;
using ChadWare.Services;

namespace ChadWare.Views.Pages;

public partial class ItemsPage : ContentPage
{
    private readonly CartController _cartController;
    private const long _dummyUserId = 1;
    public ObservableCollection<Product> Products { get; } = new ObservableCollection<Product>();
    public string CategoryTitle { get; }
    public string CategoryPath { get; }

    public ItemsPage(string category)
	{
		InitializeComponent();
        CategoryTitle = category.ToUpper();
        CategoryPath = category;
        BindingContext = this;

        // resolve CartController once
        var ds = App.Services.GetRequiredService<IDataService>();
        _cartController = new CartController(ds);
        LoadProducts(category);
    }

    private void LoadProducts(string category)
    {
        var list = ProductService.Instance.GetProductsByCategory(category);
        Products.Clear();
        foreach (var p in list)
            Products.Add(p);
    }
    private async void OnMenTapped(object sender, EventArgs e)
    {
        // Navigate or show men's section
        await Navigation.PushAsync(new Views.Pages.MenProductPage());
    }

    private async void OnHomeClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.Pages.HomePage());
    }

    private async void OnWomenTapped(object sender, EventArgs e)
    {
        // Navigate or show women's section
        await Navigation.PushAsync(new Views.Pages.ProductPage());
    }

    private async void OnCartClicked(object sender, EventArgs e)
    {
        // Navigate to Cart
        await Navigation.PushAsync(new Views.Pages.CartPage());
    }

    private async void OnUserIconClicked(object sender, EventArgs e)
    {
        // After we have profile page
        // await Navigation.PushAsync(new ProfilePage());

        // For now
        await Navigation.PushAsync(new Views.Pages.SettingsPage());
    }

    private async void OnAddToCartClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is Product product)
        {
            var cartItem = new CartItem(
                   userId: _dummyUserId,
                   productId: product.ProductID,
                   productName: product.Name,
                   quantity: 1,
                   unitPrice: product.Price,
                   size: string.Empty
            );

            await _cartController.AddToCartAsync(_dummyUserId, cartItem);
            // Dummy implementation - just show success message
            await DisplayAlert("Success", $"{product.Name} added to cart", "OK");
        }
    }
}