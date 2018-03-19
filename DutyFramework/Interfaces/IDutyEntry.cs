using System;

namespace DutyFramework.Interfaces
{
    public interface IDutyEntry
    {
        Guid Id { get; set; }

        string Title { get; set; }

        string DateString { get; set; }
    }
}
