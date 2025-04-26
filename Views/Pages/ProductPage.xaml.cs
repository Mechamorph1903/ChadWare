using System.Collections.ObjectModel;
using ChadWare.Models;
using ChadWare.Services;

namespace ChadWare.Views.Pages;

public partial class ProductPage : ContentPage
{
    private readonly ProductService _productService;
    public ObservableCollection<Product> SearchResultsCollection => _productService.SearchResults;

    public ProductPage()
    {
        InitializeComponent();
        _productService = ProductService.Instance;
        BindingContext = this;
    }

    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        var searchQuery = e.NewTextValue;
        if (string.IsNullOrWhiteSpace(searchQuery))
        {
            SearchResults.IsVisible = false;
            return;
        }

        _productService.SearchProducts(searchQuery, "women");
        SearchResults.IsVisible = SearchResultsCollection.Count > 0;
    }

    private async void OnAddToCartClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is Product product)
        {
            // Dummy implementation - just show success message
            await DisplayAlert("Success", $"{product.Name} added to cart", "OK");
        }
    }

    private async void OnMenTapped(object sender, EventArgs e)
    {
        // Navigate or show men's section
        await Navigation.PushAsync(new Views.Pages.MenProductPage());
    }

    private async void OnHomeClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.Pages.HomePage());
    }

    private async void OnWomenTapped(object sender, EventArgs e)
    {
        // Navigate or show women's section
        await Navigation.PushAsync(new Views.Pages.ProductPage());
    }

    private async void OnCartClicked(object sender, EventArgs e)
    {
        // Navigate to Cart
        await Navigation.PushAsync(new Views.Pages.CartPage());
    }

    private async void OnUserIconClicked(object sender, EventArgs e)
    {
        // After we have profile page
        // await Navigation.PushAsync(new ProfilePage());

        // For now
        await DisplayAlert("Coming Soon", "User profile or login screen will be here!", "OK");
    }



    // private async void OnCartClicked(object sender, EventArgs e)
    // {
    //     await Navigation.PushAsync(new Views.Pages.CartPage());
    // }

    private async void OnCategoryClicked(object sender, EventArgs e)
    {
        if (sender is ImageButton button && button.Source is FileImageSource imageSource)
        {
            string fileName = imageSource.File.ToLower();
            string category = "";

            if (fileName.Contains("apparel"))
                category = "Women Apparel";
            else if (fileName.Contains("bags"))
                category = "Women Bags";
            else if (fileName.Contains("shoes"))
                category = "Women Shoes";
            else if (fileName.Contains("jewelry"))
                category = "Women Jewelry";

            if (!string.IsNullOrEmpty(category))
            {
                await Navigation.PushAsync(new ItemsPage(category));
            }
        }
    }
}