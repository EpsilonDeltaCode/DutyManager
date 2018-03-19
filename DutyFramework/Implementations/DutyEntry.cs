using System;
using DutyFramework.Interfaces;

namespace DutyFramework.Implementations
{
    public class DutyEntry : IDutyEntry
    {
        public DutyEntry(string title, DateTime date) : this(Guid.NewGuid(), title, GenerateDateString(date))
        {
        }

        public DutyEntry(string title, string dateString) : this(Guid.NewGuid(), title, dateString)
        {
        }

        public DutyEntry(Guid id, string title, DateTime date) : this(id, title, GenerateDateString(date))
        {
        }

        public DutyEntry(Guid id, string title, string dateString)
        {
            Id = id;
            Title = title;
            DateString = dateString;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string DateString { get; set; }

        public static string GenerateDateString(DateTime datetime)
        {
            return datetime.ToShortDateString();
        }
    }
}
