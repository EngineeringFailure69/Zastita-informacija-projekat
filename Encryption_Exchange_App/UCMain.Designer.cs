namespace Encryption_Exchange_App
{
    partial class UCMain
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
            btnSelectFileToEncrypt = new Button();
            btnEncryptSelectedFile = new Button();
            groupBox1 = new GroupBox();
            btnDecryptSelectedFile = new Button();
            lblFileSize = new Label();
            lblFileAttributes = new Label();
            lblFileDateModified = new Label();
            lblFileDateCreated = new Label();
            lblFileExtension = new Label();
            lblFilePath = new Label();
            lblFileName = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnSelectFileToEncrypt
            // 
            btnSelectFileToEncrypt.Location = new Point(265, 231);
            btnSelectFileToEncrypt.Name = "btnSelectFileToEncrypt";
            btnSelectFileToEncrypt.Size = new Size(216, 29);
            btnSelectFileToEncrypt.TabIndex = 7;
            btnSelectFileToEncrypt.Text = "Select file to encrypt/decrypt";
            btnSelectFileToEncrypt.UseVisualStyleBackColor = true;
            btnSelectFileToEncrypt.Click += btnSelectFileToEncrypt_Click;
            // 
            // btnEncryptSelectedFile
            // 
            btnEncryptSelectedFile.Location = new Point(129, 231);
            btnEncryptSelectedFile.Name = "btnEncryptSelectedFile";
            btnEncryptSelectedFile.Size = new Size(94, 29);
            btnEncryptSelectedFile.TabIndex = 8;
            btnEncryptSelectedFile.Text = "Encrypt file";
            btnEncryptSelectedFile.UseVisualStyleBackColor = true;
            btnEncryptSelectedFile.Click += btnEncryptSelectedFile_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDecryptSelectedFile);
            groupBox1.Controls.Add(lblFileSize);
            groupBox1.Controls.Add(lblFileAttributes);
            groupBox1.Controls.Add(lblFileDateModified);
            groupBox1.Controls.Add(lblFileDateCreated);
            groupBox1.Controls.Add(lblFileExtension);
            groupBox1.Controls.Add(lblFilePath);
            groupBox1.Controls.Add(lblFileName);
            groupBox1.Controls.Add(btnEncryptSelectedFile);
            groupBox1.Controls.Add(btnSelectFileToEncrypt);
            groupBox1.Location = new Point(3, 11);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(751, 266);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Select and Encrypt";
            // 
            // btnDecryptSelectedFile
            // 
            btnDecryptSelectedFile.Location = new Point(529, 231);
            btnDecryptSelectedFile.Name = "btnDecryptSelectedFile";
            btnDecryptSelectedFile.Size = new Size(94, 29);
            btnDecryptSelectedFile.TabIndex = 14;
            btnDecryptSelectedFile.Text = "Decrypt file";
            btnDecryptSelectedFile.UseVisualStyleBackColor = true;
            btnDecryptSelectedFile.Click += btnDecryptSelectedFile_Click;
            // 
            // lblFileSize
            // 
            lblFileSize.AutoSize = true;
            lblFileSize.Location = new Point(6, 83);
            lblFileSize.Name = "lblFileSize";
            lblFileSize.Size = new Size(68, 20);
            lblFileSize.TabIndex = 11;
            lblFileSize.Text = "File size: ";
            // 
            // lblFileAttributes
            // 
            lblFileAttributes.AutoSize = true;
            lblFileAttributes.Location = new Point(6, 203);
            lblFileAttributes.Name = "lblFileAttributes";
            lblFileAttributes.Size = new Size(77, 20);
            lblFileAttributes.TabIndex = 10;
            lblFileAttributes.Text = "Attributes:";
            // 
            // lblFileDateModified
            // 
            lblFileDateModified.AutoSize = true;
            lblFileDateModified.Location = new Point(6, 173);
            lblFileDateModified.Name = "lblFileDateModified";
            lblFileDateModified.Size = new Size(109, 20);
            lblFileDateModified.TabIndex = 11;
            lblFileDateModified.Text = "Date Modified:";
            // 
            // lblFileDateCreated
            // 
            lblFileDateCreated.AutoSize = true;
            lblFileDateCreated.Location = new Point(6, 143);
            lblFileDateCreated.Name = "lblFileDateCreated";
            lblFileDateCreated.Size = new Size(98, 20);
            lblFileDateCreated.TabIndex = 12;
            lblFileDateCreated.Text = "Date created:";
            // 
            // lblFileExtension
            // 
            lblFileExtension.AutoSize = true;
            lblFileExtension.Location = new Point(6, 113);
            lblFileExtension.Name = "lblFileExtension";
            lblFileExtension.Size = new Size(75, 20);
            lblFileExtension.TabIndex = 13;
            lblFileExtension.Text = "Extension:";
            // 
            // lblFilePath
            // 
            lblFilePath.AutoSize = true;
            lblFilePath.Location = new Point(6, 23);
            lblFilePath.Name = "lblFilePath";
            lblFilePath.Size = new Size(44, 20);
            lblFilePath.TabIndex = 9;
            lblFilePath.Text = "Path: ";
            // 
            // lblFileName
            // 
            lblFileName.AutoSize = true;
            lblFileName.Location = new Point(6, 53);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(80, 20);
            lblFileName.TabIndex = 10;
            lblFileName.Text = "File name: ";
            // 
            // UCMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Name = "UCMain";
            Size = new Size(776, 407);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnSelectFileToEncrypt;
        private Button btnEncryptSelectedFile;
        private GroupBox groupBox1;
        private Label lblFilePath;
        private Label lblFileSize;
        private Label lblFileName;
        private Label lblFileAttributes;
        private Label lblFileDateModified;
        private Label lblFileDateCreated;
        private Label lblFileExtension;
        private Button btnDecryptSelectedFile;
    }
}
