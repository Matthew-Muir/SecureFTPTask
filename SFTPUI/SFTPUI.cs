using Microsoft.SqlServer.Dts.Runtime;
using Microsoft.SqlServer.Dts.Runtime.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFTPUI
{
    public class SFTPUI : IDtsTaskUI
    {
        private TaskHost taskHostValue;

        public void Delete(System.Windows.Forms.IWin32Window parentWindow)
        {

        }

        public System.Windows.Forms.ContainerControl GetView()
        {
            return new MainForm(taskHostValue);
        }

        public void Initialize(TaskHost taskHost, IServiceProvider serviceProvider)
        {
            taskHostValue = taskHost;
        }

        public void New(System.Windows.Forms.IWin32Window parentWindow)
        {

        }
    }
}
