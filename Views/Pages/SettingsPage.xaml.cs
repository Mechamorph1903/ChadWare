
using Microsoft.Maui;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using ChadWare.Controllers;
using ChadWare.Models;
using ChadWare.Services;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ChadWare.Views.Pages
{
    public partial class SettingsPage : ContentPage
    {
        // User data model
        private UserData userData;

        public SettingsPage()
        {
            InitializeComponent();

            // Initialize user data with mock values
            userData = new UserData
            {
                Name = "Sarah Smith",
                Email = "sarahsmith55@gmail.com",
                MobileNumber = "(123)-456-789",
                Birthday = null // Initially not set
            };

            // Load user data to UI
            LoadUserData();
        }

        private void LoadUserData()
        {
            // In a real implementation, this would update UI elements with the current userData values
            // For now, assuming data is already displayed via XAML
        }

        // Event handler for sign-out button
        private async void OnSignOutClicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Sign Out", "Are you sure you want to sign out?", "Yes", "No");

            if (confirm)
            {
                await DisplayAlert("Signed Out", "You have been signed out successfully.", "OK");

                // In a real app, you would clear authentication tokens and navigate to login page
                // Example: await Navigation.PushAsync(new LoginPage());
            }
        }

        // Event handlers for changing user information
        private async void OnChangeEmailTapped(object sender, EventArgs e)
        {
            string newEmail = await DisplayPromptAsync("Change Email", "Enter new email address:", initialValue: userData.Email);

            if (!string.IsNullOrWhiteSpace(newEmail))
            {
                // Validate email format
                if (IsValidEmail(newEmail))
                {
                    userData.Email = newEmail;
                    await DisplayAlert("Success", "Email updated successfully.", "OK");
                    LoadUserData();
                }
                else
                {
                    await DisplayAlert("Error", "Please enter a valid email address.", "OK");
                }
            }
        }

        private async void OnChangePasswordTapped(object sender, EventArgs e)
        {
            string currentPassword = await DisplayPromptAsync("Change Password", "Enter current password:", keyboard: Keyboard.Default);

            if (!string.IsNullOrWhiteSpace(currentPassword))
            {
                // In a real app, you would validate the current password
                // For this demo, we'll accept any non-empty input

                string newPassword = await DisplayPromptAsync("Change Password", "Enter new password:", keyboard: Keyboard.Default);

                if (!string.IsNullOrWhiteSpace(newPassword))
                {
                    string confirmPassword = await DisplayPromptAsync("Change Password", "Confirm new password:", keyboard: Keyboard.Default);

                    if (newPassword == confirmPassword)
                    {
                        await DisplayAlert("Success", "Password updated successfully.", "OK");
                    }
                    else
                    {
                        await DisplayAlert("Error", "Passwords do not match.", "OK");
                    }
                }
            }
        }

        private async void OnChangeNameTapped(object sender, EventArgs e)
        {
            string newName = await DisplayPromptAsync("Change Name", "Enter new name:", initialValue: userData.Name);

            if (!string.IsNullOrWhiteSpace(newName))
            {
                userData.Name = newName;
                await DisplayAlert("Success", "Name updated successfully.", "OK");
                LoadUserData();
            }
        }

        private async void OnChangeMobileNumberTapped(object sender, EventArgs e)
        {
            string newMobileNumber = await DisplayPromptAsync("Change Mobile Number", "Enter new mobile number:", initialValue: userData.MobileNumber);

            if (!string.IsNullOrWhiteSpace(newMobileNumber))
            {
                // Validate phone number format
                if (IsValidPhoneNumber(newMobileNumber))
                {
                    userData.MobileNumber = newMobileNumber;
                    await DisplayAlert("Success", "Mobile number updated successfully.", "OK");
                    LoadUserData();
                }
                else
                {
                    await DisplayAlert("Error", "Please enter a valid mobile number.", "OK");
                }
            }
        }

        private async void OnAddBirthdayTapped(object sender, EventArgs e)
        {
            // For simplicity, we'll just use a prompt - in a real app you might want a date picker
            string birthdayInput = await DisplayPromptAsync("Add Birthday", "Enter your birthday (MM/DD/YYYY):",
                initialValue: userData.Birthday?.ToString("MM/dd/yyyy") ?? "");

            if (!string.IsNullOrWhiteSpace(birthdayInput))
            {
                // Try to parse the date
                if (DateTime.TryParse(birthdayInput, out DateTime birthday))
                {
                    userData.Birthday = birthday;
                    await DisplayAlert("Success", "Birthday added successfully.", "OK");
                    LoadUserData();
                }
                else
                {
                    await DisplayAlert("Error", "Please enter a valid date format (MM/DD/YYYY).", "OK");
                }
            }
        }

        // Helper methods for validation
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

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Simple validation - in a real app you might want more sophisticated validation
            return !string.IsNullOrWhiteSpace(phoneNumber) && phoneNumber.Length >= 7;
        }
    }

    // Simple data model class to hold user information
    public class UserData
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public DateTime? Birthday { get; set; }
        // Password is not stored here for security reasons
    }
}
    






