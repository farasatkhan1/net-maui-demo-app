namespace NetMAUIDemoApp.Views.auth.onboarding;

public partial class SignupFlow2 : ContentPage
{
	public SignupFlow2()
	{
		InitializeComponent();
	}

    private async void onFlowClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//home");
    }
}