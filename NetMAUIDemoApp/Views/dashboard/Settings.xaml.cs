using NetMAUIDemoApp.Interfaces;

namespace NetMAUIDemoApp.Views.dashboard;

public partial class Settings : ContentPage
{
	public Settings()
	{
        InitializeComponent();

        var dependency = DependencyService.Get<IDeviceInfoService>();

        if (dependency != null)
        {
            DeviceInfoModel.Text = dependency.GetDeviceModel();
        }
    }
}