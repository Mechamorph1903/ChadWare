namespace ChadWare
{
    public partial class MainPage : ContentPage
    {
    public MainPage()
      {
        InitializeComponent();
      }
        private async void OnLoginClicked(object sender, EventArgs e)
        {
            // Example: Dummy login logic 
            string username = "user"; 
            string password = "pass";

            if (username == "user" && password == "pass")
            {
                await Navigation.PushAsync(new Views.Pages.HomePage()); 
            }
            else
            {
                await DisplayAlert("Login Failed", "Username or password is incorrect.", "OK");
            }
        }
    }

}
