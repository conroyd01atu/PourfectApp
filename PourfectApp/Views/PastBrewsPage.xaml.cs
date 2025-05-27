using System.Collections.ObjectModel;
using PourfectApp.Models;

namespace PourfectApp.Views
{
    public partial class PastBrewsPage : ContentPage
    {
        private ObservableCollection<Brew> brews;

        public PastBrewsPage()
        {
            InitializeComponent();
            brews = new ObservableCollection<Brew>();
            BrewsCollectionView.ItemsSource = brews;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadBrews();
        }

        private async Task LoadBrews()
        {
            try
            {
                // Get current user
                string username = Preferences.Get("username", "Guest");

                // Load brews from database
                var brewList = await ServiceHelper.Database.GetBrewsByUserAsync(username);

                // Clear and repopulate the collection
                brews.Clear();
                foreach (var brew in brewList)
                {
                    brews.Add(brew);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to load brews: {ex.Message}", "OK");
            }
        }

        private async void OnBrewTapped(object sender, EventArgs e)
        {
            if (sender is Frame frame && frame.BindingContext is Brew brew)
            {
                await DisplayAlert("Brew Details",
                    $"Coffee: {brew.CoffeeName}\n" +
                    $"Roaster: {brew.Roaster}\n" +
                    $"Method: {brew.Dripper}\n" +
                    $"Ratio: {brew.CoffeeWeight}g : {brew.WaterWeight}g\n" +
                    $"Temperature: {brew.WaterTemperature}°C\n" +
                    $"Time: {brew.BrewTime}\n" +
                    $"Rating: {brew.Rating:F1}/5.0\n\n" +
                    $"Notes: {brew.Notes}",
                    "OK");
            }
        }
    }
}