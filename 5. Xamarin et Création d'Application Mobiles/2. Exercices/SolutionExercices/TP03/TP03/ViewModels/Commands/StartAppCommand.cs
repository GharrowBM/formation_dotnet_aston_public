using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TP03.ViewModels.Commands
{
    public class StartAppCommand : ICommand
    {
        private MainVM _vm;
        public StartAppCommand(MainVM vm)
        {
            _vm = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _vm.TakePicture();
        }
    }
}
