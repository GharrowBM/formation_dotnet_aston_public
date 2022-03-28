using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EXO_03.ViewModels.Commands
{
    public class SearchCitiesByNameCommand : ICommand
    {
        private MainPageVM mainPageVM;
        public SearchCitiesByNameCommand(MainPageVM mainPageVM)
        {
            this.mainPageVM = mainPageVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            string cityName = parameter as string;

            if (string.IsNullOrEmpty(cityName)) return false;
            return true;
        }

        public void Execute(object parameter)
        {
            mainPageVM.SearchCitiesByName();
        }
    }
}
