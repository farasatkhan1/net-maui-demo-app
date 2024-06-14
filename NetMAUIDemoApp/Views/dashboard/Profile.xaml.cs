using NetMAUIDemoApp.ViewModels;
using Plugin.Firebase.CloudMessaging;
using Plugin.Firebase.Crashlytics;

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

    private void DivideByZero(object sender, EventArgs e)
    {
        try
        {
            int zero = 0;
            var division = 10 / zero;
        }
        catch (Exception ex)
        {
            CrossFirebaseCrashlytics.Current.RecordException(ex);
            CrossFirebaseCrashlytics.Current.Log("This is Custom log message.");
            CrossFirebaseCrashlytics.Current.SetCustomKey("cus_key division", "<0_0>");
        }
        
    }
}

