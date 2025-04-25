namespace ChadWare.Views.Pages;

public partial class HomePage : ContentPage
{
    public HomePage()
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
}