using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TP03.ViewModels.Commands
{
    public class RedoPictureCommand : ICommand
    {
        private ScanVM _vm;

        public event EventHandler CanExecuteChanged;

        public RedoPictureCommand(ScanVM vm)
        {
            _vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _vm.RedoPicture();
        }
    }
}
