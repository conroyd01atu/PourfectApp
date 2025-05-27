namespace PourfectApp.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            // For now, just check if fields are not empty
            if (string.IsNullOrWhiteSpace(UsernameEntry.Text) ||
                string.IsNullOrWhiteSpace(PasswordEntry.Text))
            {
                await DisplayAlert("Error", "Please enter both username and password", "OK");
                return;
            }

            // Store username in preferences for later use
            Preferences.Set("username", UsernameEntry.Text);
            Preferences.Set("isLoggedIn", true);

            // Navigate to main app
            Application.Current.MainPage = new AppShell();
        }

        private void OnSkipLoginClicked(object sender, EventArgs e)
        {
            // Set guest mode
            Preferences.Set("username", "Guest");
            Preferences.Set("isLoggedIn", false);

            // Navigate to main app
            Application.Current.MainPage = new AppShell();
        }
    }
}