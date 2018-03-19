using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DutyFramework.Interfaces;

namespace DutyFramework.Implementations
{
    public class Reminder : IReminder
    {
        public Guid Id { get; set; }
        public DateTime When { get; }
        public IDuty RespectiveDuty { get; }
    }
}
