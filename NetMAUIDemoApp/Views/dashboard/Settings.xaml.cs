using NetMAUIDemoApp.ViewModels;

namespace NetMAUIDemoApp.Views.dashboard;

public partial class Settings : ContentPage
{

	public Settings()
	{
        InitializeComponent();

        HandlerChanged += OnHandlerChanged;
    }

    void OnHandlerChanged(object sender, EventArgs e)
    {
        BindingContext = Handler.MauiContext.Services.GetService<SettingsPageViewModel>();
    }
}