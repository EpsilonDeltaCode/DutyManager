using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DutyFramework.Implementations;
using DutyFramework.Interfaces;

namespace DutyManager.ViewModel
{
    public class TimeManagementViewModel : IViewModel
    {
        private DateTime? _deadLine;
        private DateTime? _lastChange;
        private string _progressDescription;

        public TimeManagementViewModel()
        {
            
        }

        public DateTime? DeadLine
        {
            get => _deadLine;
            set
            {
                if (value != null)
                    _deadLine = value.Value;
                else
                    MiniLogger.LoggerWindow.AddEntry("Error", "Try to set local DeadLine with a value=null");
                
                OnPropertyChanged(nameof(DeadLine));
            }
        }

        public DateTime? LastChange
        {
            get => _lastChange;
            private set
            {
                if (value != null)
                    _lastChange = value.Value;
                else
                    MiniLogger.LoggerWindow.AddEntry("Error", "Try to set local LastChange with a value=null");

                OnPropertyChanged(nameof(LastChange));
            }
        }

        public int Progress { get; private set; }

        public string ProgressText
        {
            get => Progress.ToString();
            set
            {
                if (int.TryParse(value, out int newProgress))
                {
                    if (newProgress >= 0 && newProgress <= 100)
                    {
                        Progress = newProgress;
                    }
                }
                OnPropertyChanged(nameof(ProgressText));
                OnPropertyChanged(nameof(Progress));
            }
        }

        public string ProgressDescription
        {
            get => _progressDescription;
            set
            {
                _progressDescription = value;
                OnPropertyChanged(nameof(ProgressDescription));
            }
        }

        public void Setup()
        {
            DeadLine = DateTime.Now;
            LastChange = DateTime.Now;
            ProgressText = "";
            ProgressDescription = "";
        }


        public void OnDutyListBoxSelectionChange(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems[0] is Duty selectedDuty)
            {
                DeadLine = selectedDuty.DeadLine;
                LastChange = selectedDuty.LastChange;
                ProgressText = selectedDuty.Progress.ToString();
                ProgressDescription = selectedDuty.ProgressDescription;
            }
            else
            {
                MiniLogger.LoggerWindow.AddEntry("Error", "Try to set local Properties from \"SelectionChangedEventArgs.AddedItems[0] as Duty\"=null");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
