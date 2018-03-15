using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DutyManager.MainObjects
{
    public interface IDuty
    {
        Guid Id { get; set; }
        string Titel { get; set; }
        DateTime Created { get; set; }
        DateTime LastChange { get; set; }
        DateTime DeadLine { get; set; }
        IStatus CurrentStatus { get; set; }
        IList<IReminder> Reminders { get; set; }
        IList<IStatement> Statements { get; set; }
        IList<IDutyConnection> Connections { get; set; }
    }
}
