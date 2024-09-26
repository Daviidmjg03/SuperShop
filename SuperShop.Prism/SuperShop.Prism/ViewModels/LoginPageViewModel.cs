using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperShop.Prism.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public string _password;
        private bool _isRunning;
        private bool _IsEnabled;
        private DelegateCommand _loginComand;

        public LoginPageViewModel(INavigationService navigationService) :base(navigationService) 
        {
            Title = "Login";
            IsEnabled = true;
        }

        public DelegateCommand LoginCommand => _loginComand ?? (_loginComand = new DelegateCommand(Login));

        public string Email { get; set; }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsEnabled
        {
            get => _IsEnabled;

            set => SetProperty(ref _IsEnabled, value);
        }

        private async void Login()
        {

            if(string.IsNullOrEmpty(Email))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must enter an email.", "Accept");
                Password = string.Empty;
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must enter a password.", "Accept");
                Password = string.Empty;
                return;
            }

            await App.Current.MainPage.DisplayAlert("Ok", "Boa, entrámos!!!.", "Accept");

        }

    }
}
