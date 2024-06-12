using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using Microsoft.Maui.ApplicationModel.Communication;
using Microsoft.Maui.Storage;

namespace NetMAUIDemoApp.ViewModels
{
    class ProfilePageViewModel: INotifyPropertyChanged
    {
        public ICommand SaveCommand { get; }
        public ICommand ClearPreferencesCommand { get; }
        public ICommand LogoutCommand { get; }

        public ProfilePageViewModel()
        {
            SaveCommand = new Command(OnSaveButtonClicked);
            ClearPreferencesCommand = new Command(OnClearPreferencesButtonClicked);
            LogoutCommand = new Command(OnLogoutButtonClicked);
        }

        private void OnSaveButtonClicked()
        {
            Preferences.Set("fname", _fname);
            Preferences.Set("lname", _lname);
            Preferences.Set("email", _email);
        }

        private void OnClearPreferencesButtonClicked()
        {
            Preferences.Clear();
            FName = string.Empty;
            LName = string.Empty;
            Email = string.Empty;
        }

        private async void OnLogoutButtonClicked()
        {
            await Shell.Current.GoToAsync("//login");
        }

        private string _fname;
        private string _lname;
        private string _email;

        public string FName
        {
            get => _fname;
            set
            {
                if (_fname != value)
                {
                    _fname = value;
                    OnPropertyChanged(nameof(FName));
                }
            }
        }
        public string LName
        {
            get => _lname;
            set
            {
                if (_lname != value)
                {
                    _lname = value;
                    OnPropertyChanged(nameof(LName));
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void LoadData()
        {
            FName = Preferences.Get("fname", "");
            LName = Preferences.Get("lname", "");
            Email = Preferences.Get("email", "");
        }
    }
}
