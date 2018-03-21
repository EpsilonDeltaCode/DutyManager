using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutyManager.ViewModel
{
    public class ReminderViewModel : IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            throw new NotImplementedException();
        }

        public void Setup()
        {

        }
    }
}
