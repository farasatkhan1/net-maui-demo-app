namespace NetMAUIDemoApp.Views.auth;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void OnSignupButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//signup");
    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//home");
    }
}