using DemoProject.Model;
using DemoProject.MVVM;
using DemoProject.View;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace DemoProject.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteItem(), canExecute => (SelectedItem != null));
        public RelayCommand SaveCommand => new RelayCommand(execute => SaveFile());
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
        private void AddItem(Item item)
        {
            Items.Add(item);
        }

        private void DeleteItem()
        {
            Items.Remove(SelectedItem);
        }

        private void SaveFile()
        {
            if (!Items.Any())
            {
                MessageBox.Show("No items to save. Cancelled");
                return;
            }

            SaveFileDialog dialogue = new SaveFileDialog();

            dialogue.Title = "Save Your File"; // Dialog title
            dialogue.DefaultExt = ".txt"; // Default file extension
            dialogue.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"; // File type filters
            dialogue.OverwritePrompt = true; // Ask if file exists

            bool? result = dialogue.ShowDialog();

            if (result == true)
            {
                string path = dialogue.FileName;

                File.WriteAllText(path, "Hello World!");

                MessageBox.Show("File saved to: " + path);
            }
            else
            {
                MessageBox.Show("Save cancelled.");
            }
        }

        private bool CanSave()
        {
            return true;
        }
        private void OpenAddDataWindow()
        {

            // Instantiate the AddDataWindowViewModel
            var addDataWindowViewModel = new AddDataWindowViewModel();

            // Subscribe to the DataSubmitted event on the ViewModel
            addDataWindowViewModel.DataSubmitted += OnDataSubmitted;

            // Create the AddDataWindow and set its DataContext
            var addDataWindow = new AddDataWindow
            {
                DataContext = addDataWindowViewModel
            };



            var mainWindow = Application.Current.MainWindow;
            addDataWindow.Owner = mainWindow;
            mainWindow.Opacity = 0.5; // Dim the main window

            // Un-dim the main window when the new window is closed
            addDataWindow.Closed += (sender, e) =>
            {
                mainWindow.Opacity = 1.0;
            };

            // Show the AddDataWindow
            addDataWindow.ShowDialog();
        }
        
        // Handle receiving data from the AddDataWindow after a
        // user clicks on the "OK" button
        private string _receivedData;

        public string ReceivedData
        {
            get { return _receivedData; }
            set
            {
                _receivedData = value;
                OnPropertyChanged(nameof(ReceivedData));
            }
        }
        private void OnDataSubmitted(string jsonString)
        {
            ReceivedData = jsonString;

            var item = JsonSerializer.Deserialize<Item>(jsonString);

            AddItem(item);
        }
    }

}
