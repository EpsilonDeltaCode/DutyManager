using System.Collections.Generic;

namespace DutyManager.MainObjects
{
    public interface ITextBlock
    {
        IList<string> Lines { get; set; }
        string ToSingleLine();
    }
}