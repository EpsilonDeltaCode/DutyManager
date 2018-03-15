using System;

namespace DutyManager.MainObjects
{
    public interface IStatus
    {
        int Progress { get; set; }

        ITextBlock Description { get; set; }
    }
}