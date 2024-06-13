using NetMAUIDemoApp.ViewModels.auth;

namespace NetMAUIDemoApp.Views.auth;

public partial class Signup : ContentPage
{
    public Signup()
    {
        InitializeComponent();

        HandlerChanged += OnHandlerChanged;
    }

    void OnHandlerChanged(object sender, EventArgs e)
    {
        BindingContext = Handler.MauiContext.Services.GetService<SignupViewModel>();
    }

    private async void OnLoginButtonPressed(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//login");
    }

    private async void OnSignupButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("flow1");
    }
}