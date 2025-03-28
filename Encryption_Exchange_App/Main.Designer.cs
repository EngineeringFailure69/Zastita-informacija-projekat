namespace Encryption_Exchange_App
{
    partial class Main
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Main));
            menuStrip1 = new MenuStrip();
            mainPageToolStripMenuItem = new ToolStripMenuItem();
            encryptionToolStripMenuItem = new ToolStripMenuItem();
            encryptionSettingsToolStripMenuItem = new ToolStripMenuItem();
            tCPToolStripMenuItem = new ToolStripMenuItem();
            TCPSettingsToolStripMenuItem = new ToolStripMenuItem();
            serverSettingsToolStripMenuItem = new ToolStripMenuItem();
            clientSettingsToolStripMenuItem = new ToolStripMenuItem();
            fSWToolStripMenuItem = new ToolStripMenuItem();
            FSWSettingsToolStripMenuItem = new ToolStripMenuItem();
            tabFSWSettingsPage = new TabPage();
            groupBox6 = new GroupBox();
            lblNumber = new Label();
            label7 = new Label();
            label1 = new Label();
            lblStatus = new Label();
            groupBox5 = new GroupBox();
            rcbLog = new RichTextBox();
            groupBox4 = new GroupBox();
            pictureBox1 = new PictureBox();
            label6 = new Label();
            label2 = new Label();
            groupBox3 = new GroupBox();
            cbEnableDisable = new CheckBox();
            cbRenaming = new CheckBox();
            cbDeleting = new CheckBox();
            cbCreating = new CheckBox();
            btnUploadDirectory = new Button();
            gbFilesInTheDirectory = new GroupBox();
            lvCurrentFiles = new ListView();
            tabEncryptionSettingsPage = new TabPage();
            groupBox7 = new GroupBox();
            rtbLog = new RichTextBox();
            groupBox1 = new GroupBox();
            btnSelectFileToEncryptDecrypt = new Button();
            lblFileSize = new Label();
            lblFileAttributes = new Label();
            lblFileDateModified = new Label();
            lblFileDateCreated = new Label();
            lblFileExtension = new Label();
            lblFilePath = new Label();
            lblFileName = new Label();
            groupBox2 = new GroupBox();
            btnDecryptSelectedFile = new Button();
            rbRC6OFB = new RadioButton();
            rbBifid = new RadioButton();
            btnEncryptSelectedFile = new Button();
            tabMainPage = new TabPage();
            tabControl = new TabControl();
            tabTCPClientSettingsPage = new TabPage();
            lblClientStatus = new Label();
            btnChoseFile = new Button();
            btnSendFile = new Button();
            tbPort = new TextBox();
            tbIPAddress = new TextBox();
            label5 = new Label();
            lblChosenFile = new Label();
            label3 = new Label();
            tabTCPServerSettingsPage = new TabPage();
            lblServerStatus = new Label();
            btnStopListening = new Button();
            textBox1 = new TextBox();
            label4 = new Label();
            btnStartListening = new Button();
            tabTCPSettingsPage = new TabPage();
            checkedListBox1 = new CheckedListBox();
            menuStrip1.SuspendLayout();
            tabFSWSettingsPage.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            ((ISupportInitialize)pictureBox1).BeginInit();
            groupBox3.SuspendLayout();
            gbFilesInTheDirectory.SuspendLayout();
            tabEncryptionSettingsPage.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            tabControl.SuspendLayout();
            tabTCPClientSettingsPage.SuspendLayout();
            tabTCPServerSettingsPage.SuspendLayout();
            tabTCPSettingsPage.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mainPageToolStripMenuItem, encryptionToolStripMenuItem, tCPToolStripMenuItem, fSWToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // mainPageToolStripMenuItem
            // 
            mainPageToolStripMenuItem.Name = "mainPageToolStripMenuItem";
            mainPageToolStripMenuItem.Size = new Size(94, 24);
            mainPageToolStripMenuItem.Text = "Main page";
            mainPageToolStripMenuItem.Click += mainPageToolStripMenuItem_Click;
            // 
            // encryptionToolStripMenuItem
            // 
            encryptionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { encryptionSettingsToolStripMenuItem });
            encryptionToolStripMenuItem.Name = "encryptionToolStripMenuItem";
            encryptionToolStripMenuItem.Size = new Size(93, 24);
            encryptionToolStripMenuItem.Text = "Encryption";
            // 
            // encryptionSettingsToolStripMenuItem
            // 
            encryptionSettingsToolStripMenuItem.Name = "encryptionSettingsToolStripMenuItem";
            encryptionSettingsToolStripMenuItem.Size = new Size(145, 26);
            encryptionSettingsToolStripMenuItem.Text = "Settings";
            encryptionSettingsToolStripMenuItem.Click += encryptionSettingsToolStripMenuItem_Click;
            // 
            // tCPToolStripMenuItem
            // 
            tCPToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { TCPSettingsToolStripMenuItem, serverSettingsToolStripMenuItem, clientSettingsToolStripMenuItem });
            tCPToolStripMenuItem.Name = "tCPToolStripMenuItem";
            tCPToolStripMenuItem.Size = new Size(47, 24);
            tCPToolStripMenuItem.Text = "TCP";
            // 
            // TCPSettingsToolStripMenuItem
            // 
            TCPSettingsToolStripMenuItem.Name = "TCPSettingsToolStripMenuItem";
            TCPSettingsToolStripMenuItem.Size = new Size(188, 26);
            TCPSettingsToolStripMenuItem.Text = "Settings";
            TCPSettingsToolStripMenuItem.Click += TCPSettingsToolStripMenuItem_Click;
            // 
            // serverSettingsToolStripMenuItem
            // 
            serverSettingsToolStripMenuItem.Name = "serverSettingsToolStripMenuItem";
            serverSettingsToolStripMenuItem.Size = new Size(188, 26);
            serverSettingsToolStripMenuItem.Text = "Server settings";
            serverSettingsToolStripMenuItem.Click += serverSettingsToolStripMenuItem_Click;
            // 
            // clientSettingsToolStripMenuItem
            // 
            clientSettingsToolStripMenuItem.Name = "clientSettingsToolStripMenuItem";
            clientSettingsToolStripMenuItem.Size = new Size(188, 26);
            clientSettingsToolStripMenuItem.Text = "Client settings";
            clientSettingsToolStripMenuItem.Click += clientSettingsToolStripMenuItem_Click;
            // 
            // fSWToolStripMenuItem
            // 
            fSWToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { FSWSettingsToolStripMenuItem });
            fSWToolStripMenuItem.Name = "fSWToolStripMenuItem";
            fSWToolStripMenuItem.Size = new Size(52, 24);
            fSWToolStripMenuItem.Text = "FSW";
            // 
            // FSWSettingsToolStripMenuItem
            // 
            FSWSettingsToolStripMenuItem.Name = "FSWSettingsToolStripMenuItem";
            FSWSettingsToolStripMenuItem.Size = new Size(145, 26);
            FSWSettingsToolStripMenuItem.Text = "Settings";
            FSWSettingsToolStripMenuItem.Click += FSWSettingsToolStripMenuItem_Click;
            // 
            // tabFSWSettingsPage
            // 
            tabFSWSettingsPage.Controls.Add(groupBox6);
            tabFSWSettingsPage.Controls.Add(groupBox5);
            tabFSWSettingsPage.Controls.Add(groupBox4);
            tabFSWSettingsPage.Controls.Add(groupBox3);
            tabFSWSettingsPage.Controls.Add(btnUploadDirectory);
            tabFSWSettingsPage.Controls.Add(gbFilesInTheDirectory);
            tabFSWSettingsPage.Location = new Point(4, 29);
            tabFSWSettingsPage.Name = "tabFSWSettingsPage";
            tabFSWSettingsPage.Padding = new Padding(3);
            tabFSWSettingsPage.Size = new Size(768, 392);
            tabFSWSettingsPage.TabIndex = 3;
            tabFSWSettingsPage.Text = "FSW settings";
            tabFSWSettingsPage.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(lblNumber);
            groupBox6.Controls.Add(label7);
            groupBox6.Controls.Add(label1);
            groupBox6.Controls.Add(lblStatus);
            groupBox6.Location = new Point(12, 289);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(462, 75);
            groupBox6.TabIndex = 20;
            groupBox6.TabStop = false;
            groupBox6.Text = "Status";
            // 
            // lblNumber
            // 
            lblNumber.AutoSize = true;
            lblNumber.Location = new Point(376, 37);
            lblNumber.Name = "lblNumber";
            lblNumber.Size = new Size(69, 20);
            lblNumber.TabIndex = 4;
            lblNumber.Text = "number...";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(216, 37);
            label7.Name = "label7";
            label7.Size = new Size(142, 20);
            label7.TabIndex = 3;
            label7.Text = "Number of changes:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 37);
            label1.Name = "label1";
            label1.Size = new Size(87, 20);
            label1.TabIndex = 1;
            label1.Text = "FSW status: ";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(121, 37);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(56, 20);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "status...";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(rcbLog);
            groupBox5.Location = new Point(12, 158);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(464, 125);
            groupBox5.TabIndex = 19;
            groupBox5.TabStop = false;
            groupBox5.Text = "Log";
            // 
            // rcbLog
            // 
            rcbLog.Location = new Point(6, 26);
            rcbLog.Name = "rcbLog";
            rcbLog.Size = new Size(452, 83);
            rcbLog.TabIndex = 0;
            rcbLog.Text = "";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(pictureBox1);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(label2);
            groupBox4.Location = new Point(12, 6);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(762, 67);
            groupBox4.TabIndex = 18;
            groupBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(496, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(51, 42);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.Location = new Point(139, 9);
            label6.Name = "label6";
            label6.Size = new Size(317, 46);
            label6.TabIndex = 19;
            label6.Text = "File System Watcher";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(314, 118);
            label2.Name = "label2";
            label2.Size = new Size(317, 46);
            label2.TabIndex = 17;
            label2.Text = "File System Watcher";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(cbEnableDisable);
            groupBox3.Controls.Add(cbRenaming);
            groupBox3.Controls.Add(cbDeleting);
            groupBox3.Controls.Add(cbCreating);
            groupBox3.Location = new Point(12, 79);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(464, 73);
            groupBox3.TabIndex = 16;
            groupBox3.TabStop = false;
            groupBox3.Text = "Tracking";
            // 
            // cbEnableDisable
            // 
            cbEnableDisable.AutoSize = true;
            cbEnableDisable.Location = new Point(6, 26);
            cbEnableDisable.Name = "cbEnableDisable";
            cbEnableDisable.Size = new Size(165, 24);
            cbEnableDisable.TabIndex = 0;
            cbEnableDisable.Text = "Enable/Disable FSW";
            cbEnableDisable.UseVisualStyleBackColor = true;
            cbEnableDisable.CheckedChanged += cbEnableDisable_CheckedChanged;
            // 
            // cbRenaming
            // 
            cbRenaming.AutoSize = true;
            cbRenaming.Location = new Point(364, 26);
            cbRenaming.Name = "cbRenaming";
            cbRenaming.Size = new Size(98, 24);
            cbRenaming.TabIndex = 9;
            cbRenaming.Text = "Renaming";
            cbRenaming.UseVisualStyleBackColor = true;
            cbRenaming.CheckedChanged += cbRenaming_CheckedChanged;
            // 
            // cbDeleting
            // 
            cbDeleting.AutoSize = true;
            cbDeleting.Location = new Point(270, 26);
            cbDeleting.Name = "cbDeleting";
            cbDeleting.Size = new Size(88, 24);
            cbDeleting.TabIndex = 8;
            cbDeleting.Text = "Deleting";
            cbDeleting.UseVisualStyleBackColor = true;
            cbDeleting.CheckedChanged += cbDeleting_CheckedChanged;
            // 
            // cbCreating
            // 
            cbCreating.AutoSize = true;
            cbCreating.Location = new Point(177, 26);
            cbCreating.Name = "cbCreating";
            cbCreating.Size = new Size(87, 24);
            cbCreating.TabIndex = 7;
            cbCreating.Text = "Creating";
            cbCreating.UseVisualStyleBackColor = true;
            cbCreating.CheckedChanged += cbCreating_CheckedChanged;
            // 
            // btnUploadDirectory
            // 
            btnUploadDirectory.Location = new Point(563, 358);
            btnUploadDirectory.Name = "btnUploadDirectory";
            btnUploadDirectory.Size = new Size(146, 29);
            btnUploadDirectory.TabIndex = 15;
            btnUploadDirectory.Text = "Upload directory";
            btnUploadDirectory.UseVisualStyleBackColor = true;
            btnUploadDirectory.Click += btnUploadDirectory_Click;
            // 
            // gbFilesInTheDirectory
            // 
            gbFilesInTheDirectory.Controls.Add(lvCurrentFiles);
            gbFilesInTheDirectory.Location = new Point(502, 94);
            gbFilesInTheDirectory.Name = "gbFilesInTheDirectory";
            gbFilesInTheDirectory.Size = new Size(263, 258);
            gbFilesInTheDirectory.TabIndex = 14;
            gbFilesInTheDirectory.TabStop = false;
            gbFilesInTheDirectory.Text = "Current files in the target directory ";
            // 
            // lvCurrentFiles
            // 
            lvCurrentFiles.Location = new Point(6, 26);
            lvCurrentFiles.Name = "lvCurrentFiles";
            lvCurrentFiles.Size = new Size(249, 226);
            lvCurrentFiles.TabIndex = 3;
            lvCurrentFiles.UseCompatibleStateImageBehavior = false;
            // 
            // tabEncryptionSettingsPage
            // 
            tabEncryptionSettingsPage.Controls.Add(groupBox7);
            tabEncryptionSettingsPage.Controls.Add(groupBox1);
            tabEncryptionSettingsPage.Controls.Add(groupBox2);
            tabEncryptionSettingsPage.Location = new Point(4, 29);
            tabEncryptionSettingsPage.Name = "tabEncryptionSettingsPage";
            tabEncryptionSettingsPage.Padding = new Padding(3);
            tabEncryptionSettingsPage.Size = new Size(768, 392);
            tabEncryptionSettingsPage.TabIndex = 1;
            tabEncryptionSettingsPage.Text = "Encryption settings";
            tabEncryptionSettingsPage.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(rtbLog);
            groupBox7.Location = new Point(6, 220);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(756, 149);
            groupBox7.TabIndex = 5;
            groupBox7.TabStop = false;
            groupBox7.Text = "Log";
            // 
            // rtbLog
            // 
            rtbLog.Location = new Point(6, 23);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(744, 120);
            rtbLog.TabIndex = 5;
            rtbLog.Text = "";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSelectFileToEncryptDecrypt);
            groupBox1.Controls.Add(lblFileSize);
            groupBox1.Controls.Add(lblFileAttributes);
            groupBox1.Controls.Add(lblFileDateModified);
            groupBox1.Controls.Add(lblFileDateCreated);
            groupBox1.Controls.Add(lblFileExtension);
            groupBox1.Controls.Add(lblFilePath);
            groupBox1.Controls.Add(lblFileName);
            groupBox1.Location = new Point(6, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(525, 193);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Select and encrypt";
            // 
            // btnSelectFileToEncryptDecrypt
            // 
            btnSelectFileToEncryptDecrypt.Location = new Point(141, 158);
            btnSelectFileToEncryptDecrypt.Name = "btnSelectFileToEncryptDecrypt";
            btnSelectFileToEncryptDecrypt.Size = new Size(216, 29);
            btnSelectFileToEncryptDecrypt.TabIndex = 21;
            btnSelectFileToEncryptDecrypt.Text = "Select file to encrypt/decrypt";
            btnSelectFileToEncryptDecrypt.UseVisualStyleBackColor = true;
            btnSelectFileToEncryptDecrypt.Click += btnSelectFileToEncryptDecrypt_Click_1;
            // 
            // lblFileSize
            // 
            lblFileSize.AutoSize = true;
            lblFileSize.Location = new Point(6, 83);
            lblFileSize.Name = "lblFileSize";
            lblFileSize.Size = new Size(68, 20);
            lblFileSize.TabIndex = 17;
            lblFileSize.Text = "File size: ";
            // 
            // lblFileAttributes
            // 
            lblFileAttributes.AutoSize = true;
            lblFileAttributes.Location = new Point(330, 83);
            lblFileAttributes.Name = "lblFileAttributes";
            lblFileAttributes.Size = new Size(77, 20);
            lblFileAttributes.TabIndex = 15;
            lblFileAttributes.Text = "Attributes:";
            // 
            // lblFileDateModified
            // 
            lblFileDateModified.AutoSize = true;
            lblFileDateModified.Location = new Point(258, 110);
            lblFileDateModified.Name = "lblFileDateModified";
            lblFileDateModified.Size = new Size(109, 20);
            lblFileDateModified.TabIndex = 18;
            lblFileDateModified.Text = "Date Modified:";
            // 
            // lblFileDateCreated
            // 
            lblFileDateCreated.AutoSize = true;
            lblFileDateCreated.Location = new Point(6, 110);
            lblFileDateCreated.Name = "lblFileDateCreated";
            lblFileDateCreated.Size = new Size(98, 20);
            lblFileDateCreated.TabIndex = 19;
            lblFileDateCreated.Text = "Date created:";
            // 
            // lblFileExtension
            // 
            lblFileExtension.AutoSize = true;
            lblFileExtension.Location = new Point(178, 83);
            lblFileExtension.Name = "lblFileExtension";
            lblFileExtension.Size = new Size(75, 20);
            lblFileExtension.TabIndex = 20;
            lblFileExtension.Text = "Extension:";
            // 
            // lblFilePath
            // 
            lblFilePath.AutoSize = true;
            lblFilePath.Location = new Point(6, 23);
            lblFilePath.Name = "lblFilePath";
            lblFilePath.Size = new Size(44, 20);
            lblFilePath.TabIndex = 14;
            lblFilePath.Text = "Path: ";
            // 
            // lblFileName
            // 
            lblFileName.AutoSize = true;
            lblFileName.Location = new Point(6, 52);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(80, 20);
            lblFileName.TabIndex = 16;
            lblFileName.Text = "File name: ";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnDecryptSelectedFile);
            groupBox2.Controls.Add(rbRC6OFB);
            groupBox2.Controls.Add(rbBifid);
            groupBox2.Controls.Add(btnEncryptSelectedFile);
            groupBox2.Location = new Point(537, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(225, 193);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Pick the encryption algorithm ";
            // 
            // btnDecryptSelectedFile
            // 
            btnDecryptSelectedFile.Location = new Point(125, 158);
            btnDecryptSelectedFile.Name = "btnDecryptSelectedFile";
            btnDecryptSelectedFile.Size = new Size(94, 29);
            btnDecryptSelectedFile.TabIndex = 23;
            btnDecryptSelectedFile.Text = "Decrypt file";
            btnDecryptSelectedFile.UseVisualStyleBackColor = true;
            btnDecryptSelectedFile.Click += btnDecryptSelectedFile_Click_1;
            // 
            // rbRC6OFB
            // 
            rbRC6OFB.AutoSize = true;
            rbRC6OFB.Location = new Point(6, 78);
            rbRC6OFB.Name = "rbRC6OFB";
            rbRC6OFB.Size = new Size(101, 24);
            rbRC6OFB.TabIndex = 1;
            rbRC6OFB.Text = "RC6 + OFB";
            rbRC6OFB.UseVisualStyleBackColor = true;
            // 
            // rbBifid
            // 
            rbBifid.AutoSize = true;
            rbBifid.Checked = true;
            rbBifid.Location = new Point(6, 39);
            rbBifid.Name = "rbBifid";
            rbBifid.Size = new Size(61, 24);
            rbBifid.TabIndex = 0;
            rbBifid.TabStop = true;
            rbBifid.Text = "Bifid";
            rbBifid.UseVisualStyleBackColor = true;
            // 
            // btnEncryptSelectedFile
            // 
            btnEncryptSelectedFile.Location = new Point(6, 158);
            btnEncryptSelectedFile.Name = "btnEncryptSelectedFile";
            btnEncryptSelectedFile.Size = new Size(94, 29);
            btnEncryptSelectedFile.TabIndex = 22;
            btnEncryptSelectedFile.Text = "Encrypt file";
            btnEncryptSelectedFile.UseVisualStyleBackColor = true;
            btnEncryptSelectedFile.Click += btnEncryptSelectedFile_Click_1;
            // 
            // tabMainPage
            // 
            tabMainPage.Location = new Point(4, 29);
            tabMainPage.Name = "tabMainPage";
            tabMainPage.Padding = new Padding(3);
            tabMainPage.Size = new Size(768, 392);
            tabMainPage.TabIndex = 0;
            tabMainPage.Text = "Main page";
            tabMainPage.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabMainPage);
            tabControl.Controls.Add(tabEncryptionSettingsPage);
            tabControl.Controls.Add(tabFSWSettingsPage);
            tabControl.Controls.Add(tabTCPClientSettingsPage);
            tabControl.Controls.Add(tabTCPServerSettingsPage);
            tabControl.Controls.Add(tabTCPSettingsPage);
            tabControl.Location = new Point(12, 31);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(776, 425);
            tabControl.TabIndex = 3;
            // 
            // tabTCPClientSettingsPage
            // 
            tabTCPClientSettingsPage.Controls.Add(lblClientStatus);
            tabTCPClientSettingsPage.Controls.Add(btnChoseFile);
            tabTCPClientSettingsPage.Controls.Add(btnSendFile);
            tabTCPClientSettingsPage.Controls.Add(tbPort);
            tabTCPClientSettingsPage.Controls.Add(tbIPAddress);
            tabTCPClientSettingsPage.Controls.Add(label5);
            tabTCPClientSettingsPage.Controls.Add(lblChosenFile);
            tabTCPClientSettingsPage.Controls.Add(label3);
            tabTCPClientSettingsPage.Location = new Point(4, 29);
            tabTCPClientSettingsPage.Name = "tabTCPClientSettingsPage";
            tabTCPClientSettingsPage.Padding = new Padding(3);
            tabTCPClientSettingsPage.Size = new Size(768, 392);
            tabTCPClientSettingsPage.TabIndex = 4;
            tabTCPClientSettingsPage.Text = "TCP client settings";
            tabTCPClientSettingsPage.UseVisualStyleBackColor = true;
            // 
            // lblClientStatus
            // 
            lblClientStatus.AutoSize = true;
            lblClientStatus.Location = new Point(216, 264);
            lblClientStatus.Name = "lblClientStatus";
            lblClientStatus.Size = new Size(49, 20);
            lblClientStatus.TabIndex = 7;
            lblClientStatus.Text = "Status";
            // 
            // btnChoseFile
            // 
            btnChoseFile.Location = new Point(74, 202);
            btnChoseFile.Name = "btnChoseFile";
            btnChoseFile.Size = new Size(94, 29);
            btnChoseFile.TabIndex = 6;
            btnChoseFile.Text = "Chose file";
            btnChoseFile.UseVisualStyleBackColor = true;
            btnChoseFile.Click += btnChoseFile_Click;
            // 
            // btnSendFile
            // 
            btnSendFile.Location = new Point(74, 260);
            btnSendFile.Name = "btnSendFile";
            btnSendFile.Size = new Size(94, 29);
            btnSendFile.TabIndex = 5;
            btnSendFile.Text = "Send file";
            btnSendFile.UseVisualStyleBackColor = true;
            btnSendFile.Click += btnSendFile_Click;
            // 
            // tbPort
            // 
            tbPort.Location = new Point(216, 147);
            tbPort.Name = "tbPort";
            tbPort.Size = new Size(125, 27);
            tbPort.TabIndex = 4;
            tbPort.Text = "5000";
            tbPort.TextAlign = HorizontalAlignment.Center;
            // 
            // tbIPAddress
            // 
            tbIPAddress.Location = new Point(216, 92);
            tbIPAddress.Name = "tbIPAddress";
            tbIPAddress.Size = new Size(125, 27);
            tbIPAddress.TabIndex = 3;
            tbIPAddress.Text = "127.0.0.1";
            tbIPAddress.TextAlign = HorizontalAlignment.Center;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(74, 150);
            label5.Name = "label5";
            label5.Size = new Size(38, 20);
            label5.TabIndex = 2;
            label5.Text = "Port:";
            // 
            // lblChosenFile
            // 
            lblChosenFile.AutoSize = true;
            lblChosenFile.Location = new Point(216, 206);
            lblChosenFile.Name = "lblChosenFile";
            lblChosenFile.Size = new Size(82, 20);
            lblChosenFile.TabIndex = 1;
            lblChosenFile.Text = "Chosen file";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(74, 95);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 0;
            label3.Text = "IP address:";
            // 
            // tabTCPServerSettingsPage
            // 
            tabTCPServerSettingsPage.Controls.Add(lblServerStatus);
            tabTCPServerSettingsPage.Controls.Add(btnStopListening);
            tabTCPServerSettingsPage.Controls.Add(textBox1);
            tabTCPServerSettingsPage.Controls.Add(label4);
            tabTCPServerSettingsPage.Controls.Add(btnStartListening);
            tabTCPServerSettingsPage.Location = new Point(4, 29);
            tabTCPServerSettingsPage.Name = "tabTCPServerSettingsPage";
            tabTCPServerSettingsPage.Padding = new Padding(3);
            tabTCPServerSettingsPage.Size = new Size(768, 392);
            tabTCPServerSettingsPage.TabIndex = 5;
            tabTCPServerSettingsPage.Text = "TCP server settings";
            tabTCPServerSettingsPage.UseVisualStyleBackColor = true;
            // 
            // lblServerStatus
            // 
            lblServerStatus.AutoSize = true;
            lblServerStatus.Location = new Point(418, 66);
            lblServerStatus.Name = "lblServerStatus";
            lblServerStatus.Size = new Size(49, 20);
            lblServerStatus.TabIndex = 4;
            lblServerStatus.Text = "Status";
            // 
            // btnStopListening
            // 
            btnStopListening.Location = new Point(364, 165);
            btnStopListening.Name = "btnStopListening";
            btnStopListening.Size = new Size(122, 29);
            btnStopListening.TabIndex = 3;
            btnStopListening.Text = "Stop listening";
            btnStopListening.UseVisualStyleBackColor = true;
            btnStopListening.Click += btnStopListening_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(222, 59);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 2;
            textBox1.Text = "5000";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(135, 62);
            label4.Name = "label4";
            label4.Size = new Size(38, 20);
            label4.TabIndex = 1;
            label4.Text = "Port:";
            // 
            // btnStartListening
            // 
            btnStartListening.Location = new Point(93, 165);
            btnStartListening.Name = "btnStartListening";
            btnStartListening.Size = new Size(120, 29);
            btnStartListening.TabIndex = 0;
            btnStartListening.Text = "Start listening";
            btnStartListening.UseVisualStyleBackColor = true;
            btnStartListening.Click += btnStartListening_Click;
            // 
            // tabTCPSettingsPage
            // 
            tabTCPSettingsPage.Controls.Add(checkedListBox1);
            tabTCPSettingsPage.Location = new Point(4, 29);
            tabTCPSettingsPage.Name = "tabTCPSettingsPage";
            tabTCPSettingsPage.Padding = new Padding(3);
            tabTCPSettingsPage.Size = new Size(768, 392);
            tabTCPSettingsPage.TabIndex = 6;
            tabTCPSettingsPage.Text = "TCP settings";
            tabTCPSettingsPage.UseVisualStyleBackColor = true;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(492, 110);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(150, 114);
            checkedListBox1.TabIndex = 0;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 457);
            Controls.Add(tabControl);
            Controls.Add(menuStrip1);
            Name = "Main";
            Text = "Main";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabFSWSettingsPage.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((ISupportInitialize)pictureBox1).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            gbFilesInTheDirectory.ResumeLayout(false);
            tabEncryptionSettingsPage.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tabControl.ResumeLayout(false);
            tabTCPClientSettingsPage.ResumeLayout(false);
            tabTCPClientSettingsPage.PerformLayout();
            tabTCPServerSettingsPage.ResumeLayout(false);
            tabTCPServerSettingsPage.PerformLayout();
            tabTCPSettingsPage.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mainPageToolStripMenuItem;
        private ToolStripMenuItem encryptionToolStripMenuItem;
        private ToolStripMenuItem encryptionSettingsToolStripMenuItem;
        private ToolStripMenuItem tCPToolStripMenuItem;
        private ToolStripMenuItem TCPSettingsToolStripMenuItem;
        private ToolStripMenuItem fSWToolStripMenuItem;
        private ToolStripMenuItem FSWSettingsToolStripMenuItem;
        private TabPage tabFSWSettingsPage;
        private GroupBox groupBox3;
        private CheckBox cbEnableDisable;
        private Label label1;
        private CheckBox cbRenaming;
        private Label lblStatus;
        private CheckBox cbDeleting;
        private CheckBox cbCreating;
        private Button btnUploadDirectory;
        private GroupBox gbFilesInTheDirectory;
        private ListView lvCurrentFiles;
        private TabPage tabEncryptionSettingsPage;
        private GroupBox groupBox2;
        private RadioButton rbRC6OFB;
        private RadioButton rbBifid;
        private TabPage tabMainPage;
        private TabControl tabControl;
        private TabPage tabTCPClientSettingsPage;
        private ToolStripMenuItem serverSettingsToolStripMenuItem;
        private ToolStripMenuItem clientSettingsToolStripMenuItem;
        private TabPage tabTCPServerSettingsPage;
        private Button btnStartListening;
        private TabPage tabTCPSettingsPage;
        private CheckedListBox checkedListBox1;
        private Label label5;
        private Label lblChosenFile;
        private Label label3;
        private TextBox tbIPAddress;
        private TextBox tbPort;
        private Button btnChoseFile;
        private Button btnSendFile;
        private Button btnStopListening;
        private TextBox textBox1;
        private Label label4;
        private Label lblClientStatus;
        private Label lblServerStatus;
        private PictureBox pictureBox1;
        private GroupBox groupBox4;
        private Label label2;
        private Label label6;
        private GroupBox groupBox5;
        private RichTextBox rcbLog;
        private GroupBox groupBox6;
        private Label lblNumber;
        private Label label7;
        private GroupBox groupBox1;
        private Button btnDecryptSelectedFile;
        private Button btnEncryptSelectedFile;
        private Button btnSelectFileToEncryptDecrypt;
        private Label lblFileSize;
        private Label lblFileAttributes;
        private Label lblFileDateModified;
        private Label lblFileDateCreated;
        private Label lblFileExtension;
        private Label lblFilePath;
        private Label lblFileName;
        private GroupBox groupBox7;
        private RichTextBox rtbLog;
    }
}