using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NetMAUIDemoApp.ViewModels.auth
{
    public class LoginViewModel: INotifyPropertyChanged
    {
        private readonly FirebaseAuthClient _firebaseAuthClient;
        public ICommand LoginCommand { get; }

        public LoginViewModel(FirebaseAuthClient firebaseAuthClient)
        {
            _firebaseAuthClient = firebaseAuthClient;
            LoginCommand = new Command(async () => await SignIn());
            Task.Run(async () => await CheckIfUserIsLoggedIn());
        }

        private string _email;

        private string _password;

        public string Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        private async Task SignIn()
        {
            try
            {
                var user = await _firebaseAuthClient.SignInWithEmailAndPasswordAsync(Email, Password);
                if (user != null)
                {
                    var token = await GetAccessToken();

                    if (!string.IsNullOrEmpty(token))
                    {
                        Preferences.Set("accessToken", token);
                        Preferences.Set("fname", user.User.Info.DisplayName);
                        Preferences.Set("email", user.User.Info.Email);
                    }

                    await Shell.Current.GoToAsync("//home");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Login Failed", ex.Message, "OK");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async Task<string> GetAccessToken()
        {
            if (_firebaseAuthClient.User == null)
            {
                return null;
            }

            return await _firebaseAuthClient.User.GetIdTokenAsync();
        }

        private async Task CheckIfUserIsLoggedIn()
        {
            var token = GetSavedToken();
            if (!string.IsNullOrEmpty(token))
            {
                await Shell.Current.GoToAsync("//home");
            }
        }

        private string GetSavedToken()
        {
            return Preferences.Get("accessToken", null);
        }
    }
}
