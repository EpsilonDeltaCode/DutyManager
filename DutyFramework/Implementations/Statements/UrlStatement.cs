using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DutyFramework.Interfaces;

namespace DutyFramework.Implementations.Statements
{
    public class UrlStatement : IDescribingStatement
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public string Website { get; set; }
    }
}
