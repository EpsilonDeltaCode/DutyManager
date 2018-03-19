using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseConnection
{
    public class DataBaseConnectionStatusEventArgs : EventArgs
    {
        public DataBaseConnectionStatusEventArgs(DataBaseConnectionStatusFlag flag, Exception failException)
        {
            Flag = flag;
            FailException = failException;
        }

        public DataBaseConnectionStatusFlag Flag { get; set; }

        public Exception FailException { get; set; }
    }

    public enum DataBaseConnectionStatusFlag
    {
        Initialize = 1,
        Creation = 2,
        Attempt = 4,
        Connecting = 8,
        Finished = 16,
        Failed = 32,
        ElementNotFound = 64,
        UpdateFailed = 128
    }
}
