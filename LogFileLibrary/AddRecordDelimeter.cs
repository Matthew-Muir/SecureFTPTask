using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecureFTP;

namespace LogFileLibrary
{
    public static class AddRecordDelimeter
    {
        //run at the end of task
        //append to bottom of the file a break
        public static void AppendToEnd(string path, string text)
        {
            using (StreamWriter sw = File.AppendText(@"C:\quick\log.txt"))
            {
                sw.WriteLine(text);
            }
            
        }

    }
}
