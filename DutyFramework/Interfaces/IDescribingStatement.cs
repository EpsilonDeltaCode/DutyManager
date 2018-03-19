using System;

namespace DutyFramework.Interfaces
{
    public interface IDescribingStatement : IStatement
    {
        string Description { get; set; }
    }
}
