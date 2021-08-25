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
            var str = @"C:\quick\xmllog.xml";
            var outLog = @"C:\quick\Flog.txt";

            var xmlLogExists = File.Exists(str + xmlLogName);
            var fLogExists = File.Exists(CreateFlogFile.CurrentLogName(logPath));

            //If the formatted log doesn't exist. Then create it.
            if (!fLogExists)
            {
                CreateFlogFile.Create(logPath);
            }

            //If the WinSCP log exists. Then proceed with XML information extraction and writing to F-log.
            if (xmlLogExists)
            {
                //LEFT OFF HERE 
            }

            

            XmlnsRemove.Remove(str);




            XPathDocument docNav = new XPathDocument(str);
            XPathNavigator nav = docNav.CreateNavigator();

            var log = new Log(nav);

            UpdateRecord.AppendToEnd(outLog, log.ToString());

            
            Console.ReadKey();
           
        }
    }
}
