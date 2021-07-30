using Microsoft.DataTransformationServices.Controls;
using Microsoft.SqlServer.Dts.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecureFTP
{
    public partial class SFTPMainWindow : DTSBaseTaskUI
    {
        private const string Title = "SFTP Test UI";
        private const string Description = "Displays content";
        private static Icon TaskIcon = new Icon("SecureFTP.Resources.safe.ico");
        private GeneralView generalView;
        public GeneralView GeneralView
        {
            get { return generalView; }
        }

        public SFTPMainWindow(TaskHost taskHost, object connections) :
            base(Title, TaskIcon, Description, taskHost, connections)
        {
            InitializeComponent();

            // Setup our views
            generalView = new GeneralView();
            this.DTSTaskUIHost.FastLoad = false;
            this.DTSTaskUIHost.AddView("General", generalView, null);
            this.DTSTaskUIHost.FastLoad = true;
        }
    }
}
