using NetMAUIDemoApp.ViewModels;

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
}

