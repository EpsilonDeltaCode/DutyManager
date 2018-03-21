using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DutyFramework.Implementations;
using DutyFramework.Interfaces;
using DutyManager.ViewModel;

namespace DutyManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        

        public MainWindow()
        {
            InitializeComponent();

            MiniLogger.LoggerWindow.ShowWindow();

            CurrentMainViewModel = new MainViewModel();
            CurrentMainViewModel.Setup();
            CurrentDataManager = new DataManager(CurrentMainViewModel);
            CurrentDataManager.Setup();

            TimeManagementGrid.DataContext = CurrentMainViewModel.CurrentTimeManagementViewModel;
            RemindersGrid.DataContext = CurrentMainViewModel.CurrentReminderViewModel;
            ConnectionsGrid.DataContext = CurrentMainViewModel.CurrentConnectionsViewModel;

            DutyListGrid.DataContext = CurrentMainViewModel;
            //DutyListBox.DataContext = CurrentMainViewModel;
            DutyListBox.SelectionChanged += CurrentMainViewModel.OnDutyListBoxSelectionChange;
            DutyListBox.SelectionChanged += CurrentMainViewModel.CurrentTimeManagementViewModel.OnDutyListBoxSelectionChange;
        }

        public MainViewModel CurrentMainViewModel { get; set; }

        public DataManager CurrentDataManager { get; set; }






        // Event Handling (Begin)


        /*
        private void OnDutyListBoxSelectionChange(object sender, SelectionChangedEventArgs e)
        {
            var selectedDuty = e.AddedItems[0] as IDuty;
            CurrentMainViewModel.CurrentDuty = selectedDuty;
        }


            SelectionChanged="OnDutyListBoxSelectionChange"

        */


        // Event Handling (End)
        private void TestButton_OnClick(object sender, RoutedEventArgs e)
        {
            CurrentMainViewModel.MainDutyList.Add(new DummyDuty("ButtonAddedDuty"));
            Debug.WriteLine("Button Clicked");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
