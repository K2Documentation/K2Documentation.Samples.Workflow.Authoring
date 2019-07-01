namespace WorkflowAuthoringSample
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGo = new System.Windows.Forms.Button();
            this.txtOutputLocation = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblOutputLocation = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.txtProcessName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnDeployIncomplete = new System.Windows.Forms.Button();
            this.lblProcessFile = new System.Windows.Forms.Label();
            this.txtProcessFile = new System.Windows.Forms.TextBox();
            this.btnBrowseProcessFile = new System.Windows.Forms.Button();
            this.lblDeploymentResults = new System.Windows.Forms.Label();
            this.txtDeploymentResults = new System.Windows.Forms.TextBox();
            this.btnDeploy = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtHostName = new System.Windows.Forms.TextBox();
            this.lblServerPort = new System.Windows.Forms.Label();
            this.lblHostName = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.chkPermExport = new System.Windows.Forms.CheckBox();
            this.chkPermCanImpersonate = new System.Windows.Forms.CheckBox();
            this.chkPermAdmin = new System.Windows.Forms.CheckBox();
            this.txtPermUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUpdateAdminPerm = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.txtProcMngUserName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnUpdateProcPerm = new System.Windows.Forms.Button();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.btnActionMng = new System.Windows.Forms.Button();
            this.btnActionInstMng = new System.Windows.Forms.Button();
            this.btnWorklistItemMng = new System.Windows.Forms.Button();
            this.btnProcDataMng = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Enabled = false;
            this.btnGo.Location = new System.Drawing.Point(6, 167);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "&Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtOutputLocation
            // 
            this.txtOutputLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputLocation.BackColor = System.Drawing.SystemColors.Window;
            this.txtOutputLocation.Location = new System.Drawing.Point(6, 85);
            this.txtOutputLocation.Name = "txtOutputLocation";
            this.txtOutputLocation.ReadOnly = true;
            this.txtOutputLocation.Size = new System.Drawing.Size(402, 20);
            this.txtOutputLocation.TabIndex = 2;
            this.txtOutputLocation.TextChanged += new System.EventHandler(this.UITextChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(414, 85);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(27, 20);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblOutputLocation
            // 
            this.lblOutputLocation.AutoSize = true;
            this.lblOutputLocation.Location = new System.Drawing.Point(6, 69);
            this.lblOutputLocation.Name = "lblOutputLocation";
            this.lblOutputLocation.Size = new System.Drawing.Size(116, 13);
            this.lblOutputLocation.TabIndex = 1;
            this.lblOutputLocation.Text = "Project output location:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(435, 66);
            this.label1.TabIndex = 0;
            this.label1.Text = "This workflow authoring sample will create a simple approval process to the speci" +
                "fied output location.\r\n- Browse for a location to create the project.\r\n- Click \"" +
                "Go\" to create the project.";
            // 
            // txtProcessName
            // 
            this.txtProcessName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProcessName.Location = new System.Drawing.Point(6, 124);
            this.txtProcessName.Name = "txtProcessName";
            this.txtProcessName.Size = new System.Drawing.Size(402, 20);
            this.txtProcessName.TabIndex = 5;
            this.txtProcessName.Text = "Approval Process Sample";
            this.txtProcessName.TextChanged += new System.EventHandler(this.UITextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Process name:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(460, 324);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnGo);
            this.tabPage1.Controls.Add(this.txtProcessName);
            this.tabPage1.Controls.Add(this.txtOutputLocation);
            this.tabPage1.Controls.Add(this.btnBrowse);
            this.tabPage1.Controls.Add(this.lblOutputLocation);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(452, 298);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Process Authoring";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnDeployIncomplete);
            this.tabPage2.Controls.Add(this.lblProcessFile);
            this.tabPage2.Controls.Add(this.txtProcessFile);
            this.tabPage2.Controls.Add(this.btnBrowseProcessFile);
            this.tabPage2.Controls.Add(this.lblDeploymentResults);
            this.tabPage2.Controls.Add(this.txtDeploymentResults);
            this.tabPage2.Controls.Add(this.btnDeploy);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(452, 298);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Process Deployment";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnDeployIncomplete
            // 
            this.btnDeployIncomplete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeployIncomplete.Location = new System.Drawing.Point(9, 269);
            this.btnDeployIncomplete.Name = "btnDeployIncomplete";
            this.btnDeployIncomplete.Size = new System.Drawing.Size(222, 23);
            this.btnDeployIncomplete.TabIndex = 7;
            this.btnDeployIncomplete.Text = "&Try to deploy an incomplete process";
            this.btnDeployIncomplete.UseVisualStyleBackColor = true;
            this.btnDeployIncomplete.Click += new System.EventHandler(this.btnDeployIncomplete_Click);
            // 
            // lblProcessFile
            // 
            this.lblProcessFile.AutoSize = true;
            this.lblProcessFile.Location = new System.Drawing.Point(6, 7);
            this.lblProcessFile.Name = "lblProcessFile";
            this.lblProcessFile.Size = new System.Drawing.Size(64, 13);
            this.lblProcessFile.TabIndex = 6;
            this.lblProcessFile.Text = "Process file:";
            // 
            // txtProcessFile
            // 
            this.txtProcessFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProcessFile.BackColor = System.Drawing.SystemColors.Window;
            this.txtProcessFile.Location = new System.Drawing.Point(9, 23);
            this.txtProcessFile.Name = "txtProcessFile";
            this.txtProcessFile.ReadOnly = true;
            this.txtProcessFile.Size = new System.Drawing.Size(402, 20);
            this.txtProcessFile.TabIndex = 4;
            this.txtProcessFile.TextChanged += new System.EventHandler(this.txtProcessFile_TextChanged);
            // 
            // btnBrowseProcessFile
            // 
            this.btnBrowseProcessFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseProcessFile.Location = new System.Drawing.Point(417, 23);
            this.btnBrowseProcessFile.Name = "btnBrowseProcessFile";
            this.btnBrowseProcessFile.Size = new System.Drawing.Size(27, 20);
            this.btnBrowseProcessFile.TabIndex = 5;
            this.btnBrowseProcessFile.Text = "...";
            this.btnBrowseProcessFile.UseVisualStyleBackColor = true;
            this.btnBrowseProcessFile.Click += new System.EventHandler(this.btnBrowseProcessFile_Click);
            // 
            // lblDeploymentResults
            // 
            this.lblDeploymentResults.AutoSize = true;
            this.lblDeploymentResults.Location = new System.Drawing.Point(6, 81);
            this.lblDeploymentResults.Name = "lblDeploymentResults";
            this.lblDeploymentResults.Size = new System.Drawing.Size(104, 13);
            this.lblDeploymentResults.TabIndex = 2;
            this.lblDeploymentResults.Text = "Deployment Results:";
            // 
            // txtDeploymentResults
            // 
            this.txtDeploymentResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeploymentResults.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeploymentResults.Location = new System.Drawing.Point(6, 97);
            this.txtDeploymentResults.Multiline = true;
            this.txtDeploymentResults.Name = "txtDeploymentResults";
            this.txtDeploymentResults.Size = new System.Drawing.Size(440, 166);
            this.txtDeploymentResults.TabIndex = 1;
            // 
            // btnDeploy
            // 
            this.btnDeploy.Enabled = false;
            this.btnDeploy.Location = new System.Drawing.Point(9, 49);
            this.btnDeploy.Name = "btnDeploy";
            this.btnDeploy.Size = new System.Drawing.Size(75, 23);
            this.btnDeploy.TabIndex = 0;
            this.btnDeploy.Text = "&Deploy";
            this.btnDeploy.UseVisualStyleBackColor = true;
            this.btnDeploy.Click += new System.EventHandler(this.btnDeploy_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.tabControl2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(452, 298);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Process Management";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtHostName);
            this.groupBox1.Controls.Add(this.lblServerPort);
            this.groupBox1.Controls.Add(this.lblHostName);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 72);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server Settings";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(79, 41);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "5555";
            this.txtPort.TextChanged += new System.EventHandler(this.TextChangedForWorkflowManagement);
            // 
            // txtHostName
            // 
            this.txtHostName.Location = new System.Drawing.Point(79, 19);
            this.txtHostName.Name = "txtHostName";
            this.txtHostName.Size = new System.Drawing.Size(345, 20);
            this.txtHostName.TabIndex = 1;
            this.txtHostName.Text = "localhost";
            this.txtHostName.TextChanged += new System.EventHandler(this.TextChangedForWorkflowManagement);
            // 
            // lblServerPort
            // 
            this.lblServerPort.AutoSize = true;
            this.lblServerPort.Location = new System.Drawing.Point(6, 48);
            this.lblServerPort.Name = "lblServerPort";
            this.lblServerPort.Size = new System.Drawing.Size(29, 13);
            this.lblServerPort.TabIndex = 2;
            this.lblServerPort.Text = "Port:";
            // 
            // lblHostName
            // 
            this.lblHostName.AutoSize = true;
            this.lblHostName.Location = new System.Drawing.Point(6, 22);
            this.lblHostName.Name = "lblHostName";
            this.lblHostName.Size = new System.Drawing.Size(32, 13);
            this.lblHostName.TabIndex = 0;
            this.lblHostName.Text = "Host:";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Location = new System.Drawing.Point(6, 84);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(440, 208);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label6);
            this.tabPage5.Controls.Add(this.label4);
            this.tabPage5.Controls.Add(this.chkPermExport);
            this.tabPage5.Controls.Add(this.chkPermCanImpersonate);
            this.tabPage5.Controls.Add(this.chkPermAdmin);
            this.tabPage5.Controls.Add(this.txtPermUserName);
            this.tabPage5.Controls.Add(this.label3);
            this.tabPage5.Controls.Add(this.btnUpdateAdminPerm);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(432, 182);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Administrive Permission Management";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Rights:";
            // 
            // chkPermExport
            // 
            this.chkPermExport.AutoSize = true;
            this.chkPermExport.Checked = true;
            this.chkPermExport.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPermExport.Location = new System.Drawing.Point(75, 55);
            this.chkPermExport.Name = "chkPermExport";
            this.chkPermExport.Size = new System.Drawing.Size(56, 17);
            this.chkPermExport.TabIndex = 4;
            this.chkPermExport.Text = "Export";
            this.chkPermExport.UseVisualStyleBackColor = true;
            // 
            // chkPermCanImpersonate
            // 
            this.chkPermCanImpersonate.AutoSize = true;
            this.chkPermCanImpersonate.Location = new System.Drawing.Point(75, 78);
            this.chkPermCanImpersonate.Name = "chkPermCanImpersonate";
            this.chkPermCanImpersonate.Size = new System.Drawing.Size(106, 17);
            this.chkPermCanImpersonate.TabIndex = 5;
            this.chkPermCanImpersonate.Text = "Can Impersonate";
            this.chkPermCanImpersonate.UseVisualStyleBackColor = true;
            // 
            // chkPermAdmin
            // 
            this.chkPermAdmin.AutoSize = true;
            this.chkPermAdmin.Checked = true;
            this.chkPermAdmin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPermAdmin.Location = new System.Drawing.Point(75, 32);
            this.chkPermAdmin.Name = "chkPermAdmin";
            this.chkPermAdmin.Size = new System.Drawing.Size(55, 17);
            this.chkPermAdmin.TabIndex = 3;
            this.chkPermAdmin.Text = "Admin";
            this.chkPermAdmin.UseVisualStyleBackColor = true;
            // 
            // txtPermUserName
            // 
            this.txtPermUserName.Location = new System.Drawing.Point(75, 3);
            this.txtPermUserName.Name = "txtPermUserName";
            this.txtPermUserName.Size = new System.Drawing.Size(345, 20);
            this.txtPermUserName.TabIndex = 1;
            this.txtPermUserName.Text = "K2:Domain\\Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "User Name:";
            // 
            // btnUpdateAdminPerm
            // 
            this.btnUpdateAdminPerm.AutoSize = true;
            this.btnUpdateAdminPerm.Location = new System.Drawing.Point(75, 101);
            this.btnUpdateAdminPerm.Name = "btnUpdateAdminPerm";
            this.btnUpdateAdminPerm.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateAdminPerm.TabIndex = 6;
            this.btnUpdateAdminPerm.Text = "&Update";
            this.btnUpdateAdminPerm.UseVisualStyleBackColor = true;
            this.btnUpdateAdminPerm.Click += new System.EventHandler(this.btnUpdateAdminPerm_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.label7);
            this.tabPage6.Controls.Add(this.txtProcMngUserName);
            this.tabPage6.Controls.Add(this.label5);
            this.tabPage6.Controls.Add(this.btnUpdateProcPerm);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(432, 182);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "Process Permission Management";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // txtProcMngUserName
            // 
            this.txtProcMngUserName.Location = new System.Drawing.Point(75, 3);
            this.txtProcMngUserName.Name = "txtProcMngUserName";
            this.txtProcMngUserName.Size = new System.Drawing.Size(345, 20);
            this.txtProcMngUserName.TabIndex = 1;
            this.txtProcMngUserName.Text = "K2:Domain\\Username";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "User Name:";
            // 
            // btnUpdateProcPerm
            // 
            this.btnUpdateProcPerm.Location = new System.Drawing.Point(75, 29);
            this.btnUpdateProcPerm.Name = "btnUpdateProcPerm";
            this.btnUpdateProcPerm.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateProcPerm.TabIndex = 2;
            this.btnUpdateProcPerm.Text = "&Update";
            this.btnUpdateProcPerm.UseVisualStyleBackColor = true;
            this.btnUpdateProcPerm.Click += new System.EventHandler(this.btnUpdateProcPerm_Click);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.label8);
            this.tabPage7.Controls.Add(this.btnActionMng);
            this.tabPage7.Controls.Add(this.btnActionInstMng);
            this.tabPage7.Controls.Add(this.btnWorklistItemMng);
            this.tabPage7.Controls.Add(this.btnProcDataMng);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(432, 182);
            this.tabPage7.TabIndex = 3;
            this.tabPage7.Text = "Miscellaneous";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // btnActionMng
            // 
            this.btnActionMng.Location = new System.Drawing.Point(5, 90);
            this.btnActionMng.Name = "btnActionMng";
            this.btnActionMng.Size = new System.Drawing.Size(198, 23);
            this.btnActionMng.TabIndex = 3;
            this.btnActionMng.Text = "Global Action Rights Management";
            this.btnActionMng.UseVisualStyleBackColor = true;
            this.btnActionMng.Click += new System.EventHandler(this.btnActionMng_Click);
            // 
            // btnActionInstMng
            // 
            this.btnActionInstMng.Location = new System.Drawing.Point(5, 61);
            this.btnActionInstMng.Name = "btnActionInstMng";
            this.btnActionInstMng.Size = new System.Drawing.Size(198, 23);
            this.btnActionInstMng.TabIndex = 2;
            this.btnActionInstMng.Text = "Action Instance Rights Management";
            this.btnActionInstMng.UseVisualStyleBackColor = true;
            this.btnActionInstMng.Click += new System.EventHandler(this.btnActionInstMng_Click);
            // 
            // btnWorklistItemMng
            // 
            this.btnWorklistItemMng.Location = new System.Drawing.Point(3, 32);
            this.btnWorklistItemMng.Name = "btnWorklistItemMng";
            this.btnWorklistItemMng.Size = new System.Drawing.Size(198, 23);
            this.btnWorklistItemMng.TabIndex = 1;
            this.btnWorklistItemMng.Text = "Worklist Item Management";
            this.btnWorklistItemMng.UseVisualStyleBackColor = true;
            this.btnWorklistItemMng.Click += new System.EventHandler(this.btnWorklistItemMng_Click);
            // 
            // btnProcDataMng
            // 
            this.btnProcDataMng.Location = new System.Drawing.Point(5, 3);
            this.btnProcDataMng.Name = "btnProcDataMng";
            this.btnProcDataMng.Size = new System.Drawing.Size(198, 23);
            this.btnProcDataMng.TabIndex = 0;
            this.btnProcDataMng.Text = "Process Data Management";
            this.btnProcDataMng.UseVisualStyleBackColor = true;
            this.btnProcDataMng.Click += new System.EventHandler(this.btnProcDataMng_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Info;
            this.label6.Location = new System.Drawing.Point(9, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(411, 40);
            this.label6.TabIndex = 8;
            this.label6.Text = "Warning: This is not meant to be a process or server management tool. Do not clic" +
                "k buttons on the Process Management tab without first understanding the code beh" +
                "ind them.";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Info;
            this.label7.Location = new System.Drawing.Point(9, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(411, 40);
            this.label7.TabIndex = 9;
            this.label7.Text = "Warning: This is not meant to be a process or server management tool. Do not clic" +
                "k buttons on the Process Management tab without first understanding the code beh" +
                "ind them.";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.Info;
            this.label8.Location = new System.Drawing.Point(9, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(411, 40);
            this.label8.TabIndex = 9;
            this.label8.Text = "Warning: This is not meant to be a process or server management tool. Do not clic" +
                "k buttons on the Process Management tab without first understanding the code beh" +
                "ind them.";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 352);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Workflow Samples";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtOutputLocation;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblOutputLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox txtProcessName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnDeploy;
        private System.Windows.Forms.Label lblDeploymentResults;
        private System.Windows.Forms.TextBox txtDeploymentResults;
        private System.Windows.Forms.Label lblProcessFile;
        private System.Windows.Forms.TextBox txtProcessFile;
        private System.Windows.Forms.Button btnBrowseProcessFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnUpdateAdminPerm;
        private System.Windows.Forms.Button btnUpdateProcPerm;
        private System.Windows.Forms.Button btnProcDataMng;
        private System.Windows.Forms.Button btnWorklistItemMng;
        private System.Windows.Forms.Button btnActionInstMng;
        private System.Windows.Forms.Button btnActionMng;
        private System.Windows.Forms.Button btnDeployIncomplete;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtHostName;
        private System.Windows.Forms.Label lblServerPort;
        private System.Windows.Forms.Label lblHostName;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TextBox txtPermUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkPermAdmin;
        private System.Windows.Forms.CheckBox chkPermExport;
        private System.Windows.Forms.CheckBox chkPermCanImpersonate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProcMngUserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

