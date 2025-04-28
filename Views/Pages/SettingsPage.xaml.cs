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
        private readonly IDataService _dataService;
        private User _currentUser;

        public SettingsPage(IDataService dataService)
        {
            InitializeComponent();
            _dataService = dataService;
            LoadUserData();
            ShowPersonalInfo();
        }

        private async void LoadUserData()
        {
            try
            {
                // In a real app, you would get the current user's ID from authentication
                _currentUser = await _dataService.GetUserByEmailAsync("SarahSmith45@gmail.com") ?? new User
                {
                    FirstName = "Sarah",
                    LastName = "Smith",
                    Email = "SarahSmith45@gmail.com",
                    PhoneNumber = "(123)-456-7890",
                    EmailNotifications = true,
                    SmsNotifications = false,
                    MailNotifications = true
                };
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Failed to load user data: " + ex.Message, "OK");
            }
        }

        void OnPersonalInfoClicked(object sender, EventArgs e)
        {
            ShowPersonalInfo();
        }

        void OnCommunicationsClicked(object sender, EventArgs e)
        {
            ContentArea.Content = new StackLayout
            {
                Spacing = 10,
                Children =
                {
                    new Label { Text = "Communications Preferences", FontAttributes = FontAttributes.Bold, FontSize = 20 },
                    new Label { Text = "Email Notifications", FontAttributes = FontAttributes.Bold },
                    new Switch { IsToggled = _currentUser?.EmailNotifications ?? false },
                    new Label { Text = "SMS Notifications", FontAttributes = FontAttributes.Bold },
                    new Switch { IsToggled = _currentUser?.SmsNotifications ?? false },
                    new Label { Text = "Mail Notifications", FontAttributes = FontAttributes.Bold },
                    new Switch { IsToggled = _currentUser?.MailNotifications ?? false },
                }
            };
        }

        void OnPaymentMethodsClicked(object sender, EventArgs e)
        {
            ContentArea.Content = new StackLayout
            {
                Spacing = 10,
                Children =
                {
                    new Label { Text = "Payment Methods", FontAttributes = FontAttributes.Bold, FontSize = 20 },
                    new Label { Text = "Visa ending in 1234", FontSize = 16 },
                    new Button { Text = "Add New Payment Method", FontSize = 12 }
                }
            };
        }

        async void OnSignOutClicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Sign Out", "Are you sure you want to sign out?", "Yes", "No");
            if (confirm)
            {
                // TODO: Implement sign out logic
                await Shell.Current.GoToAsync("///SignIn");
            }
        }

        void ShowPersonalInfo()
        {
            var stack = new StackLayout { Spacing = 15 };

            // Email
            var emailEntry = new Entry { Text = _currentUser?.Email, Placeholder = "Email" };
            var emailButton = new Button { Text = "Update Email" };
            emailButton.Clicked += async (s, e) => {
                try
                {
                    _currentUser.Email = emailEntry.Text;
                    await _dataService.UpdateUserAsync(_currentUser);
                    await DisplayAlert("Success", "Email updated successfully!", "OK");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", "Failed to update email: " + ex.Message, "OK");
                }
            };

            // Password
            var passwordEntry = new Entry { Placeholder = "New Password", IsPassword = true };
            var passwordButton = new Button { Text = "Update Password" };
            passwordButton.Clicked += async (s, e) => {
                try
                {
                    _currentUser.Password = passwordEntry.Text;
                    await _dataService.UpdateUserAsync(_currentUser);
                    await DisplayAlert("Success", "Password updated successfully!", "OK");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", "Failed to update password: " + ex.Message, "OK");
                }
            };

            // Name
            var firstNameEntry = new Entry { Text = _currentUser?.FirstName, Placeholder = "First Name" };
            var lastNameEntry = new Entry { Text = _currentUser?.LastName, Placeholder = "Last Name" };
            var nameButton = new Button { Text = "Update Name" };
            nameButton.Clicked += async (s, e) => {
                try
                {
                    _currentUser.FirstName = firstNameEntry.Text;
                    _currentUser.LastName = lastNameEntry.Text;
                    await _dataService.UpdateUserAsync(_currentUser);
                    await DisplayAlert("Success", "Name updated successfully!", "OK");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", "Failed to update name: " + ex.Message, "OK");
                }
            };

            // Phone
            var phoneEntry = new Entry { Text = _currentUser?.PhoneNumber, Placeholder = "Mobile Number" };
            var phoneButton = new Button { Text = "Update Mobile Number" };
            phoneButton.Clicked += async (s, e) => {
                try
                {
                    _currentUser.PhoneNumber = phoneEntry.Text;
                    await _dataService.UpdateUserAsync(_currentUser);
                    await DisplayAlert("Success", "Mobile number updated successfully!", "OK");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", "Failed to update mobile number: " + ex.Message, "OK");
                }
            };

            stack.Children.Add(new Label { Text = "Personal Information", FontAttributes = FontAttributes.Bold, FontSize = 20 });
            
            stack.Children.Add(new Label { Text = "Email", FontAttributes = FontAttributes.Bold });
            stack.Children.Add(emailEntry);
            stack.Children.Add(emailButton);

            stack.Children.Add(new Label { Text = "Password", FontAttributes = FontAttributes.Bold });
            stack.Children.Add(passwordEntry);
            stack.Children.Add(passwordButton);

            stack.Children.Add(new Label { Text = "Name", FontAttributes = FontAttributes.Bold });
            stack.Children.Add(firstNameEntry);
            stack.Children.Add(lastNameEntry);
            stack.Children.Add(nameButton);

            stack.Children.Add(new Label { Text = "Mobile Number", FontAttributes = FontAttributes.Bold });
            stack.Children.Add(phoneEntry);
            stack.Children.Add(phoneButton);

            ContentArea.Content = stack;
        }
    }
}