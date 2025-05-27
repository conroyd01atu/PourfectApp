using System.Collections.ObjectModel;

namespace PourfectApp.Views
{
    public partial class PastBrewsPage : ContentPage
    {
        // Temporary class for displaying brews (will be replaced with proper model later)
        public class BrewItem
        {
            public string CoffeeName { get; set; }
            public string Roaster { get; set; }
            public DateTime BrewDate { get; set; }
            public string Dripper { get; set; }
            public double CoffeeWeight { get; set; }
            public double WaterWeight { get; set; }
            public double Rating { get; set; }
        }

        private ObservableCollection<BrewItem> brews;

        public PastBrewsPage()
        {
            InitializeComponent();
            LoadBrews();
        }

        private void LoadBrews()
        {
            // For now, create some sample data
            brews = new ObservableCollection<BrewItem>
            {
                new BrewItem
                {
                    CoffeeName = "Ethiopian Yirgacheffe",
                    Roaster = "Blue Bottle Coffee",
                    BrewDate = DateTime.Today.AddDays(-1),
                    Dripper = "V60",
                    CoffeeWeight = 15,
                    WaterWeight = 250,
                    Rating = 4.5
                },
                new BrewItem
                {
                    CoffeeName = "Colombian Geisha",
                    Roaster = "Local Roaster",
                    BrewDate = DateTime.Today.AddDays(-3),
                    Dripper = "Chemex",
                    CoffeeWeight = 30,
                    WaterWeight = 500,
                    Rating = 5.0
                },
                new BrewItem
                {
                    CoffeeName = "Kenya AA",
                    Roaster = "Stumptown Coffee",
                    BrewDate = DateTime.Today.AddDays(-7),
                    Dripper = "Kalita Wave",
                    CoffeeWeight = 20,
                    WaterWeight = 340,
                    Rating = 4.0
                }
            };

            BrewsCollectionView.ItemsSource = brews;
        }

        private async void OnBrewTapped(object sender, EventArgs e)
        {
            if (sender is Frame frame && frame.BindingContext is BrewItem brew)
            {
                await DisplayAlert("Brew Details",
                    $"Coffee: {brew.CoffeeName}\n" +
                    $"Roaster: {brew.Roaster}\n" +
                    $"Method: {brew.Dripper}\n" +
                    $"Ratio: {brew.CoffeeWeight}g : {brew.WaterWeight}g\n" +
                    $"Rating: {brew.Rating:F1}/5.0",
                    "OK");
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Refresh brews when page appears
            // This will be useful when we add SQLite
        }
    }
}