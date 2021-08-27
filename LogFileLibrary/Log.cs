using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace LogFileLibrary
{
    public class Log
    {
        public string Dts { get; set; }
        public TransferType TransferType { get; set; }
        public Protocol Protocol { get; set; }
        public string FileName { get; set; }
        public string LocalPath { get; set; }
        public string RemotePath { get; set; }
        public TransferResult TransferResult { get; set; }

        public Log(XPathNavigator nav)
        {
            this.Dts = nav.SelectSingleNode("/session/@start").Value.Substring(0,19);
            this.TransferType = DetermineTransferType(nav);
            this.Protocol = DetermineTransferProtocol(nav);
            this.FileName = ExtractFileName(nav);
            this.LocalPath = ExtractLocalPath(nav);
            this.RemotePath = nav.SelectSingleNode("/session/group[2]/cwd/cwd/@value").Value;
            this.TransferResult = DetermineTransferResult(nav);
        }

        public override string ToString()
        {
            return $"{this.Dts}|{this.TransferType}|{this.Protocol}|{this.FileName}|{this.LocalPath}|{this.RemotePath}|{this.TransferResult}\r\n";

        }

        private TransferType DetermineTransferType(XPathNavigator nav)
        {
            if(nav.SelectSingleNode("/session/group[3]/upload") != null)
            {
                return TransferType.Send;
            }
            else
            {
                return TransferType.Receive;
            }
        }

        private Protocol DetermineTransferProtocol(XPathNavigator nav)
        {
            var valueString = nav.SelectSingleNode("/session/group[1]/@name").Value;

            if (valueString.Contains("sftp"))
            {
                return Protocol.Sftp;
            }
            else if(valueString.Contains("ftps"))
            {
                return Protocol.Ftps;
            }
            else
            {
                return Protocol.Ftp;
            }
        }

        private string ExtractFileName(XPathNavigator nav)
        {
            var attString = nav.SelectSingleNode("/session/group[3]/upload/filename/@value").Value;
            return attString.Substring(attString.LastIndexOf('\\') + 1);
        }

        private string ExtractLocalPath(XPathNavigator nav)
        {
            var attStr = nav.SelectSingleNode("/session/group[3]/upload/filename/@value").Value;
            return attStr.Substring(0, attStr.LastIndexOf('\\') + 1);
        }

        private TransferResult DetermineTransferResult(XPathNavigator nav)
        {
            var result = nav.SelectSingleNode("/session/group[2]/cwd/result/@success").Value;

            if (result == "true")
            {
                return TransferResult.Success;
            }
            else
            {
                return TransferResult.Failure;
            }
        }
    }

}
