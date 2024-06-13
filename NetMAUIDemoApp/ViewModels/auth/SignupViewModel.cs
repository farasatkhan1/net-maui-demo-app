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
    public class SignupViewModel
    {
        private readonly FirebaseAuthClient _firebaseAuthClient;

        public ICommand SignUpCommand { get; }

        public SignupViewModel(FirebaseAuthClient firebaseAuthClient)
        {
            _firebaseAuthClient = firebaseAuthClient;
            SignUpCommand = new Command(async () => await SignUp());

            Task.Run(async () => await CheckIfUserIsLoggedIn());
        }

        private string _username;
        private string _email;
        private string _password;

        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }
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

        private async Task SignUp()
        {
            try
            {
                var user = await _firebaseAuthClient.CreateUserWithEmailAndPasswordAsync(Email, Password, Username);
                if (user != null)
                {
                    var token = await GetAccessToken();

                    if (!string.IsNullOrEmpty(token))
                    {
                        Preferences.Set("accessToken", token);
                        Preferences.Set("fname", user.User.Info.DisplayName);
                        Preferences.Set("email", user.User.Info.Email);
                    }

                    await Shell.Current.GoToAsync("flow1");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Signup Failed", ex.Message, "OK");
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
