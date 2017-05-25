using System;
using System.Windows;
using System.Windows.Input;

namespace lr1
{
    class ConfirmCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            bool flag = false;
            bool flag2 = false;
            bool flag3 = false;

            var apply = parameter as MainWindowViewModel;
            if (apply.House == 0 | apply.Building == 0 | apply.Flat == 0 | apply.Name == "" | apply.Surname == "" | apply.Patronymic == "")
                MessageBox.Show("Некорректные данные");
            else flag = true;

            foreach (var item in apply.Cities)
            {
                if (apply.SelectedCity.Name == item.Name) { flag2 = true; break; }
            }

            foreach (var item in apply.SelectedCity.Streets)
            {
                if (apply.SelectedStreet.Name == item.Name) { flag3 = true; break; }
            }

            if (flag == flag2 == flag3 == true) MessageBox.Show("Заявка отправлена");

            //if (string.IsNullOrWhiteSpace(apply.SelectedStreet.Name) & string.IsNullOrWhiteSpace(apply.SelectedCity.Name))
            //    MessageBox.Show("Укажите город");
            //else flag = true;


        }
    }
}