using NetMAUIDemoApp.ViewModels;

namespace NetMAUIDemoApp.Views.dashboard;

public partial class Settings : ContentPage
{

	public Settings(SettingsPageViewModel viewModel)
	{
        InitializeComponent();

        BindingContext = viewModel;
    }
}