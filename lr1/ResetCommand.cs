using System;
using System.Windows.Input;

namespace lr1
{
    class ResetCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var apply = parameter as MainWindowViewModel;

            apply.Surname = "";
            apply.Name = "";
            apply.Patronymic = "";
            apply.SelectedCity = apply.Cities[0];
            apply.SelectedStreet = apply.Cities[0].Streets[0];
            apply.House = 0;
            apply.Building = 0;
            apply.Flat = 0;
        }
    }
}