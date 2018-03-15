using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutyManager.MainObjects
{
    public class NoDescriptionStatus : IStatus
    {
        public NoDescriptionStatus(int percentage)
        {
            Progress = percentage;
        }
        public int Progress { get; set; }

        public ITextBlock Description
        {
            get => new SingleLineTextBlock("");
            set => throw new InvalidOperationException("You must not add a Description to a NoDescription Status!");
        }
    }
}
