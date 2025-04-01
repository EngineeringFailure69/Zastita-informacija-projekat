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
            lblOutputXFolder = new Label();
            lblTargetFolder = new Label();
            btnChoseXFolder = new Button();
            btnChoseTargetFolder = new Button();
            groupBox9 = new GroupBox();
            rtbAppLog = new RichTextBox();
            groupBox8 = new GroupBox();
            lblLastActivity = new Label();
            lblNumberOfDecryptedFiles = new Label();
            label9 = new Label();
            lblNumberOfEncryptedFiles = new Label();
            label11 = new Label();
            lblEncryptingAlgoStatus = new Label();
            lblFSWStatus = new Label();
            label8 = new Label();
            tabControl = new TabControl();
            tabTCPClientSettingsPage = new TabPage();
            groupBox12 = new GroupBox();
            rtbClientSettings = new RichTextBox();
            groupBox11 = new GroupBox();
            lblChosenFile = new Label();
            btnChoseFile = new Button();
            btnSendFile = new Button();
            groupBox10 = new GroupBox();
            label3 = new Label();
            tbIPAddress = new TextBox();
            label5 = new Label();
            tbPort = new TextBox();
            lblClientStatus = new Label();
            tabTCPServerSettingsPage = new TabPage();
            groupBox14 = new GroupBox();
            textBox1 = new TextBox();
            label4 = new Label();
            lblServerStatus = new Label();
            btnStartListening = new Button();
            btnStopListening = new Button();
            groupBox13 = new GroupBox();
            rtbServerSettings = new RichTextBox();
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
            tabMainPage.SuspendLayout();
            groupBox9.SuspendLayout();
            groupBox8.SuspendLayout();
            tabControl.SuspendLayout();
            tabTCPClientSettingsPage.SuspendLayout();
            groupBox12.SuspendLayout();
            groupBox11.SuspendLayout();
            groupBox10.SuspendLayout();
            tabTCPServerSettingsPage.SuspendLayout();
            groupBox14.SuspendLayout();
            groupBox13.SuspendLayout();
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
            encryptionSettingsToolStripMenuItem.Size = new Size(174, 26);
            encryptionSettingsToolStripMenuItem.Text = "Podesavanja";
            encryptionSettingsToolStripMenuItem.Click += encryptionSettingsToolStripMenuItem_Click;
            // 
            // tCPToolStripMenuItem
            // 
            tCPToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { serverSettingsToolStripMenuItem, clientSettingsToolStripMenuItem });
            tCPToolStripMenuItem.Name = "tCPToolStripMenuItem";
            tCPToolStripMenuItem.Size = new Size(47, 24);
            tCPToolStripMenuItem.Text = "TCP";
            // 
            // serverSettingsToolStripMenuItem
            // 
            serverSettingsToolStripMenuItem.Name = "serverSettingsToolStripMenuItem";
            serverSettingsToolStripMenuItem.Size = new Size(243, 26);
            serverSettingsToolStripMenuItem.Text = "Serverska podesavanja";
            serverSettingsToolStripMenuItem.Click += serverSettingsToolStripMenuItem_Click;
            // 
            // clientSettingsToolStripMenuItem
            // 
            clientSettingsToolStripMenuItem.Name = "clientSettingsToolStripMenuItem";
            clientSettingsToolStripMenuItem.Size = new Size(243, 26);
            clientSettingsToolStripMenuItem.Text = "Klijentska podesavanja";
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
            FSWSettingsToolStripMenuItem.Size = new Size(174, 26);
            FSWSettingsToolStripMenuItem.Text = "Podesavanja";
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
            groupBox6.Size = new Size(484, 75);
            groupBox6.TabIndex = 20;
            groupBox6.TabStop = false;
            groupBox6.Text = "Status";
            // 
            // lblNumber
            // 
            lblNumber.AutoSize = true;
            lblNumber.Location = new Point(384, 37);
            lblNumber.Name = "lblNumber";
            lblNumber.Size = new Size(45, 20);
            lblNumber.TabIndex = 4;
            lblNumber.Text = "broj...";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(274, 37);
            label7.Name = "label7";
            label7.Size = new Size(103, 20);
            label7.TabIndex = 3;
            label7.Text = "Broj promena:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(63, 37);
            label1.Name = "label1";
            label1.Size = new Size(87, 20);
            label1.TabIndex = 1;
            label1.Text = "FSW status: ";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(156, 37);
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
            groupBox5.Size = new Size(484, 125);
            groupBox5.TabIndex = 19;
            groupBox5.TabStop = false;
            groupBox5.Text = "Log";
            // 
            // rcbLog
            // 
            rcbLog.Location = new Point(6, 26);
            rcbLog.Name = "rcbLog";
            rcbLog.Size = new Size(472, 83);
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
            groupBox3.Size = new Size(484, 73);
            groupBox3.TabIndex = 16;
            groupBox3.TabStop = false;
            groupBox3.Text = "Tracking";
            // 
            // cbEnableDisable
            // 
            cbEnableDisable.AutoSize = true;
            cbEnableDisable.Location = new Point(6, 26);
            cbEnableDisable.Name = "cbEnableDisable";
            cbEnableDisable.Size = new Size(158, 24);
            cbEnableDisable.TabIndex = 0;
            cbEnableDisable.Text = "Ukljuci/Iskljuci FSW";
            cbEnableDisable.UseVisualStyleBackColor = true;
            cbEnableDisable.CheckedChanged += cbEnableDisable_CheckedChanged;
            // 
            // cbRenaming
            // 
            cbRenaming.AutoSize = true;
            cbRenaming.Location = new Point(349, 26);
            cbRenaming.Name = "cbRenaming";
            cbRenaming.Size = new Size(129, 24);
            cbRenaming.TabIndex = 9;
            cbRenaming.Text = "Preimenovanje";
            cbRenaming.UseVisualStyleBackColor = true;
            cbRenaming.CheckedChanged += cbRenaming_CheckedChanged;
            // 
            // cbDeleting
            // 
            cbDeleting.AutoSize = true;
            cbDeleting.Location = new Point(260, 26);
            cbDeleting.Name = "cbDeleting";
            cbDeleting.Size = new Size(83, 24);
            cbDeleting.TabIndex = 8;
            cbDeleting.Text = "Brisanje";
            cbDeleting.UseVisualStyleBackColor = true;
            cbDeleting.CheckedChanged += cbDeleting_CheckedChanged;
            // 
            // cbCreating
            // 
            cbCreating.AutoSize = true;
            cbCreating.Location = new Point(164, 26);
            cbCreating.Name = "cbCreating";
            cbCreating.Size = new Size(90, 24);
            cbCreating.TabIndex = 7;
            cbCreating.Text = "Kreiranje";
            cbCreating.UseVisualStyleBackColor = true;
            cbCreating.CheckedChanged += cbCreating_CheckedChanged;
            // 
            // btnUploadDirectory
            // 
            btnUploadDirectory.Location = new Point(550, 358);
            btnUploadDirectory.Name = "btnUploadDirectory";
            btnUploadDirectory.Size = new Size(167, 29);
            btnUploadDirectory.TabIndex = 15;
            btnUploadDirectory.Text = "Odaberite direktorijum";
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
            gbFilesInTheDirectory.Text = "Trenutni fajlovi ";
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
            groupBox1.Size = new Size(525, 211);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Odaberite i kriptujte";
            // 
            // btnSelectFileToEncryptDecrypt
            // 
            btnSelectFileToEncryptDecrypt.Location = new Point(109, 176);
            btnSelectFileToEncryptDecrypt.Name = "btnSelectFileToEncryptDecrypt";
            btnSelectFileToEncryptDecrypt.Size = new Size(320, 29);
            btnSelectFileToEncryptDecrypt.TabIndex = 21;
            btnSelectFileToEncryptDecrypt.Text = "Odaberite fajl za kriptovanje/dekriptovanje";
            btnSelectFileToEncryptDecrypt.UseVisualStyleBackColor = true;
            btnSelectFileToEncryptDecrypt.Click += btnSelectFileToEncryptDecrypt_Click_1;
            // 
            // lblFileSize
            // 
            lblFileSize.AutoSize = true;
            lblFileSize.Location = new Point(6, 83);
            lblFileSize.Name = "lblFileSize";
            lblFileSize.Size = new Size(96, 20);
            lblFileSize.TabIndex = 17;
            lblFileSize.Text = "Velicina fajla:";
            // 
            // lblFileAttributes
            // 
            lblFileAttributes.AutoSize = true;
            lblFileAttributes.Location = new Point(330, 83);
            lblFileAttributes.Name = "lblFileAttributes";
            lblFileAttributes.Size = new Size(62, 20);
            lblFileAttributes.TabIndex = 15;
            lblFileAttributes.Text = "Atributi:";
            // 
            // lblFileDateModified
            // 
            lblFileDateModified.AutoSize = true;
            lblFileDateModified.Location = new Point(6, 141);
            lblFileDateModified.Name = "lblFileDateModified";
            lblFileDateModified.Size = new Size(143, 20);
            lblFileDateModified.TabIndex = 18;
            lblFileDateModified.Text = "Datum modifikacije:";
            // 
            // lblFileDateCreated
            // 
            lblFileDateCreated.AutoSize = true;
            lblFileDateCreated.Location = new Point(6, 110);
            lblFileDateCreated.Name = "lblFileDateCreated";
            lblFileDateCreated.Size = new Size(118, 20);
            lblFileDateCreated.TabIndex = 19;
            lblFileDateCreated.Text = "Datum kreiranja:";
            // 
            // lblFileExtension
            // 
            lblFileExtension.AutoSize = true;
            lblFileExtension.Location = new Point(178, 83);
            lblFileExtension.Name = "lblFileExtension";
            lblFileExtension.Size = new Size(77, 20);
            lblFileExtension.TabIndex = 20;
            lblFileExtension.Text = "Ekstenzija:";
            // 
            // lblFilePath
            // 
            lblFilePath.AutoSize = true;
            lblFilePath.Location = new Point(6, 23);
            lblFilePath.Name = "lblFilePath";
            lblFilePath.Size = new Size(65, 20);
            lblFilePath.TabIndex = 14;
            lblFilePath.Text = "Putanja: ";
            // 
            // lblFileName
            // 
            lblFileName.AutoSize = true;
            lblFileName.Location = new Point(6, 52);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(70, 20);
            lblFileName.TabIndex = 16;
            lblFileName.Text = "Ime fajla:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnDecryptSelectedFile);
            groupBox2.Controls.Add(rbRC6OFB);
            groupBox2.Controls.Add(rbBifid);
            groupBox2.Controls.Add(btnEncryptSelectedFile);
            groupBox2.Location = new Point(537, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(225, 211);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Odaberite algoritam ";
            // 
            // btnDecryptSelectedFile
            // 
            btnDecryptSelectedFile.Location = new Point(106, 176);
            btnDecryptSelectedFile.Name = "btnDecryptSelectedFile";
            btnDecryptSelectedFile.Size = new Size(113, 29);
            btnDecryptSelectedFile.TabIndex = 23;
            btnDecryptSelectedFile.Text = "Dekriptuj fajl";
            btnDecryptSelectedFile.UseVisualStyleBackColor = true;
            btnDecryptSelectedFile.Click += btnDecryptSelectedFile_Click_1;
            // 
            // rbRC6OFB
            // 
            rbRC6OFB.AutoSize = true;
            rbRC6OFB.Location = new Point(6, 106);
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
            rbBifid.CheckedChanged += rbBifid_CheckedChanged;
            // 
            // btnEncryptSelectedFile
            // 
            btnEncryptSelectedFile.Location = new Point(6, 176);
            btnEncryptSelectedFile.Name = "btnEncryptSelectedFile";
            btnEncryptSelectedFile.Size = new Size(94, 29);
            btnEncryptSelectedFile.TabIndex = 22;
            btnEncryptSelectedFile.Text = "Kriptuj fajl";
            btnEncryptSelectedFile.UseVisualStyleBackColor = true;
            btnEncryptSelectedFile.Click += btnEncryptSelectedFile_Click_1;
            // 
            // tabMainPage
            // 
            tabMainPage.Controls.Add(lblOutputXFolder);
            tabMainPage.Controls.Add(lblTargetFolder);
            tabMainPage.Controls.Add(btnChoseXFolder);
            tabMainPage.Controls.Add(btnChoseTargetFolder);
            tabMainPage.Controls.Add(groupBox9);
            tabMainPage.Controls.Add(groupBox8);
            tabMainPage.Location = new Point(4, 29);
            tabMainPage.Name = "tabMainPage";
            tabMainPage.Padding = new Padding(3);
            tabMainPage.Size = new Size(768, 392);
            tabMainPage.TabIndex = 0;
            tabMainPage.Text = "Main page";
            tabMainPage.UseVisualStyleBackColor = true;
            // 
            // lblOutputXFolder
            // 
            lblOutputXFolder.AutoSize = true;
            lblOutputXFolder.Location = new Point(198, 212);
            lblOutputXFolder.Name = "lblOutputXFolder";
            lblOutputXFolder.Size = new Size(65, 20);
            lblOutputXFolder.TabIndex = 5;
            lblOutputXFolder.Text = "X folder:";
            // 
            // lblTargetFolder
            // 
            lblTargetFolder.AutoSize = true;
            lblTargetFolder.Location = new Point(198, 155);
            lblTargetFolder.Name = "lblTargetFolder";
            lblTargetFolder.Size = new Size(101, 20);
            lblTargetFolder.TabIndex = 4;
            lblTargetFolder.Text = "Target folder: ";
            // 
            // btnChoseXFolder
            // 
            btnChoseXFolder.Location = new Point(6, 208);
            btnChoseXFolder.Name = "btnChoseXFolder";
            btnChoseXFolder.Size = new Size(186, 29);
            btnChoseXFolder.TabIndex = 3;
            btnChoseXFolder.Text = "Odaberite X folder";
            btnChoseXFolder.UseVisualStyleBackColor = true;
            btnChoseXFolder.Click += btnChoseXFolder_Click;
            // 
            // btnChoseTargetFolder
            // 
            btnChoseTargetFolder.Location = new Point(6, 151);
            btnChoseTargetFolder.Name = "btnChoseTargetFolder";
            btnChoseTargetFolder.Size = new Size(186, 29);
            btnChoseTargetFolder.TabIndex = 2;
            btnChoseTargetFolder.Text = "Odaberite Target folder";
            btnChoseTargetFolder.UseVisualStyleBackColor = true;
            btnChoseTargetFolder.Click += btnChoseTargetFolder_Click;
            // 
            // groupBox9
            // 
            groupBox9.Controls.Add(rtbAppLog);
            groupBox9.Location = new Point(3, 261);
            groupBox9.Name = "groupBox9";
            groupBox9.Size = new Size(759, 125);
            groupBox9.TabIndex = 1;
            groupBox9.TabStop = false;
            groupBox9.Text = "App log:";
            // 
            // rtbAppLog
            // 
            rtbAppLog.Location = new Point(6, 26);
            rtbAppLog.Name = "rtbAppLog";
            rtbAppLog.Size = new Size(747, 93);
            rtbAppLog.TabIndex = 2;
            rtbAppLog.Text = "";
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(lblLastActivity);
            groupBox8.Controls.Add(lblNumberOfDecryptedFiles);
            groupBox8.Controls.Add(label9);
            groupBox8.Controls.Add(lblNumberOfEncryptedFiles);
            groupBox8.Controls.Add(label11);
            groupBox8.Controls.Add(lblEncryptingAlgoStatus);
            groupBox8.Controls.Add(lblFSWStatus);
            groupBox8.Controls.Add(label8);
            groupBox8.Location = new Point(6, 6);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(756, 125);
            groupBox8.TabIndex = 0;
            groupBox8.TabStop = false;
            // 
            // lblLastActivity
            // 
            lblLastActivity.AutoSize = true;
            lblLastActivity.Location = new Point(6, 86);
            lblLastActivity.Name = "lblLastActivity";
            lblLastActivity.Size = new Size(138, 20);
            lblLastActivity.TabIndex = 8;
            lblLastActivity.Text = "Poslednja aktivnost:";
            // 
            // lblNumberOfDecryptedFiles
            // 
            lblNumberOfDecryptedFiles.AutoSize = true;
            lblNumberOfDecryptedFiles.Location = new Point(202, 55);
            lblNumberOfDecryptedFiles.Name = "lblNumberOfDecryptedFiles";
            lblNumberOfDecryptedFiles.Size = new Size(17, 20);
            lblNumberOfDecryptedFiles.TabIndex = 6;
            lblNumberOfDecryptedFiles.Text = "0";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 55);
            label9.Name = "label9";
            label9.Size = new Size(180, 20);
            label9.TabIndex = 5;
            label9.Text = "Broj dekriptovanih fajlova";
            // 
            // lblNumberOfEncryptedFiles
            // 
            lblNumberOfEncryptedFiles.AutoSize = true;
            lblNumberOfEncryptedFiles.Location = new Point(640, 23);
            lblNumberOfEncryptedFiles.Name = "lblNumberOfEncryptedFiles";
            lblNumberOfEncryptedFiles.Size = new Size(17, 20);
            lblNumberOfEncryptedFiles.TabIndex = 4;
            lblNumberOfEncryptedFiles.Text = "0";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(455, 23);
            label11.Name = "label11";
            label11.Size = new Size(179, 20);
            label11.TabIndex = 3;
            label11.Text = "Broj enkriptovanih fajlova";
            // 
            // lblEncryptingAlgoStatus
            // 
            lblEncryptingAlgoStatus.AutoSize = true;
            lblEncryptingAlgoStatus.Location = new Point(207, 23);
            lblEncryptingAlgoStatus.Name = "lblEncryptingAlgoStatus";
            lblEncryptingAlgoStatus.Size = new Size(210, 20);
            lblEncryptingAlgoStatus.TabIndex = 2;
            lblEncryptingAlgoStatus.Text = "RC6 + OFB kriptovanje aktivno";
            // 
            // lblFSWStatus
            // 
            lblFSWStatus.AutoSize = true;
            lblFSWStatus.Location = new Point(68, 23);
            lblFSWStatus.Name = "lblFSWStatus";
            lblFSWStatus.Size = new Size(133, 20);
            lblFSWStatus.TabIndex = 1;
            lblFSWStatus.Text = "FSW nije aktivan   |";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 23);
            label8.Name = "label8";
            label8.Size = new Size(56, 20);
            label8.TabIndex = 0;
            label8.Text = "Status: ";
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabMainPage);
            tabControl.Controls.Add(tabEncryptionSettingsPage);
            tabControl.Controls.Add(tabFSWSettingsPage);
            tabControl.Controls.Add(tabTCPClientSettingsPage);
            tabControl.Controls.Add(tabTCPServerSettingsPage);
            tabControl.Location = new Point(12, 31);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(776, 425);
            tabControl.TabIndex = 3;
            // 
            // tabTCPClientSettingsPage
            // 
            tabTCPClientSettingsPage.Controls.Add(groupBox12);
            tabTCPClientSettingsPage.Controls.Add(groupBox11);
            tabTCPClientSettingsPage.Controls.Add(groupBox10);
            tabTCPClientSettingsPage.Controls.Add(lblClientStatus);
            tabTCPClientSettingsPage.Location = new Point(4, 29);
            tabTCPClientSettingsPage.Name = "tabTCPClientSettingsPage";
            tabTCPClientSettingsPage.Padding = new Padding(3);
            tabTCPClientSettingsPage.Size = new Size(768, 392);
            tabTCPClientSettingsPage.TabIndex = 4;
            tabTCPClientSettingsPage.Text = "TCP client settings";
            tabTCPClientSettingsPage.UseVisualStyleBackColor = true;
            // 
            // groupBox12
            // 
            groupBox12.Controls.Add(rtbClientSettings);
            groupBox12.Location = new Point(6, 260);
            groupBox12.Name = "groupBox12";
            groupBox12.Size = new Size(753, 125);
            groupBox12.TabIndex = 11;
            groupBox12.TabStop = false;
            groupBox12.Text = "Log";
            // 
            // rtbClientSettings
            // 
            rtbClientSettings.Location = new Point(6, 19);
            rtbClientSettings.Name = "rtbClientSettings";
            rtbClientSettings.Size = new Size(741, 100);
            rtbClientSettings.TabIndex = 10;
            rtbClientSettings.Text = "";
            // 
            // groupBox11
            // 
            groupBox11.Controls.Add(lblChosenFile);
            groupBox11.Controls.Add(btnChoseFile);
            groupBox11.Controls.Add(btnSendFile);
            groupBox11.Location = new Point(6, 101);
            groupBox11.Name = "groupBox11";
            groupBox11.Size = new Size(756, 91);
            groupBox11.TabIndex = 9;
            groupBox11.TabStop = false;
            // 
            // lblChosenFile
            // 
            lblChosenFile.AutoSize = true;
            lblChosenFile.Location = new Point(6, 23);
            lblChosenFile.Name = "lblChosenFile";
            lblChosenFile.Size = new Size(95, 20);
            lblChosenFile.TabIndex = 1;
            lblChosenFile.Text = "Odabran fajl:";
            // 
            // btnChoseFile
            // 
            btnChoseFile.Location = new Point(197, 56);
            btnChoseFile.Name = "btnChoseFile";
            btnChoseFile.Size = new Size(107, 29);
            btnChoseFile.TabIndex = 6;
            btnChoseFile.Text = "Odaberi fajl";
            btnChoseFile.UseVisualStyleBackColor = true;
            btnChoseFile.Click += btnChoseFile_Click;
            // 
            // btnSendFile
            // 
            btnSendFile.Location = new Point(412, 56);
            btnSendFile.Name = "btnSendFile";
            btnSendFile.Size = new Size(106, 29);
            btnSendFile.TabIndex = 5;
            btnSendFile.Text = "Posalji fajl";
            btnSendFile.UseVisualStyleBackColor = true;
            btnSendFile.Click += btnSendFile_Click;
            // 
            // groupBox10
            // 
            groupBox10.Controls.Add(label3);
            groupBox10.Controls.Add(tbIPAddress);
            groupBox10.Controls.Add(label5);
            groupBox10.Controls.Add(tbPort);
            groupBox10.Location = new Point(3, 6);
            groupBox10.Name = "groupBox10";
            groupBox10.Size = new Size(759, 70);
            groupBox10.TabIndex = 8;
            groupBox10.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 31);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 0;
            label3.Text = "IP adresa:";
            // 
            // tbIPAddress
            // 
            tbIPAddress.Location = new Point(91, 28);
            tbIPAddress.Name = "tbIPAddress";
            tbIPAddress.Size = new Size(125, 27);
            tbIPAddress.TabIndex = 3;
            tbIPAddress.Text = "127.0.0.1";
            tbIPAddress.TextAlign = HorizontalAlignment.Center;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(287, 31);
            label5.Name = "label5";
            label5.Size = new Size(38, 20);
            label5.TabIndex = 2;
            label5.Text = "Port:";
            // 
            // tbPort
            // 
            tbPort.Location = new Point(331, 28);
            tbPort.Name = "tbPort";
            tbPort.Size = new Size(125, 27);
            tbPort.TabIndex = 4;
            tbPort.Text = "5000";
            tbPort.TextAlign = HorizontalAlignment.Center;
            // 
            // lblClientStatus
            // 
            lblClientStatus.AutoSize = true;
            lblClientStatus.Location = new Point(12, 207);
            lblClientStatus.Name = "lblClientStatus";
            lblClientStatus.Size = new Size(52, 20);
            lblClientStatus.TabIndex = 7;
            lblClientStatus.Text = "Status:";
            // 
            // tabTCPServerSettingsPage
            // 
            tabTCPServerSettingsPage.Controls.Add(groupBox14);
            tabTCPServerSettingsPage.Controls.Add(groupBox13);
            tabTCPServerSettingsPage.Location = new Point(4, 29);
            tabTCPServerSettingsPage.Name = "tabTCPServerSettingsPage";
            tabTCPServerSettingsPage.Padding = new Padding(3);
            tabTCPServerSettingsPage.Size = new Size(768, 392);
            tabTCPServerSettingsPage.TabIndex = 5;
            tabTCPServerSettingsPage.Text = "TCP server settings";
            tabTCPServerSettingsPage.UseVisualStyleBackColor = true;
            // 
            // groupBox14
            // 
            groupBox14.Controls.Add(textBox1);
            groupBox14.Controls.Add(label4);
            groupBox14.Controls.Add(lblServerStatus);
            groupBox14.Controls.Add(btnStartListening);
            groupBox14.Controls.Add(btnStopListening);
            groupBox14.Location = new Point(6, 6);
            groupBox14.Name = "groupBox14";
            groupBox14.Size = new Size(756, 125);
            groupBox14.TabIndex = 6;
            groupBox14.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(98, 26);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 2;
            textBox1.Text = "5000";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 29);
            label4.Name = "label4";
            label4.Size = new Size(38, 20);
            label4.TabIndex = 1;
            label4.Text = "Port:";
            // 
            // lblServerStatus
            // 
            lblServerStatus.AutoSize = true;
            lblServerStatus.Location = new Point(11, 78);
            lblServerStatus.Name = "lblServerStatus";
            lblServerStatus.Size = new Size(49, 20);
            lblServerStatus.TabIndex = 4;
            lblServerStatus.Text = "Status";
            // 
            // btnStartListening
            // 
            btnStartListening.Location = new Point(285, 25);
            btnStartListening.Name = "btnStartListening";
            btnStartListening.Size = new Size(131, 29);
            btnStartListening.TabIndex = 0;
            btnStartListening.Text = "Pokreni slusanje";
            btnStartListening.UseVisualStyleBackColor = true;
            btnStartListening.Click += btnStartListening_Click;
            // 
            // btnStopListening
            // 
            btnStopListening.Location = new Point(481, 25);
            btnStopListening.Name = "btnStopListening";
            btnStopListening.Size = new Size(122, 29);
            btnStopListening.TabIndex = 3;
            btnStopListening.Text = "Prekini slusanje";
            btnStopListening.UseVisualStyleBackColor = true;
            btnStopListening.Click += btnStopListening_Click;
            // 
            // groupBox13
            // 
            groupBox13.Controls.Add(rtbServerSettings);
            groupBox13.Location = new Point(6, 156);
            groupBox13.Name = "groupBox13";
            groupBox13.Size = new Size(756, 230);
            groupBox13.TabIndex = 5;
            groupBox13.TabStop = false;
            groupBox13.Text = "Log";
            // 
            // rtbServerSettings
            // 
            rtbServerSettings.Location = new Point(6, 28);
            rtbServerSettings.Name = "rtbServerSettings";
            rtbServerSettings.Size = new Size(744, 196);
            rtbServerSettings.TabIndex = 0;
            rtbServerSettings.Text = "";
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
            tabMainPage.ResumeLayout(false);
            tabMainPage.PerformLayout();
            groupBox9.ResumeLayout(false);
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            tabControl.ResumeLayout(false);
            tabTCPClientSettingsPage.ResumeLayout(false);
            tabTCPClientSettingsPage.PerformLayout();
            groupBox12.ResumeLayout(false);
            groupBox11.ResumeLayout(false);
            groupBox11.PerformLayout();
            groupBox10.ResumeLayout(false);
            groupBox10.PerformLayout();
            tabTCPServerSettingsPage.ResumeLayout(false);
            groupBox14.ResumeLayout(false);
            groupBox14.PerformLayout();
            groupBox13.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mainPageToolStripMenuItem;
        private ToolStripMenuItem encryptionToolStripMenuItem;
        private ToolStripMenuItem encryptionSettingsToolStripMenuItem;
        private ToolStripMenuItem tCPToolStripMenuItem;
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
        private GroupBox groupBox8;
        private Label lblNumberOfEncryptedFiles;
        private Label label11;
        private Label lblEncryptingAlgoStatus;
        private Label lblFSWStatus;
        private Label label8;
        private GroupBox groupBox9;
        private RichTextBox rtbAppLog;
        private Label lblLastActivity;
        private Label lblNumberOfDecryptedFiles;
        private Label label9;
        private Label lblOutputXFolder;
        private Label lblTargetFolder;
        private Button btnChoseXFolder;
        private Button btnChoseTargetFolder;
        private GroupBox groupBox10;
        private GroupBox groupBox11;
        private RichTextBox rtbClientSettings;
        private GroupBox groupBox12;
        private GroupBox groupBox13;
        private RichTextBox rtbServerSettings;
        private GroupBox groupBox14;
    }
}