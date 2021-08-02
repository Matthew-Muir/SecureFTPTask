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

namespace SFTPUI
{
    public partial class MainForm : Form
    {
        private TaskHost taskHost;
        public MainForm(TaskHost taskHostValue)
        {
            InitializeComponent();
            taskHost = taskHostValue;
            
            //textBox1.Text = taskHost.Properties["FtpLocalPath"].GetValue(taskHost).ToString();
            //intTBX.Text = taskHost.Properties["ServerName"].GetValue(taskHost).ToString();
            //folderTBX.Text = taskHost.Properties["PackageFolder"].GetValue(taskHost).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            taskHost.Properties["FtpProtocolName"].SetValue(taskHost, textBox1);
            taskHost.Properties["FtpHostName"].SetValue(taskHost, textBox2);
            taskHost.Properties["FtpPortNumber"].SetValue(taskHost, textBox3);
            taskHost.Properties["FtpUserNamer"].SetValue(taskHost, textBox4);
            taskHost.Properties["FtpPassword"].SetValue(taskHost, textBox5);
            taskHost.Properties["FtpSshHostKeyFingerprint"].SetValue(taskHost, textBox6);
            taskHost.Properties["FtpOperationName"].SetValue(taskHost, textBox7);
            taskHost.Properties["FtpLocalPath"].SetValue(taskHost, textBox8);
            taskHost.Properties["FtpRemotePath"].SetValue(taskHost, textBox9);
            taskHost.Properties["FtpRemove"].SetValue(taskHost, textBox10);
        }


        //private void btnDone_Click(object sender, EventArgs e)
        //{
        //    taskHost.Properties["ServerName"].SetValue(taskHost, intTBX.Text);
        //    taskHost.Properties["PackageFolder"].SetValue(taskHost, folderTBX.Text);
        //}
    }
}