using System;
using System.Collections.Generic;
using DutyFramework.Interfaces;

namespace DutyFramework.Implementations
{
    public class Duty : IDuty
    {
        public Guid Id { get; set; }

        public string Titel { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastChange { get; set; }

        public DateTime DeadLine { get; set; }
        public string DeadLineAsDateString => DeadLine.ToShortDateString();

        public int Progress { get; set; }

        public string ProgressDescription { get; set; }

        public IList<IReminder> Reminders { get; set; }

        public IList<IStatement> Statements { get; set; }

        public IList<IDutyConnection> Connections { get; set; }
    }
}
