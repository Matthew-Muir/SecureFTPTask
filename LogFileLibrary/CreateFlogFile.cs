using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFileLibrary
{
    public static class CreateFlogFile
    {
        public static void Create(string path)
        {
            var fullPath = path + "FTP_Log_" + DateTime.Now.ToString("yyyyMM") + ".txt";
            using (File.Create(fullPath))
            { }
            UpdateRecord.AppendToEnd(fullPath, ProvideColumnNamesAndStruc());
        }

        public static string CurrentLogName(string path)
        {
            return path + "FTP_Log_" + DateTime.Now.ToString("yyyyMM") + ".txt";
        }

        private static string ProvideColumnNamesAndStruc()
        {
            return "DTS|TransferType|Protocol|Filename|Destination|Result\r\n";
        }
    }
}
