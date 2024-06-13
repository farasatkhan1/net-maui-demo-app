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
            await _firebaseAuthClient.SignInWithEmailAndPasswordAsync(Email, Password);

            await Shell.Current.GoToAsync("//home");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
