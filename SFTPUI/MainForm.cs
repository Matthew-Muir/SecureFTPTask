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

            #region Populate_Form_Fields
            textBox1.Text = taskHost.Properties["FtpProtocolName"].GetValue(taskHost).ToString();
            textBox2.Text = taskHost.Properties["FtpHostName"].GetValue(taskHost).ToString();
            textBox3.Text = taskHost.Properties["FtpPortNumber"].GetValue(taskHost).ToString();
            textBox4.Text = taskHost.Properties["FtpUserName"].GetValue(taskHost).ToString();
            textBox5.Text = taskHost.Properties["FtpPassword"].GetValue(taskHost).ToString();
            textBox6.Text = taskHost.Properties["FtpSshHostKeyFingerprint"].GetValue(taskHost).ToString();
            textBox7.Text = taskHost.Properties["FtpOperationName"].GetValue(taskHost).ToString();
            textBox8.Text = taskHost.Properties["FtpLocalPath"].GetValue(taskHost).ToString();
            textBox9.Text = taskHost.Properties["FtpRemotePath"].GetValue(taskHost).ToString();
            textBox10.Text = taskHost.Properties["FtpRemove"].GetValue(taskHost).ToString();
            #endregion

            #region Populate_Tooltips

            toolTip1.SetToolTip(label1, "SFTP");
            toolTip2.SetToolTip(label2, "localhost");
            toolTip3.SetToolTip(label3, "SFTP port number 22");
            toolTip4.SetToolTip(label4, "Login credential to access server");
            toolTip5.SetToolTip(label5, "Login credential to access server");
            toolTip6.SetToolTip(label6, "This credential should be provided to you by server the admin.\nElse connect to server via WinSCP app and obtain credential from Session->Server/Protocol Info");
            toolTip7.SetToolTip(label7, "GetFiles (download files from server)\nPutFiles (Upload files to server)");
            toolTip8.SetToolTip(label8, "File location on local machine.");
            toolTip9.SetToolTip(label9, "Path to destination on server");
            toolTip10.SetToolTip(label10, "True or False. This option will delete source files/directory after transfer");

            #endregion


        }

        private void button1_Click(object sender, EventArgs e)
        {
            taskHost.Properties["FtpProtocolName"].SetValue(taskHost, textBox1.Text);
            taskHost.Properties["FtpHostName"].SetValue(taskHost, textBox2.Text);
            taskHost.Properties["FtpPortNumber"].SetValue(taskHost, Int32.Parse(textBox3.Text));
            taskHost.Properties["FtpUserName"].SetValue(taskHost, textBox4.Text);
            taskHost.Properties["FtpPassword"].SetValue(taskHost, textBox5.Text);
            taskHost.Properties["FtpSshHostKeyFingerprint"].SetValue(taskHost, textBox6.Text);
            taskHost.Properties["FtpOperationName"].SetValue(taskHost, textBox7.Text);
            taskHost.Properties["FtpLocalPath"].SetValue(taskHost, textBox8.Text);
            taskHost.Properties["FtpRemotePath"].SetValue(taskHost, textBox9.Text);
            taskHost.Properties["FtpRemove"].SetValue(taskHost, Boolean.Parse(textBox10.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            helpForm.Show();
        }
    }
}