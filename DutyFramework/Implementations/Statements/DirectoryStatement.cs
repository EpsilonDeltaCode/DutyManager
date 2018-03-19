using System;
using System.IO;
using DutyFramework.Interfaces;

namespace DutyFramework.Implementations.Statements
{
    public class DirectoryStatement : IDescribingStatement
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public DirectoryInfo Dir { get; set; }
        
    }
}
