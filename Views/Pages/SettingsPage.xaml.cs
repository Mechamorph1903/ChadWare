using ChadWare.Services;
using ChadWare.Models;
using Microsoft.Maui.Storage;
using System.Xml;

namespace ChadWare.Views.Pages
{
    public partial class SettingsPage : ContentPage
    {
        private readonly UserService _userService;
        private User? _currentUser;

        // Temporary fields for UI only
        private string? _mobileNumber;
        private DateTime? _birthday;

        public SettingsPage()
        {
            InitializeComponent();
            _userService = new UserService();
            LoadUserData();
        }

        private async void LoadUserData()
        {
            try
            {
                var email = await SecureStorage.GetAsync("UserEmail");
                if (string.IsNullOrWhiteSpace(email))
                {
                    await DisplayAlert("Error", "No logged-in user found.", "OK");
                    return;
                }

                _currentUser = await _userService.GetUserByEmailAsync(email);
                if (_currentUser != null)
                {
                    UsernameLabel.Text = _currentUser.FirstName ?? "Unknown User";
                    NameLabel.Text = _currentUser.FirstName ?? "No Name";
                    EmailLabel.Text = _currentUser.Email ?? "No Email";
                }
                else
                {
                    await DisplayAlert("Error", "User not found.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to load user data: {ex.Message}", "OK");
            }
        }

        private async void OnSignOutClicked(object sender, EventArgs e)
        {
            try
            {
                SecureStorage.Default.Remove("UserEmail");
                SecureStorage.Default.Remove("UserPassword");
                await Navigation.PopToRootAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Failed to sign out: " + ex.Message, "OK");
            }
        }

        private async void OnChangeEmailTapped(object sender, EventArgs e)
        {
            if (_currentUser == null) return;

            string newEmail = await DisplayPromptAsync("Change Email", "Enter new email address:", initialValue: _currentUser.Email);

            if (!string.IsNullOrWhiteSpace(newEmail))
            {
                if (IsValidEmail(newEmail))
                {
                    _currentUser.Email = newEmail;
                    await _userService.AddUserAsync(_currentUser);
                    await DisplayAlert("Success", "Email updated.", "OK");
                    LoadUserData();
                }
                else
                {
                    await DisplayAlert("Error", "Invalid email format.", "OK");
                }
            }
        }

        private async void OnChangePasswordTapped(object sender, EventArgs e)
        {
            if (_currentUser == null) return;

            string currentPassword = await DisplayPromptAsync("Change Password", "Enter current password:");

            if (!string.IsNullOrWhiteSpace(currentPassword))
            {
                var isValid = await _userService.ValidateUserAsync(_currentUser.Email, currentPassword);
                if (isValid)
                {
                    string newPassword = await DisplayPromptAsync("Change Password", "Enter new password:");
                    if (!string.IsNullOrWhiteSpace(newPassword))
                    {
                        string confirmPassword = await DisplayPromptAsync("Change Password", "Confirm new password:");
                        if (newPassword == confirmPassword)
                        {
                            _currentUser.Password = newPassword;
                            await _userService.AddUserAsync(_currentUser);
                            await DisplayAlert("Success", "Password updated.", "OK");
                        }
                        else
                        {
                            await DisplayAlert("Error", "Passwords do not match.", "OK");
                        }
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Current password incorrect.", "OK");
                }
            }
        }
        private async void OnHomeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Pages.HomePage());
        }
        private async void OnChangeNameTapped(object sender, EventArgs e)
        {
            if (_currentUser == null) return;

            string newName = await DisplayPromptAsync("Change Name", "Enter full name:", initialValue: _currentUser.FirstName);

            if (!string.IsNullOrWhiteSpace(newName))
            {
                _currentUser.FirstName = newName;
                await _userService.AddUserAsync(_currentUser);
                await DisplayAlert("Success", "Name updated.", "OK");

                // UPDATE BOTH LABELS IMMEDIATELY
                NameLabel.Text = _currentUser.FirstName ?? "No Name";
                UsernameLabel.Text = _currentUser.FirstName ?? "Unknown User";
            }
        }


        private async void OnChangeMobileNumberTapped(object sender, EventArgs e)
        {
            string newMobile = await DisplayPromptAsync("Change Mobile Number", "Enter new number:", initialValue: _mobileNumber);

            if (!string.IsNullOrWhiteSpace(newMobile))
            {
                _mobileNumber = newMobile;
                MobileLabel.Text = _mobileNumber;
                await DisplayAlert("Success", "Mobile number updated.", "OK");
            }
        }

        private async void OnAddBirthdayTapped(object sender, EventArgs e)
        {
            string input = await DisplayPromptAsync("Add Birthday", "Enter birthday (MM/DD/YYYY):");

            if (DateTime.TryParse(input, out DateTime birthday))
            {
                _birthday = birthday;
                BirthdayLabel.Text = _birthday?.ToString("MM/dd/yyyy") ?? "Not Set";
                await DisplayAlert("Success", "Birthday updated.", "OK");
            }
            else
            {
                await DisplayAlert("Error", "Invalid date format.", "OK");
            }
        }

        private async void OnPersonalInfoClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Info", "You are already viewing personal info.", "OK");
        }

        private async void OnCommunicationsClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Info", "Communications settings are not available yet.", "OK");
        }

        private async void OnPaymentMethodsClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Info", "Payment methods settings are not available yet.", "OK");
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
    }
}



