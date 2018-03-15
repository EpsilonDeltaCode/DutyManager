using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using DutyManager.MainObjects;
using DutyManager.ViewModel;

namespace DutyManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel currentViewModel;
        public MainWindow()
        {
            InitializeComponent();
            currentViewModel = new MainViewModel(this);

            // DataBinding (Begin)
            ;


            // DataBinding (End)

            // Test Area

            currentViewModel.Duties.Add(new DummyDuty(){ Titel = "Dummy 1 Titel"});
            currentViewModel.Duties.Add(new DummyDuty() { Titel = "Dummy 2 Titel" });
        }

        // Event Handling (Begin)

        private void OnDutyListBoxItemSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedDuty = e.AddedItems[0] as IDuty;
            currentViewModel.ChangeCurrentDuty(selectedDuty);
        }
        // Event Handling (End)
        private void TestButton_OnClick(object sender, RoutedEventArgs e)
        {
        }
    }
}
