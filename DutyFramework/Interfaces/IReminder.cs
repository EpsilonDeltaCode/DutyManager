using System;

namespace DutyFramework.Interfaces
{
    public interface IReminder
    {
        Guid Id { get; set; }

        DateTime When { get; }

        IDuty RespectiveDuty { get; }
    }
}