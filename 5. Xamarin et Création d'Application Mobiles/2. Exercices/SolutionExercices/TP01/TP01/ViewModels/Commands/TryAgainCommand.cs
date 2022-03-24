using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TP01.ViewModels.Commands
{
    public class TryAgainCommand : ICommand
    {
        private GameVM vm;

        public event EventHandler CanExecuteChanged;

        public TryAgainCommand(GameVM vm)
        {
            this.vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                bool wonState = (bool) parameter;

                if (!wonState) return true;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            vm.GenerateNewNumber();
        }
    }
}
