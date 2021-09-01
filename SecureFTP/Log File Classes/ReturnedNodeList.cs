using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SecureFTP
{
    public class ReturnedNodeList
    {
        public XmlNodeList nodeList { get; set; }
        public TransferType transferType { get; set; }

        public ReturnedNodeList(XmlNodeList xmlNodeList, TransferType transferType)
        {
            this.nodeList = xmlNodeList;
            this.transferType = transferType;
        }
    }
}
