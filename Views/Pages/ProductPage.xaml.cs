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

    private async void OnWomenTapped(object sender, EventArgs e)
    {
        // Navigate or show women's section
        await Navigation.PushAsync(new Views.Pages.ProductPage());
    }

    private async void OnUserIconClicked(object sender, EventArgs e)
    {
        var userEmail = await SecureStorage.Default.GetAsync("UserEmail");
        
        if (string.IsNullOrEmpty(userEmail))
        {
            // User not logged in, redirect to login page
            await Navigation.PopToRootAsync();
        }
        else
        {
            // Show user profile
            await Navigation.PushAsync(new UserProfilePage(userEmail));
        }
    }

    private async void OnCategoryClicked(object sender, EventArgs e)
    {
        if (sender is ImageButton button && button.Source is FileImageSource imageSource)
        {
            string fileName = imageSource.File.ToLower(); // e.g., "womenbags.png"
            string category = "";

            if (fileName.Contains("apparel"))
                category = "Apparel";
            else if (fileName.Contains("bags"))
                category = "Bags";
            else if (fileName.Contains("shoes"))
                category = "Shoes";
            else if (fileName.Contains("jewelry"))
                category = "Jewelry";

            if (!string.IsNullOrEmpty(category))
            {
                await DisplayAlert("Category Clicked", $"{category} selected", "OK");

                // Example: Navigate to a specific page (you can switch to a shared CategoryPage if needed)
                // await Navigation.PushAsync(new CategoryPage(category));
            }
            else
            {
                await DisplayAlert("Error", "Unknown category", "OK");
            }
        }

    }
}