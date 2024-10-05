using DemoProject.Model;
using DemoProject.MVVM;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
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
 
        private DateTime _boundSelectedDate = DateTime.Today;
        public DateTime BoundSelectedDate
        {
            get { return _boundSelectedDate; }
            set
            {
                _boundSelectedDate = value;
                OnPropertyChanged();
            }
        }



        public void SubmitData()
        {
;
            Item item = new Item();

            item.Name = BoundName;
            item.NumberOfPets = int.Parse(BoundNumberOfPets);
            item.Birthday = BoundSelectedDate;

            DataSubmitted?.Invoke( JsonSerializer.Serialize(item) );
        }

        public bool CanSubmitData()
        {
            // Test if the Name input field has some text at all
            if (string.IsNullOrWhiteSpace(BoundName))
                return false;

            // Test if the Number of Pets input field is an valid number
            if(string.IsNullOrEmpty(BoundNumberOfPets) || !Regex.IsMatch(BoundNumberOfPets, @"^\d+$"))
                return false;

            return true;

        }
    }


}
