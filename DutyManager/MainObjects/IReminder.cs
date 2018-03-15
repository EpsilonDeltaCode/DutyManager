using System;

namespace DutyManager.MainObjects
{
    public interface IReminder
    {
        DateTime When { get; }

        IDuty RespectiveDuty { get; }
    }
}