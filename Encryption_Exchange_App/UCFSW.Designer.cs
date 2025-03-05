namespace Encryption_Exchange_App
{
    partial class UCFSW
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cbEnableDisable = new CheckBox();
            label1 = new Label();
            lblStatus = new Label();
            lvCurrentFiles = new ListView();
            gbFilesInTheDirectory = new GroupBox();
            btnUploadDirectory = new Button();
            cbCreating = new CheckBox();
            cbDeleting = new CheckBox();
            cbRenaming = new CheckBox();
            cbDataChange = new CheckBox();
            groupBox1 = new GroupBox();
            label2 = new Label();
            gbFilesInTheDirectory.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 52);
            label1.Name = "label1";
            label1.Size = new Size(87, 20);
            label1.TabIndex = 1;
            label1.Text = "FSW status: ";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(99, 52);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(56, 20);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "status...";
            // 
            // lvCurrentFiles
            // 
            lvCurrentFiles.Location = new Point(6, 26);
            lvCurrentFiles.Name = "lvCurrentFiles";
            lvCurrentFiles.Size = new Size(249, 226);
            lvCurrentFiles.TabIndex = 3;
            lvCurrentFiles.UseCompatibleStateImageBehavior = false;
            // 
            // gbFilesInTheDirectory
            // 
            gbFilesInTheDirectory.Controls.Add(lvCurrentFiles);
            gbFilesInTheDirectory.Location = new Point(501, 95);
            gbFilesInTheDirectory.Name = "gbFilesInTheDirectory";
            gbFilesInTheDirectory.Size = new Size(263, 258);
            gbFilesInTheDirectory.TabIndex = 4;
            gbFilesInTheDirectory.TabStop = false;
            gbFilesInTheDirectory.Text = "Current files in the target directory ";
            // 
            // btnUploadDirectory
            // 
            btnUploadDirectory.Location = new Point(562, 359);
            btnUploadDirectory.Name = "btnUploadDirectory";
            btnUploadDirectory.Size = new Size(146, 29);
            btnUploadDirectory.TabIndex = 5;
            btnUploadDirectory.Text = "Upload directory";
            btnUploadDirectory.UseVisualStyleBackColor = true;
            btnUploadDirectory.Click += btnUploadDirectory_Click;
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
            // cbDataChange
            // 
            cbDataChange.AutoSize = true;
            cbDataChange.Location = new Point(468, 26);
            cbDataChange.Name = "cbDataChange";
            cbDataChange.Size = new Size(115, 24);
            cbDataChange.TabIndex = 10;
            cbDataChange.Text = "Data change";
            cbDataChange.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbEnableDisable);
            groupBox1.Controls.Add(cbDataChange);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cbRenaming);
            groupBox1.Controls.Add(lblStatus);
            groupBox1.Controls.Add(cbDeleting);
            groupBox1.Controls.Add(cbCreating);
            groupBox1.Location = new Point(3, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(583, 83);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tracking";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 121);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 12;
            label2.Text = "label2";
            // 
            // UCFSW
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label2);
            Controls.Add(groupBox1);
            Controls.Add(btnUploadDirectory);
            Controls.Add(gbFilesInTheDirectory);
            Name = "UCFSW";
            Size = new Size(776, 407);
            VisibleChanged += UCFSW_VisibleChanged_1;
            gbFilesInTheDirectory.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox cbEnableDisable;
        private Label label1;
        private Label lblStatus;
        private ListView lvCurrentFiles;
        private GroupBox gbFilesInTheDirectory;
        private Button btnUploadDirectory;
        private CheckBox cbCreating;
        private CheckBox cbDeleting;
        private CheckBox cbRenaming;
        private CheckBox cbDataChange;
        private GroupBox groupBox1;
        private Label label2;
    }
}
