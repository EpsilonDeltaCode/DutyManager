using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DutyFramework.Implementations;
using DutyFramework.Interfaces;

namespace DutyManager.ViewModel
{
    public class MainViewModel : IViewModel
    {
        private IDuty _currentDuty;

        public MainViewModel()
        {
            Setup();
            MainDutyList = new ObservableCollection<IDuty>();
            CurrentDuty = new DefaultDuty();
        }

        public ObservableCollection<IDuty> MainDutyList { get; set; }

        public IDuty CurrentDuty
        {
            get => _currentDuty;
            set
            {
                _currentDuty = value;
                CurrentTimeManagementViewModel.CurrentDuty = value;
                //CurrentReminderViewModel.CurrentDuty = value;
                //CurrentConnectionsViewModel.CurrentDuty = value;
            }
        }

        public TimeManagementViewModel CurrentTimeManagementViewModel { get; set; }

        public ReminderViewModel CurrentReminderViewModel { get; set; }

        public ConnectionsViewModel CurrentConnectionsViewModel { get; set; }


        public void OnDutyListBoxSelectionChange(object sender, SelectionChangedEventArgs e)
        {
            CurrentDuty = e.AddedItems[0] as IDuty;
        }


        // PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void Setup()
        {
            CurrentTimeManagementViewModel = new TimeManagementViewModel();
            CurrentReminderViewModel = new ReminderViewModel();
            CurrentConnectionsViewModel = new ConnectionsViewModel();
        }
    }
}
