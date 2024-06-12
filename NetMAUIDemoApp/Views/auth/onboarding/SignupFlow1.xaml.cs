namespace NetMAUIDemoApp.Views.auth.onboarding;

public partial class SignupFlow1 : ContentPage
{
	public SignupFlow1()
	{
		InitializeComponent();
	}

    private async void onFlowClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("flow2");
    }
}