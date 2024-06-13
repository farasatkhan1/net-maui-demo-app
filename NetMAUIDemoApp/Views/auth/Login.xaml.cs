using NetMAUIDemoApp.ViewModels.auth;

namespace NetMAUIDemoApp.Views.auth;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();

        HandlerChanged += OnHandlerChanged;
    }

    void OnHandlerChanged(object sender, EventArgs e)
    {
        BindingContext = Handler.MauiContext.Services.GetService<LoginViewModel>();
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