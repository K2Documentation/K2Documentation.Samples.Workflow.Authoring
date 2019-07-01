using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SourceCode.Workflow.Design;
using System.IO;
using SourceCode.Workflow.Authoring;
using SourceCode.Framework.Deployment;
using SourceCode.Framework;
using SourceCode.Workflow.Authoring.Sample.Factory;
using SourceCode.Workflow.Management;

namespace WorkflowAuthoringSample
{
    public partial class mainForm : Form
    {
        private WorkflowManagementSamples _managementSamples;
        private bool _resetWorkflowManagementConnection;
        private const string _processManagementMessageboxTitle = "Process Management";

        public mainForm()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                using (DefaultProcess process = WorkflowAuthoringSamples.CreateSampleProcess())
                {
                    string fullFileName = Path.Combine(txtOutputLocation.Text, txtProcessName.Text + ".kprx");
                    process.SaveAs(fullFileName);
                    txtProcessFile.Text = fullFileName;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = txtOutputLocation.Text;

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtOutputLocation.Text = folderBrowserDialog.SelectedPath;
            }

        }

        private void UITextChanged(object sender, EventArgs e)
        {
            btnGo.Enabled = !string.IsNullOrEmpty(txtOutputLocation.Text) && !string.IsNullOrEmpty(txtProcessName.Text);
        }

        private void btnDeploy_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            SourceCode.Workflow.Authoring.Process process = null;
            try
            {
                process = SourceCode.Workflow.Authoring.Process.Load(txtProcessFile.Text);
                StartDeployment(process);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
                if (process != null)
                {
                    process.Dispose();
                    process = null;
                }
            }
        }

        private void btnDeployIncomplete_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            DefaultProcess process = null;
            try
            {
                process = WorkflowAuthoringSamples.CreateIncompleteProcess();
                StartDeployment(process);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
                if (process != null)
                {
                    process.Dispose();
                    process = null;
                }
            }
        }

        private void StartDeployment(SourceCode.Workflow.Authoring.Process process)
        {
            DeploymentResults results = WorkflowDeploymentSamples.DeployProcess(process);

            StringBuilder sbOutput = new StringBuilder();

            if (results.Successful)
            {
                sbOutput.AppendLine("Deployment succeeded");
                sbOutput.AppendLine("====================");
                sbOutput.AppendLine();
                foreach (string output in results.Output)
                {
                    sbOutput.AppendLine(output);
                }
            }
            else
            {
                sbOutput.AppendLine("Deployment failed");
                sbOutput.AppendLine("=================");
                sbOutput.AppendLine();
                for (int i = 0; i < results.Errors.Count; i++)
                {
                    sbOutput.AppendLine(results.Errors[i].ToString());
                }
            }

            txtDeploymentResults.Text = sbOutput.ToString();
        }

        private void txtProcessFile_TextChanged(object sender, EventArgs e)
        {
            btnDeploy.Enabled = !string.IsNullOrEmpty(txtProcessFile.Text);
        }

        private void btnBrowseProcessFile_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = txtProcessFile.Text;
            openFileDialog.CheckFileExists = true;
            openFileDialog.Filter = "*.kprx|*.kprx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtProcessFile.Text = openFileDialog.FileName;
            }
        }


        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_managementSamples != null)
            {
                _managementSamples.Dispose();
                _managementSamples = null;
            }
        }

        public WorkflowManagementSamples ManagementSamples
        {
            get
            {
                if (_resetWorkflowManagementConnection)
                {
                    _managementSamples.Dispose();
                    _managementSamples = null;
                    _resetWorkflowManagementConnection = false;
                }

                if (_managementSamples == null)
                {
                    _managementSamples = new WorkflowManagementSamples();
                    _managementSamples.Host = txtHostName.Text;
                    _managementSamples.Port = int.Parse(txtPort.Text);
                }

                return _managementSamples;
            }
        }

        private void btnUpdateAdminPerm_Click(object sender, EventArgs e)
        {
            try
            {
                if (!WarnIfLoggedOnUser(txtPermUserName.Text))
                    return;

                // Update
                ManagementSamples.UpdateAdminPermissions(txtPermUserName.Text, chkPermAdmin.Checked, chkPermExport.Checked, chkPermCanImpersonate.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool WarnIfLoggedOnUser(string userName)
        {
            // Try and determine if the current logged on user
            // is the same one trying to update permissions
            // and warn the user about it.
            if (!string.IsNullOrEmpty(userName))
            {
                string fullUserName = string.Format("{0}\\{1}", System.Environment.UserDomainName, System.Environment.UserName);
                string[] nameParts = userName.Split(':');
                if (nameParts.Length > 0)
                {
                    string permUserName = nameParts[nameParts.Length - 1];

                    if (string.Compare(fullUserName, permUserName, true) == 0)
                    {
                        if (MessageBox.Show(string.Format("You will be updating rights for the current logged on user '{0}'.\nDo you want to continue?", fullUserName), _processManagementMessageboxTitle, MessageBoxButtons.YesNo) == DialogResult.No)
                            return false;
                    }
                }
            }

            return true;
        }


        private void btnUpdateProcPerm_Click(object sender, EventArgs e)
        {
            try
            {
                if (!WarnIfLoggedOnUser(txtProcMngUserName.Text))
                    return;

                ManagementSamples.UpdateProcessPermissions(txtProcMngUserName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnProcDataMng_Click(object sender, EventArgs e)
        {
            try
            {
                ManagementSamples.ProcessData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnWorklistItemMng_Click(object sender, EventArgs e)
        {
            try
            {
                ManagementSamples.WorklistItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnActionInstMng_Click(object sender, EventArgs e)
        {
            try
            {
                ManagementSamples.ActionInstanceRights();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnActionMng_Click(object sender, EventArgs e)
        {
            try
            {
                ManagementSamples.ActionRights();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextChangedForWorkflowManagement(object sender, EventArgs e)
        {
            _resetWorkflowManagementConnection = true;
        }

    }
}