using DemoProject.Model;
using DemoProject.MVVM;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace DemoProject.ViewModel
{
    class AddDataWindowViewModel : ViewModelBase
    {
        public RelayCommand SubmitCommand => new RelayCommand(execute => SubmitData(), canExecute => CanSubmitData());

        public event Action<string> DataSubmitted;

        private string _boundName;

        public string BoundName
        {
            get { return _boundName; }
            set
            {
                _boundName = value;
                OnPropertyChanged();
            }
        }

        private string _boundNumberOfPets;
        public string BoundNumberOfPets
        {
            get { return _boundNumberOfPets; }
            set
            {
                _boundNumberOfPets = value;
                OnPropertyChanged();
            }
        }
 
        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
            }
        }

        public void SubmitData()
        {
            int year, month, day;
            string name;
            int pets;

            DataSubmitted?.Invoke( BoundName );
        }

        public bool CanSubmitData()
        {
            // Test if the first Textfield has some text at all
            if (string.IsNullOrWhiteSpace(BoundName))
                return false;

            if(string.IsNullOrEmpty(BoundNumberOfPets) || !Regex.IsMatch(BoundNumberOfPets, @"^\d+$"))
                return false;

            return true;

        }
    }


}
