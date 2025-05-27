using System.Collections.ObjectModel;

namespace PourfectApp.Views
{
    public partial class RecipesPage : ContentPage
    {
        // Temporary class for displaying recipes (will be replaced with proper model later)
        public class RecipeItem
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Method { get; set; }
            public string Ratio { get; set; }
            public int Temperature { get; set; }
            public string TotalTime { get; set; }
            public string GrindSize { get; set; }
            public bool IsFavorite { get; set; }
            public string FavoriteIcon => IsFavorite ? "⭐" : "☆";
        }

        private ObservableCollection<RecipeItem> recipes;

        public RecipesPage()
        {
            InitializeComponent();
            LoadRecipes();
        }

        private void LoadRecipes()
        {
            // Sample recipes to get started
            recipes = new ObservableCollection<RecipeItem>
            {
                new RecipeItem
                {
                    Name = "James Hoffmann V60",
                    Description = @"Award winning Barista Jame Hoffman's v60 Recipe. 
                            Pour in three stages: 2x the weight of grounds for the bloom (45 seconds), then two equal pours at 45-second intervals.
                            Stir during the bloom, swirl gently at the end, and aim for a total brew time of around 2:30.",
                    Method = "V60",
                    Ratio = "1:16.67",
                    Temperature = 95,
                    TotalTime = "2:30",
                    GrindSize = "Fine",
                    IsFavorite = true
                },
                new RecipeItem
                {
                    Name = "Scott Rao Chemex",
                    Description = "Classic Chemex recipe for clean, bright cups",
                    Method = "Chemex",
                    Ratio = "1:15",
                    Temperature = 96,
                    TotalTime = "4:00",
                    GrindSize = "Medium-Coarse",
                    IsFavorite = false
                },
                new RecipeItem
                {
                    Name = "4:6 Method",
                   Description = @"Tetsu Kasuya's flexible recipe for adjusting sweetness and strength. 
                                   Divide your first four pours into 40 percent of the total water weight, 
                                   and adjust the remaining 60 percent to taste, either in 1 pour, 
                                   or 3–4 more smaller pours.",
                    Method = "V60",
                    Ratio = "1:15",
                    Temperature = 90,
                    TotalTime = "3:45",
                    GrindSize = "Coarse",
                    IsFavorite = true
                }
            };

            RecipesCollectionView.ItemsSource = recipes;
        }

        private async void OnAddRecipeClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Add Recipe", "Recipe creation will be implemented with SQLite database", "OK");
        }

        private async void OnRecipeTapped(object sender, EventArgs e)
        {
            if (sender is Frame frame && frame.BindingContext is RecipeItem recipe)
            {
                string details = $"Method: {recipe.Method}\n" +
                               $"Ratio: {recipe.Ratio}\n" +
                               $"Temperature: {recipe.Temperature}°C\n" +
                               $"Total Time: {recipe.TotalTime}\n" +
                               $"Grind Size: {recipe.GrindSize}\n\n" +
                               $"{recipe.Description}";

                await DisplayAlert(recipe.Name, details, "OK");
            }
        }
    }
}