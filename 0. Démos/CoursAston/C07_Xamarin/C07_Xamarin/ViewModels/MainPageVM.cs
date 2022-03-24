using C07_Xamarin.Helpers;
using C07_Xamarin.Pages;
using C07_Xamarin.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace C07_Xamarin.ViewModels
{
    public class MainPageVM : INotifyPropertyChanged
    {
        private LoginCredentials _credentials = new LoginCredentials { Email = String.Empty, Password = String.Empty };
        private MainPage _page;
        private bool _isCredentialsValid;
        public bool IsCredetialsValid
        {
            get => _isCredentialsValid;
            set
            {
                _isCredentialsValid = value;
                OnPropertyChanged("IsCredentialsValid");
            }
        }

        public LoginCredentials Credentials 
        { 
            get => _credentials; 
            set
            {
                _credentials = value;
                OnPropertyChanged("Credentials");
            }
        }
        public string Email 
        { 
            get => Credentials.Email; 
            set
            {
                Credentials = new LoginCredentials()
                {
                    Password = Credentials.Password,
                    Email = value
                };
            }
        }
        public string Password 
        { 
            get => Credentials.Password; 
            set
            {
                Credentials = new LoginCredentials()
                {
                    Email = Credentials.Email,
                    Password = value
                };
            }
        }

        public LoginCommand LoginCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;



        public MainPageVM(MainPage page)
        {
            _page = page;

            Password = string.Empty;
            Email = string.Empty;
            IsCredetialsValid = false;

            LoginCommand = new LoginCommand(this);
        }

        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public async Task LoginAttempt()
        {
            Tuple<bool, string> loginResults = await LoginHelper.TryLogin(Email, Password);
            if (loginResults.Item1)
            {
                App.Token = loginResults.Item2;
                await _page.Navigation.PushAsync(new HomePage());
            }
            else
            {
                _page.DisplayAlert("Erreur", "La connection a échoué", "Ok");
            }

            //if (Email == "user@example.com" && Password == "Pa$$w0rd") await _page.Navigation.PushAsync(new HomePage());
        } 
    }

    public class LoginCredentials
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
