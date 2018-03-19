using System;
using System.Collections.Generic;
using DutyFramework.Interfaces;

namespace DutyFramework.Implementations
{
    public class DefaultDuty : Duty
    {
        public DefaultDuty()
        {
            Id = new Guid();
            Titel = "DefaultDutyTitel";
            Created = DateTime.Now;
            LastChange = DateTime.Now;
            DeadLine = DateTime.MaxValue;
            Progress = 0;
            ProgressDescription = "";
            Reminders = new List<IReminder>();
            Statements = new List<IStatement>();
            Connections = new List<IDutyConnection>();
        }
    }
}