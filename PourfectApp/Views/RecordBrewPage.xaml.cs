namespace PourfectApp.Views
{
    public partial class RecordBrewPage : ContentPage
    {
        public RecordBrewPage()
        {
            InitializeComponent();

            // Set default values
            RoastDatePicker.Date = DateTime.Today;
            DripperPicker.SelectedIndex = 0; // V60

            // Handle rating slider changes
            RatingSlider.ValueChanged += OnRatingChanged;
        }

        private void OnRatingChanged(object sender, ValueChangedEventArgs e)
        {
            RatingLabel.Text = $"{e.NewValue:F1} / 5.0";
        }

        private async void OnSaveBrewClicked(object sender, EventArgs e)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(CoffeeNameEntry.Text))
            {
                await DisplayAlert("Error", "Please enter the coffee name", "OK");
                return;
            }

            // For now, just show success message
            // Later we'll save to SQLite
            await DisplayAlert("Success", $"Brew recorded for {CoffeeNameEntry.Text}!", "OK");

            // Clear form
            ClearForm();
        }

        private void ClearForm()
        {
            CoffeeNameEntry.Text = "";
            RoasterEntry.Text = "";
            RoastDatePicker.Date = DateTime.Today;
            CoffeeWeightEntry.Text = "";
            WaterWeightEntry.Text = "";
            GrindSizeEntry.Text = "";
            WaterTempEntry.Text = "";
            BrewTimeEntry.Text = "";
            DripperPicker.SelectedIndex = 0;
            NotesEditor.Text = "";
            RatingSlider.Value = 3;
        }
    }
}