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
            comboBox1.SelectedIndex = comboBox1.FindStringExact(taskHost.Properties["FtpRemove"].GetValue(taskHost).ToString());
            comboBox2.SelectedIndex = comboBox2.FindStringExact(taskHost.Properties["FtpOperationName"].GetValue(taskHost).ToString());
            textBox2.Text = taskHost.Properties["FtpHostName"].GetValue(taskHost).ToString();
            numericUpDown1.Value = Int32.Parse(taskHost.Properties["FtpPortNumber"].GetValue(taskHost).ToString());
            textBox4.Text = taskHost.Properties["FtpUserName"].GetValue(taskHost).ToString();
            textBox5.Text = taskHost.Properties["FtpPassword"].GetValue(taskHost).ToString();
            textBox6.Text = taskHost.Properties["FtpSshHostKeyFingerprint"].GetValue(taskHost).ToString();
            textBox8.Text = taskHost.Properties["FtpLocalPath"].GetValue(taskHost).ToString();
            textBox9.Text = taskHost.Properties["FtpRemotePath"].GetValue(taskHost).ToString();
            textBox1.Text = taskHost.Properties["FtpLogPath"].GetValue(taskHost).ToString();
            textBox3.Text = taskHost.Properties["FtpExePath"].GetValue(taskHost).ToString();
            #endregion

            #region Populate_Tooltips


            toolTip2.SetToolTip(label2, "Ip address or URL ftp.example.com");
            toolTip3.SetToolTip(label3, "SFTP default port number is 22");
            toolTip4.SetToolTip(label4, "Login credential to access server");
            toolTip5.SetToolTip(label5, "Login credential to access server");
            toolTip6.SetToolTip(label6, "This credential should be provided to you by server the admin.\nElse connect to server via WinSCP app and obtain credential from Session->Server/Protocol Info");
            toolTip7.SetToolTip(label7, "GetFiles (download files from server)\nPutFiles (Upload files to server)");
            toolTip8.SetToolTip(label8, "File location on local machine.\nE.G. C:\\folder\\myfile.txt\nAutomatically select the most recently written file in the directory by using L@TEST keyword\nOr Transfer an entire directory E.G. C:\\folder\nThis field can accept wild card expression.\nRead help for more details.");
            toolTip9.SetToolTip(label9, "Path to destination on server\nE.G. / to access root \n/myfolder/ to access a particular directory");
            toolTip10.SetToolTip(label10, "Delete source files/directory after transfer?");
            toolTip11.SetToolTip(label1, "Output path for log files. Leave blank to turn off logging");
            toolTip12.SetToolTip(label11, "This field is optional.\nIt's value can be set to point to a WinSCP exe");

            #endregion


        }

        //Done button - Update taskHost values
        private void button1_Click(object sender, EventArgs e)
        {

            
            taskHost.Properties["FtpHostName"].SetValue(taskHost, textBox2.Text);
            taskHost.Properties["FtpPortNumber"].SetValue(taskHost, (int)numericUpDown1.Value);
            taskHost.Properties["FtpUserName"].SetValue(taskHost, textBox4.Text);
            taskHost.Properties["FtpPassword"].SetValue(taskHost, textBox5.Text);
            taskHost.Properties["FtpSshHostKeyFingerprint"].SetValue(taskHost, textBox6.Text);
            taskHost.Properties["FtpOperationName"].SetValue(taskHost, comboBox2.Text);
            taskHost.Properties["FtpLocalPath"].SetValue(taskHost, textBox8.Text);
            taskHost.Properties["FtpRemotePath"].SetValue(taskHost, textBox9.Text);
            taskHost.Properties["FtpRemove"].SetValue(taskHost, Boolean.Parse(comboBox1.Text));
            taskHost.Properties["FtpLogPath"].SetValue(taskHost, textBox1.Text);
            taskHost.Properties["FtpExePath"].SetValue(taskHost, textBox3.Text);
            
        }



        private void button3_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            helpForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Select File",
                CheckFileExists = true,
                CheckPathExists = true,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox8.Text = openFileDialog1.FileName;
            }
        }

        //Browse button for selecting log path
        private void button5_Click(object sender, EventArgs e)
        {
            var folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() ==  DialogResult.OK)
            {
                textBox1.Text = folderBrowser.SelectedPath + "\\";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Select File",
                CheckFileExists = true,
                CheckPathExists = true,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = openFileDialog1.FileName;
            }
        }
    }
}