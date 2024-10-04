using DemoProject.Model;
using DemoProject.MVVM;
using System.Text.RegularExpressions;

namespace DemoProject.ViewModel
{
    class AddDataWindowViewModel : ViewModelBase
    {
        public RelayCommand SubmitCommand => new RelayCommand(execute => SubmitData(), canExecute => CanSubmitData());

        //private string _numberOfPets;

        //public string NumberOfPets
        //{
        //    get { return _numberOfPets; }
        //    set {
        //        _numberOfPets = value;
        //        OnPropertyChanged();
        //        if(!Regex.IsMatch(value, @"^\d+$"))
        //        {


        //        }
        //    }
        //}

        public event Action<string> DataSubmitted;

        private string _boundName;

        public string BoundName
        {
            get { return _boundName; }
            set { _boundName = value; }
        }

        public void SubmitData()
        {
            DataSubmitted?.Invoke(BoundName);
        }

        public bool CanSubmitData()
        {
            return true;
        }
    }


}
