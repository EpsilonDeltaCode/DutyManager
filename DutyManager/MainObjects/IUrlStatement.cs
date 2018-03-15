using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutyManager.MainObjects
{
    public interface IUrlStatement : IStatement
    {
        Uri Website { get; set; }
        ITextBlock Description { get; set; }
    }
}
