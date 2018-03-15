using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DutyManager.MainObjects;

namespace DutyManager.ViewModel
{
    public class TimeManagementViewModel : IViewModel
    {
        private IDuty _currentDuty;

        public TimeManagementViewModel(IDuty currentDuty)
        {
            CurrentDuty = currentDuty;
        }

        public IDuty CurrentDuty
        {
            get => _currentDuty;
            set
            {
                _currentDuty = value;
                OnPropertyChanged(nameof(DeadLineDateTime));
                OnPropertyChanged(nameof(LastChangeDateTime));
                OnPropertyChanged(nameof(StatusProgressText));
                OnPropertyChanged(nameof(StatusProgress));
                OnPropertyChanged(nameof(StatusDescription));
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
            get => CurrentDuty.CurrentStatus.Progress;
            set
            {
                CurrentDuty.CurrentStatus.Progress = value;
                OnPropertyChanged(nameof(StatusProgressText));
                OnPropertyChanged(nameof(StatusProgress));
            }
        }

        public string StatusProgressText
        {
            get => CurrentDuty.CurrentStatus.Progress.ToString();
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
            get => CurrentDuty.CurrentStatus.Description.ToSingleLine();
            set
            {
                CurrentDuty.CurrentStatus.Description = new SingleLineTextBlock(value);
                OnPropertyChanged(nameof(StatusDescription));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
