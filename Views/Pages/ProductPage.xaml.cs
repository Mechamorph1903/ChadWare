namespace ChadWare.Views;

public partial class ProductPage : ContentPage
{
    public ProductPage()
    {
        InitializeComponent();
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