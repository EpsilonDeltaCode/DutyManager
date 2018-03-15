using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutyManager.MainObjects
{
    public class DummyDuty : IDuty
    {
        private DummyDuty(Guid id, string titel, DateTime created, DateTime lastModified, DateTime deadLine, IStatus currentStatus, IList<IReminder> reminders, IList<IStatement> statements, IList<IDutyConnection> connections)
        {
            Id = id;
            Titel = titel;
            Created = created;
            LastChange = lastModified;
            DeadLine = deadLine;
            CurrentStatus = currentStatus;
            Reminders = reminders;
            Statements = statements;
            Connections = connections;
        }

        public DummyDuty()
        {
            Id = new Guid();
            Titel = "NewTitel";
            Created = DateTime.Now;
            LastChange = DateTime.MinValue;
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
