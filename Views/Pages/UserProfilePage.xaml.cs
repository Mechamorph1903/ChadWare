using ChadWare.Services;

namespace ChadWare.Views.Pages;

public partial class UserProfilePage : ContentPage
{
    public UserProfilePage(string email)
    {
        InitializeComponent();
        LoadUserProfile(email);
    }

    private async void LoadUserProfile(string email)
    {
        var userService = new UserService();
        var user = await userService.GetUserByEmailAsync(email);
        
        if (user != null)
        {
            // Set email
            EmailLabel.Text = user.Email;

            // Create display name from email
            string displayName = user.Email.Split('@')[0]; // Get part before @
            displayName = System.Globalization.CultureInfo.CurrentCulture.TextInfo
                .ToTitleCase(displayName.Replace(".", " ")); // Convert dots to spaces and capitalize
            UserNameLabel.Text = displayName;
        }
    }

    private async void OnSignOutClicked(object sender, EventArgs e)
    {
        try
        {
            // Clear the stored credentials
            SecureStorage.Default.Remove("UserEmail");
            SecureStorage.Default.Remove("UserPassword");

            // Navigate back to main page and clear the navigation stack
            await Navigation.PopToRootAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Failed to sign out: " + ex.Message, "OK");
        }
    }
}
