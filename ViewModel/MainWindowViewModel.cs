using DemoProject.Model;
using DemoProject.MVVM;
using System.Collections.ObjectModel;

namespace DemoProject.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Items = new ObservableCollection<Item>();
            Items.Add(new Item
            {
                Name = "Wendy",
                FavoriteNumber = 22,
                Birthday = new DateOnly(1955, 7, 28)
            });
            Items.Add(new Item
            {
                Name = "Mark",
                FavoriteNumber = 13,
                Birthday = new DateOnly(1986, 10, 4)
            });
            Items.Add(new Item
            {
                Name = "Crystal",
                FavoriteNumber = 7,
                Birthday = new DateOnly(1986, 7, 19)
            });
        }

        // Items are bound to a DataGrid in the MainWindow
        public ObservableCollection<Item> Items { get; set; }

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


    }

}
