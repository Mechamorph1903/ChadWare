using ChadWare.Models;

namespace ChadWare.Views.Pages;

public partial class ItemsPage : ContentPage
{
	public ItemsPage(string category)
	{
		InitializeComponent();
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