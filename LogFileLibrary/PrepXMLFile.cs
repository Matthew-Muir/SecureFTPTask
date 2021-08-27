using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace LogFileLibrary
{
    public static class PrepXMLFile
    {
        public static XPathNavigator ReturnNav(string path)
        {
            XmlnsRemove.Remove(path);

            XPathDocument xmlDoc = new XPathDocument(path);

            XPathNavigator nav = xmlDoc.CreateNavigator();

            return nav;

        }
    }
}
