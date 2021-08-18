using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFileLibrary
{
    public class LogTextBuilder
    {

        public string BuildTextLog(Log log)
        {
            var text = $"{log.Dts} | {log.TransferType} | {log.Protocol} | {log.FileName} | {log.LocalPath} | {log.RemotePath} | {log.TransferResult} \r\n";
            return "fpp";
        }

        

    }
}
