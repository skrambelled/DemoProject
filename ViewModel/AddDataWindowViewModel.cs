using DemoProject.Model;
using DemoProject.MVVM;
using System.Text.RegularExpressions;

namespace DemoProject.ViewModel
{
    class AddDataWindowViewModel : ViewModelBase
    {
        public RelayCommand OKCommand => new RelayCommand(execute => AddData(), canExecute => CanAddData());
        public AddDataWindowViewModel()
        {
        }

        private string _numberOfPets;

        public string NumberOfPets
        {
            get { return _numberOfPets; }
            set {
                _numberOfPets = value;
                OnPropertyChanged();
                if(!Regex.IsMatch(value, @"^\d+$"))
                {
                   

                }
            }
        }

        public event EventHandler<AddItemEventArgs> DataReady;
        public void AddData()
        {

        }

        public bool CanAddData()
        {
            return true;
        }
    }


}
