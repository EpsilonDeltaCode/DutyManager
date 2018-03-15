using System;
using System.Collections.Generic;

namespace DutyManager.MainObjects
{
    public class DefaultDuty : IDuty
    {
        public DefaultDuty()
        {
            Id = new Guid();
            Titel = "DefaultDuty";
            Created = DateTime.Now;
            LastChange = DateTime.Now;
            DeadLine = DateTime.MaxValue;
            CurrentStatus = new NoDescriptionStatus(0);
            Reminders = new List<IReminder>();
            Statements = new List<IStatement>();
            Connections = new List<IDutyConnection>();
        }


        public Guid Id { get; set; }
        public string Titel { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastChange { get; set; }
        public DateTime DeadLine { get; set; }
        public IStatus CurrentStatus { get; set; }
        public IList<IReminder> Reminders { get; set; }
        public IList<IStatement> Statements { get; set; }
        public IList<IDutyConnection> Connections { get; set; }
    }
}