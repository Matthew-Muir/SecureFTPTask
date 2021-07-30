﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.DataTransformationServices.Controls;
using System.ComponentModel;
using Microsoft.SqlServer.Dts.Runtime;
using Microsoft.SqlServer.Dts.Runtime.Design;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace SecureFTP
{
    public partial class GeneralView : UserControl, IDTSTaskUIView
    {
        
        private GeneralViewNode generalNode;

        public GeneralView()
        {
            InitializeComponent();
        }

        public void OnCommit(object taskHost)
        {
            TaskHost host = taskHost as TaskHost;
            if (host == null)
            {
                throw new ArgumentException("Argument is not a TaskHost.", "taskHost");
            }

            SFTP task = host.InnerObject as SFTP;
            if (task == null)
            {
                throw new ArgumentException("Argument is not a HelloWorldTask.", "taskHost");
            }

            host.Name = generalNode.Name;
            host.Description = generalNode.Description;

            // Task properties
            task.DisplayText = generalNode.DisplayText;
        }

        public void OnInitialize(IDTSTaskUIHost treeHost, TreeNode viewNode, object taskHost, object connections)
        {
            this.generalNode = new GeneralViewNode(taskHost as TaskHost, connections as IDtsConnectionService);
            this.propertyGrid.SelectedObject = generalNode;
        }

        public void OnLoseSelection(ref bool bCanLeaveView, ref string reason)
        {
            
        }

        public void OnSelection()
        {
            
        }

        public void OnValidate(ref bool bViewIsValid, ref string reason)
        {
            
        }

        internal class GeneralViewNode
        {
            // Properties variables
            private string displayText = string.Empty;
            private string name = string.Empty;
            private string description = string.Empty;
            private GeneralViewNode generalNode;
            internal GeneralViewNode GeneralNode
            {
                get { return generalNode; }
            }

            internal TaskHost taskHost = null;
            internal IDtsConnectionService connectionService = null;

            internal GeneralViewNode(TaskHost taskHost, IDtsConnectionService connectionService)
            {
                this.taskHost = taskHost;
                this.connectionService = connectionService;

                // Extract common values from the Task Host
                name = taskHost.Name;
                description = taskHost.Description;

                // Extract values from the task object
                SecureFTP.SFTP task = taskHost.InnerObject as SecureFTP.SFTP;
                if (task == null)
                {
                    string msg = string.Format("Type mismatch for taskHost inner object.");
                    throw new ArgumentException(msg);
                }

                displayText = task.DisplayText;
            }

            #region Properties

            [Category("General"), Description("Task name")]
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    string v = value.Trim();
                    if (string.IsNullOrEmpty(v))
                    {
                        throw new ApplicationException("Task name cannot be empty");
                    }
                    name = v;
                }
            }

            [Category("General"), Description("Task description")]
            public string Description
            {
                get
                {
                    return description;
                }
                set
                {
                    description = value.Trim();
                }
            }

            [Category("General"), Description("Text to display")]
            public string DisplayText
            {
                get
                {
                    return displayText;
                }
                set
                {
                    displayText = value;
                }
            }

            #endregion
        }
    }
}
