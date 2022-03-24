using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace C07_Xamarin.ViewModels.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly MainPageVM _vm;

        public LoginCommand(MainPageVM vm)
        {
            _vm = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var creds = parameter as LoginCredentials;
            if (creds == null) return false;
            if (!string.IsNullOrEmpty(creds.Password) && !string.IsNullOrEmpty(creds.Email))
            {
                _vm.IsCredetialsValid = true;
                return true;
            }

            _vm.IsCredetialsValid = false;
            return false;
        }

        public void Execute(object parameter)
        {
            _vm.LoginAttempt();
        }
    }
}
