using ChadWare.ViewModels;

namespace ChadWare.Views.Pages;

public partial class SignIn : ContentPage
{
	public SignIn(SignInViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}