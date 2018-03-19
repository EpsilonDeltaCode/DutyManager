using System;
using System.Collections.Generic;

namespace DutyFramework.Interfaces
{
    public interface IDuty
    {
        Guid Id { get; set; }

        string Titel { get; set; }

        DateTime Created { get; set; }

        DateTime LastChange { get; set; }

        DateTime DeadLine { get; set; }

        string DeadLineAsDateString { get; }

        int Progress { get; set; }

        string ProgressDescription { get; set; }

        IList<IReminder> Reminders { get; set; }

        IList<IStatement> Statements { get; set; }

        IList<IDutyConnection> Connections { get; set; }
    }
}
