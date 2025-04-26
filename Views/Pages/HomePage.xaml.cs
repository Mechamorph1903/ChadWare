using System.Collections.ObjectModel;
using ChadWare.Models;
using ChadWare.Services;

namespace ChadWare.Views.Pages;

public partial class HomePage : ContentPage
{
    private readonly ProductService _productService;
    private ObservableCollection<Product> _searchResults;

    public ObservableCollection<Product> SearchResultsCollection
    {
        get => _searchResults;
        set
        {
            _searchResults = value;
            OnPropertyChanged(nameof(SearchResultsCollection));
        }
    }

    public HomePage()
    {
        InitializeComponent();
        _productService = ProductService.Instance;
        _searchResults = new ObservableCollection<Product>();
        BindingContext = this;
        
        // Hide search results initially
        SearchResults.IsVisible = false;
        HeroBanner.IsVisible = true;
    }

    private async void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                SearchResultsCollection.Clear();
                SearchResults.IsVisible = false;
                HeroBanner.IsVisible = true;
                return;
            }

            var searchQuery = e.NewTextValue.ToLower();
            _productService.SearchProducts(searchQuery);

            SearchResultsCollection.Clear();
            foreach (var product in _productService.SearchResults)
            {
                SearchResultsCollection.Add(product);
            }

            SearchResults.IsVisible = SearchResultsCollection.Count > 0;
            HeroBanner.IsVisible = SearchResultsCollection.Count == 0;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Search failed: {ex.Message}", "OK");
        }
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
        await Navigation.PushAsync(new Views.Pages.MenProductPage());
    }

    private async void OnHomeClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.Pages.HomePage());
    }

    private async void OnWomenTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.Pages.ProductPage());
    }

    private async void OnCartClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.Pages.CartPage());
    }

    private async void OnUserIconClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Coming Soon", "User profile or login screen will be here!", "OK");
    }
}