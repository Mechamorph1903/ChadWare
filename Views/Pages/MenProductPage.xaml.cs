namespace ChadWare.Views.Pages;

public partial class MenProductPage : ContentPage
{
    private async void OnUserIconClicked(object sender, EventArgs e)
    {
        // After we have profile page
        // await Navigation.PushAsync(new ProfilePage());

        // For now
        await DisplayAlert("Coming Soon", "User profile or login screen will be here!", "OK");
    }

    private async void OnCartClicked(object sender, EventArgs e)
    {
        // Navigate to Cart
        await Navigation.PushAsync(new Views.Pages.CartPage());
    }
    private async void OnHomeClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.Pages.HomePage());
    }

    private async void OnMenTapped(object sender, EventArgs e)
    {
        // Navigate or show men's section
        await Navigation.PushAsync(new Views.Pages.MenProductPage());
    }

    private async void OnWomenTapped(object sender, EventArgs e)
    {
        // Navigate or show women's section
        await Navigation.PushAsync(new Views.Pages.ProductPage());
    }

    private async void OnCategoryClicked(object sender, EventArgs e)
    {
        if (sender is ImageButton button && button.Source is FileImageSource imageSource)
        {
            string fileName = imageSource.File.ToLower();
            string category = "";

            if (fileName.Contains("apparel"))
            {
                category = "Men";
            }
            else if (fileName.Contains("bags"))
            {
                category = "Men Bags";
            }
            else if (fileName.Contains("shoes"))
            {
                category = "Men Shoes";
            }
            else if (fileName.Contains("accessories"))
            {
                category = "Accessories";
            }

            if (!string.IsNullOrEmpty(category))
            {
                await Navigation.PushAsync(new Views.Pages.ItemsPage(category));
            }
        }
    }
    public MenProductPage()
	{
		InitializeComponent();
	}
}