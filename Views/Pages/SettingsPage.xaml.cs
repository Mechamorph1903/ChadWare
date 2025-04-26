
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
    string email = "SarahSmith45@gmail.com";
    string name = "Sarah Smith";
    string phone = "(123)-456-7890";

    public SettingsPage()
    {
        InitializeComponent();
        ShowPersonalInfo();
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
                    new Switch(),
                    new Label { Text = "SMS Notifications", FontAttributes = FontAttributes.Bold },
                    new Switch(),
                    new Label { Text = "Mail Notifications", FontAttributes = FontAttributes.Bold },
                    new Switch(),
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

    void OnSignOutClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage.DisplayAlert("Sign Out", "You have signed out successfully.", "OK");
    }

    void ShowPersonalInfo()
    {
        var stack = new StackLayout { Spacing = 15 };

        // Email
        var emailEntry = new Entry { Text = email, Placeholder = "Email" };
        var emailButton = new Button { Text = "Update Email" };
        emailButton.Clicked += (s, e) => {
            email = emailEntry.Text;
            DisplayAlert("Success", "Email updated successfully!", "OK");
        };

        // Password
        var passwordEntry = new Entry { Placeholder = "New Password", IsPassword = true };
        var passwordButton = new Button { Text = "Update Password" };
        passwordButton.Clicked += (s, e) => {
            DisplayAlert("Success", "Password updated successfully!", "OK");
        };

        // Name
        var nameEntry = new Entry { Text = name, Placeholder = "Full Name" };
        var nameButton = new Button { Text = "Update Name" };
        nameButton.Clicked += (s, e) => {
            name = nameEntry.Text;
            DisplayAlert("Success", "Name updated successfully!", "OK");
        };

        // Phone
        var phoneEntry = new Entry { Text = phone, Placeholder = "Mobile Number" };
        var phoneButton = new Button { Text = "Update Mobile Number" };
        phoneButton.Clicked += (s, e) => {
            phone = phoneEntry.Text;
            DisplayAlert("Success", "Mobile number updated successfully!", "OK");
        };

        stack.Children.Add(new Label { Text = "Personal Information", FontAttributes = FontAttributes.Bold, FontSize = 20 });
        stack.Children.Add(new Label { Text = "Email", FontAttributes = FontAttributes.Bold });
        stack.Children.Add(emailEntry);
        stack.Children.Add(emailButton);

        stack.Children.Add(new Label { Text = "Password", FontAttributes = FontAttributes.Bold });
        stack.Children.Add(passwordEntry);
        stack.Children.Add(passwordButton);

        stack.Children.Add(new Label { Text = "Name", FontAttributes = FontAttributes.Bold });
        stack.Children.Add(nameEntry);
        stack.Children.Add(nameButton);

        stack.Children.Add(new Label { Text = "Mobile Number", FontAttributes = FontAttributes.Bold });
        stack.Children.Add(phoneEntry);
        stack.Children.Add(phoneButton);

        ContentArea.Content = stack;
    }
}
}