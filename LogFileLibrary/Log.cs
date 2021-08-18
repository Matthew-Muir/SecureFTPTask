using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogFileLibrary
{
    public class Log
    {
        public string Dts { get; set; } = DateTime.Now.ToString("s");
        public TransferType TransferType { get; set; }
        public Protocol Protocol { get; set; }
        public string FileName { get; set; }
        public string LocalPath { get; set; }
        public string RemotePath { get; set; }
        public TransferResult TransferResult { get; set; }
    }

}
