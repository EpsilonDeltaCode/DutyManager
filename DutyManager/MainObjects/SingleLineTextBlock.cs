using System.Collections.Generic;

namespace DutyManager.MainObjects
{
    public class SingleLineTextBlock : ITextBlock
    {
        private string _Line;

        public SingleLineTextBlock(string value)
        {
            _Line = value;
        }

        public IList<string> Lines
        {
            get => new List<string>(){ _Line };
            set => throw new System.NotImplementedException();
        }

        public string ToSingleLine()
        {
            return _Line;
        }
    }
}