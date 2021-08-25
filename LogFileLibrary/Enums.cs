using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFileLibrary
{
    public enum TransferType
    {
        Send,
        Receive
    }

    public enum Protocol
    {
        Sftp,
        Ftps,
        Ftp
    }

    public enum TransferResult
    {
        Success,
        Failure
    }
}
