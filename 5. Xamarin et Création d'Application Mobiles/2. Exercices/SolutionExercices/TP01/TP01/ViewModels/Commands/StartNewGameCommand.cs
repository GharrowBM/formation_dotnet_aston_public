using TP01.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TP01.ViewModels.Commands
{
    public class StartNewGameCommand : ICommand
    {
        private StartVM startVM;

        public event EventHandler CanExecuteChanged;

        public StartNewGameCommand(StartVM startVM)
        {
            this.startVM = startVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            startVM.StartNewGame();
        }
    }
}
