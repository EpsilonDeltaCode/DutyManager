using System;
using System.Collections.Generic;
using DutyFramework.Interfaces;

namespace DutyFramework.Implementations
{
    public class DummyDuty : Duty
    {
        public DummyDuty() : this("ParameterlessConstructorGeneratedDummyDuty")
        {
        }

        public DummyDuty(string title)
        {
            Id = new Guid();
            Titel = title;
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
