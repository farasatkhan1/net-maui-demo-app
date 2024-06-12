using NetMAUIDemoApp.ViewModels;

namespace NetMAUIDemoApp.Views.dashboard;

public partial class Settings : ContentPage
{
	public Settings()
	{
        InitializeComponent();

        BindingContext = new SettingsPageViewModel();
    }
}