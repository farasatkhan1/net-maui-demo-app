namespace NetMAUIDemoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            base.OnStart();

            await CheckIfUserIsLoggedIn();
        }

        private async Task CheckIfUserIsLoggedIn()
        {
            var token = Preferences.Get("accessToken", null);
            if (!string.IsNullOrEmpty(token))
            {
                await Shell.Current.GoToAsync("//home");
            }
        }
    }
}
