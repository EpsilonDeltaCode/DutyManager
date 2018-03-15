using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutyManager.MainObjects
{
    public interface IDescribingStatement : IStatement
    {
        ITextBlock Description { get; set; }
    }
}
