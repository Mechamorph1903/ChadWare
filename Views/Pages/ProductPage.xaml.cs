namespace ChadWare.Views.Pages;

public partial class ProductPage : ContentPage
{
    public ProductPage()
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
    private async void OnCategoryClicked(object sender, EventArgs e)
    {
        if (sender is ImageButton button && button.Source is FileImageSource imageSource)
        {
            string fileName = imageSource.File.ToLower();
            string category = "";

            if (fileName.Contains("apparel"))
                category = "Women Apparel";
            else if (fileName.Contains("bags"))
                category = "Women Bags";
            else if (fileName.Contains("shoes"))
                category = "Women Shoes";
            else if (fileName.Contains("jewelry"))
                category = "Women Jewelry";

            if (!string.IsNullOrEmpty(category))
            {
                await Navigation.PushAsync(new ItemsPage(category));
            }
        }
    }
}