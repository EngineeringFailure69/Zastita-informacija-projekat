namespace Encryption_Exchange_App
{
    partial class UCEncryption
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
            rbBifid = new RadioButton();
            rbRC6OFB = new RadioButton();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // rbBifid
            // 
            rbBifid.AutoSize = true;
            rbBifid.Location = new Point(6, 39);
            rbBifid.Name = "rbBifid";
            rbBifid.Size = new Size(61, 24);
            rbBifid.TabIndex = 0;
            rbBifid.TabStop = true;
            rbBifid.Text = "Bifid";
            rbBifid.UseVisualStyleBackColor = true;
            rbBifid.CheckedChanged += rbBifid_CheckedChanged;
            // 
            // rbRC6OFB
            // 
            rbRC6OFB.AutoSize = true;
            rbRC6OFB.Location = new Point(6, 78);
            rbRC6OFB.Name = "rbRC6OFB";
            rbRC6OFB.Size = new Size(101, 24);
            rbRC6OFB.TabIndex = 1;
            rbRC6OFB.TabStop = true;
            rbRC6OFB.Text = "RC6 + OFB";
            rbRC6OFB.UseVisualStyleBackColor = true;
            rbRC6OFB.CheckedChanged += rbRC6OFB_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbRC6OFB);
            groupBox1.Controls.Add(rbBifid);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 125);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Pick the encryption algorithm ";
            // 
            // UCEncryption
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Name = "UCEncryption";
            Size = new Size(776, 407);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private RadioButton rbBifid;
        private RadioButton rbRC6OFB;
        private GroupBox groupBox1;
    }
}
