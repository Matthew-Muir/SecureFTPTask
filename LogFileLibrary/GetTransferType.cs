using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace LogFileLibrary
{
    public interface GetTransferType
    {
        TransferType DetermineTransferType(XPathNavigator nav);
    }
}
