using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace ChadWare.ViewModels;

public partial class SignInViewModel : ObservableObject
{
    [ObservableProperty]
    private string email = string.Empty;

    [ObservableProperty]
    private string password = string.Empty;

    [ObservableProperty]
    private bool keepMeSignedIn;

    [ObservableProperty]
    private bool isLoading;

    public SignInViewModel()
    {
        // Constructor - any initialization if needed
    }

    [RelayCommand]
    private async Task LoginAsync()
    {
        if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
        {
            await Shell.Current.DisplayAlert("Error", "Please enter both email and password", "OK");
            return;
        }

        try
        {
            IsLoading = true;

            // TODO: Implement actual authentication logic here
            // Example:
            // var result = await _authService.LoginAsync(Email, Password);
            // if (result.Success) 
            // {
            //     if (KeepMeSignedIn)
            //     {
            //         await _authService.SaveCredentials(Email, Password);
            //     }
            //     await Shell.Current.GoToAsync("///HomePage");
            // }

            // Simulating authentication delay
            await Task.Delay(1000);

            // For demo purposes, just navigate to HomePage
            await Shell.Current.GoToAsync("///HomePage");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", "Login failed: " + ex.Message, "OK");
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    private async Task NavigateToSignUp()
    {
        // Navigate to sign up page
        await Shell.Current.GoToAsync("///SignUp");
    }

    [RelayCommand]
    private async Task ForgotPassword()
    {
        if (string.IsNullOrWhiteSpace(Email))
        {
            await Shell.Current.DisplayAlert("Error", "Please enter your email address first", "OK");
            return;
        }

        // TODO: Implement forgot password logic
        await Shell.Current.DisplayAlert("Password Reset", 
            "A password reset link will be sent to your email address", "OK");
    }
} 