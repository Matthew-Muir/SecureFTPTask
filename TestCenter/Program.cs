using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using LogFileLibrary;
using System.Xml.Linq;
using System.Xml.XPath;
using System.IO;

namespace TestCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            string logPath = @"C:\quick\";
            string xmlLogName = "xmllog.xml";


            var xmlLogExists = File.Exists(logPath + xmlLogName);
            var fLogExists = File.Exists(CreateFlogFile.CurrentLogName(logPath));

            //If the formatted log doesn't exist. Then create it.
            if (!fLogExists)
            {
                CreateFlogFile.Create(logPath);
            }

            //If the WinSCP log exists. Then proceed with XML information extraction and writing to F-log.
            if (xmlLogExists)
            {
                Log log = new Log(PrepXMLFile.ReturnNav(logPath + xmlLogName));
                UpdateRecord.AppendToEnd(CreateFlogFile.CurrentLogName(logPath), log.ToString());
                File.Delete(logPath + xmlLogName);
            }

            
            Console.ReadKey();
           
        }
    }
}
