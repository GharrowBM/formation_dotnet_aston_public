using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TP01.ViewModels.Commands
{
    public class TestNumberCommand : ICommand
    {
        private GameVM gameVM;

        public event EventHandler CanExecuteChanged;

        public TestNumberCommand(GameVM gameVM)
        {
            this.gameVM = gameVM;
        }

        public bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                int number = (int)parameter;

                if (number > gameVM.MinValue && number <= gameVM.MaxValue) return true;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            gameVM.TestMysteryNumber();
        }
    }
}
