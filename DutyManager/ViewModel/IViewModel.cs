using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutyManager.ViewModel
{
    public interface IViewModel : INotifyPropertyChanged
    {
        void OnPropertyChanged(string name);       
    }
}
