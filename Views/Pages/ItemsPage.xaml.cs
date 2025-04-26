using System.Collections.ObjectModel;
using ChadWare.Models;
using ChadWare.Services;

namespace ChadWare.Views.Pages;

public partial class ItemsPage : ContentPage
{
	private readonly ProductService _productService;
	private readonly string _category;
	public ObservableCollection<Product> Products { get; }

	public ItemsPage(string category)
	{
		InitializeComponent();
		_productService = ProductService.Instance;
		_category = category;
		Products = new ObservableCollection<Product>();
		BindingContext = this;
		LoadProducts();
	}

	private void LoadProducts()
	{
		var categoryProducts = _productService.GetProductsByCategory(_category);
		Products.Clear();
		foreach (var product in categoryProducts)
		{
			Products.Add(product);
		}
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
        await DisplayAlert("Coming Soon", "User profile or login screen will be here!", "OK");
    }

    private async void OnAddToCartClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is Product product)
        {
            // Dummy implementation - just show success message
            await DisplayAlert("Success", $"{product.Name} added to cart", "OK");
        }
    }
}