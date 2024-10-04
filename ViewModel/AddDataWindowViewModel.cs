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

        private string _data;

        public string Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public void SubmitData()
        {
            DataSubmitted?.Invoke(Data);
        }

        public bool CanSubmitData()
        {
            return true;
        }
    }


}
