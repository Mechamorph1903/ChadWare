using ChadWare.Services;

namespace ChadWare
{
    public partial class MainPage : ContentPage
    {
        private readonly UserService _userService;
        public MainPage()
        {
            InitializeComponent();
            _userService = new UserService();
            InitializeTestUsers();
        }

        private async void InitializeTestUsers()
        {
            await _userService.AddTestUsersAsync();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text?.Trim();
            string password = PasswordEntry.Text;

            // Validate empty fields
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Validation Error", "Email and password are required.", "OK");
                return;
            }

            // Validate email format
            if (!IsValidEmail(email))
            {
                await DisplayAlert("Validation Error", "Please enter a valid email address.", "OK");
                return;
            }

            // Authenticate user against database
            if (await _userService.ValidateUserAsync(email, password))
            {
                // Store credentials securely
                await SecureStorage.Default.SetAsync("UserEmail", email);
                await SecureStorage.Default.SetAsync("UserPassword", password);

                await _userService.UpdateLastLoginAsync(email);
                await Navigation.PushAsync(new Views.Pages.ProductPage());
            }
            else
            {
                await DisplayAlert("Login Failed", "Email or password is incorrect.", "OK");
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text?.Trim();
            string password = PasswordEntry.Text;

            // Validate empty fields
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Validation Error", "Email and password are required.", "OK");
                return;
            }

            // Validate email format
            if (!IsValidEmail(email))
            {
                await DisplayAlert("Validation Error", "Please enter a valid email address.", "OK");
                return;
            }

            // Validate password strength
            if (password.Length < 8 || !password.Any(char.IsUpper) || !password.Any(char.IsLower) ||
                !password.Any(char.IsDigit) || !password.Any(c => !char.IsLetterOrDigit(c)))
            {
                await DisplayAlert("Validation Error",
                    "Password must be at least 8 characters long and contain uppercase, lowercase, number, and special character.",
                    "OK");
                return;
            }

            // Create new user
            var newUser = new Models.User(
                firstName: "New", // These will be updated in the profile page
                lastName: "User",
                email: email,
                password: password,
                phoneNumber: ""
            );

            // Try to add the user
            if (await _userService.AddUserAsync(newUser))
            {
                await DisplayAlert("Success", "User account created successfully! You can now log in.", "OK");
                // Clear the fields
                EmailEntry.Text = string.Empty;
                PasswordEntry.Text = string.Empty;
            }
            else
            {
                await DisplayAlert("Error", "An account with this email already exists.", "OK");
            }
        }
    }
}
