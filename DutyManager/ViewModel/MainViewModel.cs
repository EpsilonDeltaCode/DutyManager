using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DutyManager.MainObjects;

namespace DutyManager.ViewModel
{
    public class MainViewModel : IViewModel
    {


        private IDuty _currentSelectedDuty;
        private TimeManagementViewModel _currentTimeManagementViewModel;
        private MainWindow _currentWindow;

        public MainViewModel(MainWindow window)
        {
            _currentWindow = window;         
            _currentTimeManagementViewModel = new TimeManagementViewModel(new DefaultDuty());

            Duties = new ObservableCollection<IDuty>();
            Duties.CollectionChanged += OnDutyListChanged;

            _currentWindow.DutyListBox.ItemsSource = Duties;
            _currentWindow.TimeManagementGrind.DataContext = _currentTimeManagementViewModel;
        }

        public ObservableCollection<IDuty> Duties { get; set; }

        public void ChangeCurrentDuty(IDuty selectedDuty)
        {
            _currentTimeManagementViewModel.CurrentDuty = selectedDuty;
        }

        private void OnDutyListChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

        }



        // PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
