using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace lr1
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _surname;
        private string _name;
        private string _patronymic;
        private int _house;
        private int _building;
        private int _flat;

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                DoPropertyChanged("Surname");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                DoPropertyChanged("Name");
            }
        }

        public string Patronymic
        {
            get { return _patronymic; }
            set
            {
                _patronymic = value;
                DoPropertyChanged("Patronymic");
            }
        }

        public int House
        {
            get { return _house; }
            set
            {
                _house = value;
                DoPropertyChanged("House");
            }
        }

        public int Building
        {
            get { return _building; }
            set
            {
                _building = value;
                DoPropertyChanged("Building");
            }
        }

        public int Flat
        {
            get { return _flat; }
            set
            {
                _flat = value;
                DoPropertyChanged("Flat");
            }
        }

        public List<City> Cities { get; set; }
        public List<Street> Streets { get; set; }

        public ICommand Confirm { get; set; }
        public ICommand Reset { get; set; }

        public class City
        {
            public string Name { get; set; }
            public List<Street> Streets { get; set; }
        }
        public class Street
        {
            public string Name { get; set; }
            public City CityNameforStreet { get; set; }
            public Street(string name)
            {
                Name = name;
            }
        }

        private City _selectedCity;
        public City SelectedCity
        {
            get { return _selectedCity; }
            set
            {
                if (value == null)
                    return;
                _selectedCity = value;
                DoPropertyChanged("SelectedCity");
                Streets = _selectedCity.Streets;
                DoPropertyChanged("Streets");
            }
        }

        private Street _selectedStreet;
        public Street SelectedStreet
        {
            get { return _selectedStreet; }
            set
            {
                if (value == null)
                    return;
                _selectedStreet = value;
                DoPropertyChanged("SelectedStreet");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void DoPropertyChanged(string Name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));
        }

        public MainWindowViewModel()
        {
            Cities = new List<City>()
                    {
                        new City(){ Name = "Москва", Streets = new List<Street>() {
                            new Street("Ленинский пр."),
                            new Street("Арбатская"),
                            new Street("Шаболовка")
                        } },
                        new City(){ Name = "Дубна", Streets = new List<Street>() {
                            new Street("Дубнинская"),
                            new Street("Северное шоссе"),
                            new Street("Максимовская")
                        } },
                        new City(){ Name = "Сочи", Streets = new List<Street>() {
                            new Street("Морская"),
                            new Street("Водная"),
                            new Street("Новая")
                        } },
                        new City(){ Name = "Кемерово", Streets = new List<Street>() {
                            new Street("Кемеровская"),
                            new Street("Большевиков"),
                            new Street("Конечная")
                        } }
                    };
            this.SelectedCity = this.Cities[0];
            this.SelectedStreet = Cities[0].Streets[0];
            this.Name = "";
            this.Surname = "";
            this.Patronymic = "";

            Confirm = new ConfirmCommand();
            Reset = new ResetCommand();
        }
    }
}
