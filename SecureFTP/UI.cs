using Microsoft.SqlServer.Dts.Runtime;
using Microsoft.SqlServer.Dts.Runtime.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecureFtp
{
    public class UI : IDtsTaskUI
    {
        private TaskHost _taskHost = null;
        private IDtsConnectionService _connectionService = null;

        public void Delete(System.Windows.Forms.IWin32Window parentWindow)
        {
           
        }

        public ContainerControl GetView()
        {
            return new SecureFTP.SFTPMainWindow(_taskHost, _connectionService);
        }

        public void Initialize(TaskHost taskHost, IServiceProvider serviceProvider)
        {
            this._taskHost = taskHost;
            this._connectionService = serviceProvider.GetService(typeof(IDtsConnectionService)) as IDtsConnectionService;
        }

        public void New(System.Windows.Forms.IWin32Window parentWindow)
        {
            
        }
    }
}
