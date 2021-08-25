using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFileLibrary
{
    /// <summary>
    /// Contains method to remove the xmlns from the WinSCP
    /// log file.
    /// </summary>
    public static class XmlnsRemove
    {
        public static void Remove(string filePath)
        {
            var str = File.ReadAllText(filePath);

            str = str.Replace("xmlns=\"http://winscp.net/schema/session/1.0\"", "");

            File.WriteAllText(filePath, str);

        }
    }
}
