using DemoProject.Model;
using DemoProject.MVVM;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace DemoProject.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        public RelayCommand AddCommand => new RelayCommand(execute => AddItem());
        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteItem(), canExecute => (SelectedItem != null));
        public RelayCommand SaveCommand => new RelayCommand(execute => SaveItems());

        // Items are bound to a DataGrid in the MainWindow
        public ObservableCollection<Item> Items { get; set; }

        public MainWindowViewModel()
        {
            // Initialize our Items collection
            Items = new ObservableCollection<Item>();
        }

        // The SelectedItem is bound to the selected item in our MainWindow DataGrid
        private Item _selectedItem;
        public Item SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }
        private void AddItem()
        {
            Items.Add(new Item
            {
                Name = "Mark",
                FavoriteNumber = 13,
                Birthday = new DateOnly(1986, 10, 4)
            });
        }
        private void DeleteItem()
        {
            Items.Remove(SelectedItem);
        }
        private void SaveItems()
        {
            throw new NotImplementedException();
        }

        private bool CanSave()
        {
            return true;
        }

    }

}
