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
        private Duty _currentlySelectedDuty;

        public MainViewModel()
        {
            MainDutyList = new ObservableCollection<IDuty>();
        }

        public ObservableCollection<IDuty> MainDutyList { get; set; }

        public TimeManagementViewModel CurrentTimeManagementViewModel { get; set; }

        public ReminderViewModel CurrentReminderViewModel { get; set; }

        public ConnectionsViewModel CurrentConnectionsViewModel { get; set; }


        public void OnDutyListBoxSelectionChange(object sender, SelectionChangedEventArgs e)
        {
            _currentlySelectedDuty = e.AddedItems[0] as Duty;
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
            CurrentTimeManagementViewModel.Setup();
            CurrentReminderViewModel = new ReminderViewModel();
            CurrentReminderViewModel.Setup();
            CurrentConnectionsViewModel = new ConnectionsViewModel();
            CurrentConnectionsViewModel.Setup();
        }
    }
}
