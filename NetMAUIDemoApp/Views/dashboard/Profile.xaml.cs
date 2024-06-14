using NetMAUIDemoApp.ViewModels;
using Plugin.Firebase.CloudMessaging;

namespace NetMAUIDemoApp.Views.dashboard;

public partial class Profile : ContentPage
{
    private ProfilePageViewModel profilePageViewModel;
    public Profile()
    {
        InitializeComponent();
        profilePageViewModel = new ProfilePageViewModel();
        BindingContext = profilePageViewModel;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        profilePageViewModel.LoadData();
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        await CrossFirebaseCloudMessaging.Current.CheckIfValidAsync();
        var token = await CrossFirebaseCloudMessaging.Current.GetTokenAsync();
        Console.WriteLine($"FCM token: {token}");
    }
}

