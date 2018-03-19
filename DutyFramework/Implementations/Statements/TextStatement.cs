using System;
using DutyFramework.Interfaces;

namespace DutyFramework.Implementations.Statements
{
    public class TextStatement : IDescribingStatement
    {
        public Guid Id { get; set; }

        public string Description { get; set; }
    }
}
