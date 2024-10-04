using DemoProject.Model;
using DemoProject.MVVM;
using DemoProject.View;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace DemoProject.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteItem(), canExecute => (SelectedItem != null));
        public RelayCommand SaveCommand => new RelayCommand(execute => SaveItems());
        public RelayCommand OpenAddDataCommand => new RelayCommand(execute => OpenAddDataWindow());

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
        private void OpenAddDataWindow()
        {
            var mainWindow = Application.Current.MainWindow;
            var addDataWindow = new AddDataWindow();
            addDataWindow.Owner = mainWindow;

            // Dim the main window
            mainWindow.Opacity = 0.5;

            // Un-dim the main window when the new window is closed
            addDataWindow.Closed += (sender, e) =>
            {
                mainWindow.Opacity = 1.0;
            };

            addDataWindow.ShowDialog();
        }


    }

}
