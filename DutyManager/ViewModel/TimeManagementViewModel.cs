using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DutyFramework.Implementations;
using DutyFramework.Interfaces;

namespace DutyManager.ViewModel
{
    public class TimeManagementViewModel : IViewModel
    {
        private IDuty _currentDuty;

        public TimeManagementViewModel()
        {
            
        }

        public IDuty CurrentDuty
        {
            get => _currentDuty;
            set
            {
                _currentDuty = value;
                OnCurrentDutyChange();
            }
        }

        public DateTime? DeadLineDateTime
        {
            get => CurrentDuty.DeadLine;
            set
            {
                if (value != null)
                {
                    CurrentDuty.DeadLine = value.Value;
                }

                OnPropertyChanged(nameof(DeadLineDateTime));
            }
        }

        public DateTime? LastChangeDateTime
        {
            get => CurrentDuty.LastChange;
            set
            {
                if (value != null)
                {
                    CurrentDuty.LastChange = value.Value;
                }

                OnPropertyChanged(nameof(LastChangeDateTime));
            }
        }

        public int StatusProgress
        {
            get => CurrentDuty.Progress;
            set
            {
                CurrentDuty.Progress = value;
                OnPropertyChanged(nameof(StatusProgressText));
                OnPropertyChanged(nameof(StatusProgress));
            }
        }

        public string StatusProgressText
        {
            get => CurrentDuty.Progress.ToString();
            set
            {
                if (int.TryParse(value, out int newProgress))
                {
                    if (newProgress >= 0 && newProgress <= 100)
                    {
                        StatusProgress = newProgress;
                    }
                }
                OnPropertyChanged(nameof(StatusProgressText));
                OnPropertyChanged(nameof(StatusProgress));
            }
        }

        public string StatusDescription
        {
            get => CurrentDuty.ProgressDescription;
            set
            {
                CurrentDuty.ProgressDescription = value;
                OnPropertyChanged(nameof(StatusDescription));
            }
        }

        public void OnCurrentDutyChange()
        {
            OnPropertyChanged(nameof(DeadLineDateTime));
            OnPropertyChanged(nameof(LastChangeDateTime));
            OnPropertyChanged(nameof(StatusProgressText));
            OnPropertyChanged(nameof(StatusProgress));
            OnPropertyChanged(nameof(StatusDescription));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
