namespace Encryption_Exchange_App
{
    partial class MainForm
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
            menuStrip1 = new MenuStrip();
            mainPageToolStripMenuItem = new ToolStripMenuItem();
            encryptionToolStripMenuItem = new ToolStripMenuItem();
            EncryptionSettingsToolStripMenuItem = new ToolStripMenuItem();
            multithreadingToolStripMenuItem = new ToolStripMenuItem();
            MultithreadingSettingsToolStripMenuItem1 = new ToolStripMenuItem();
            FSWToolStripMenuItem = new ToolStripMenuItem();
            FSWSettingsToolStripMenuItem2 = new ToolStripMenuItem();
            UCPanel = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mainPageToolStripMenuItem, encryptionToolStripMenuItem, multithreadingToolStripMenuItem, FSWToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
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
            encryptionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { EncryptionSettingsToolStripMenuItem });
            encryptionToolStripMenuItem.Name = "encryptionToolStripMenuItem";
            encryptionToolStripMenuItem.Size = new Size(93, 24);
            encryptionToolStripMenuItem.Text = "Encryption";
            // 
            // EncryptionSettingsToolStripMenuItem
            // 
            EncryptionSettingsToolStripMenuItem.Name = "EncryptionSettingsToolStripMenuItem";
            EncryptionSettingsToolStripMenuItem.Size = new Size(145, 26);
            EncryptionSettingsToolStripMenuItem.Text = "Settings";
            EncryptionSettingsToolStripMenuItem.Click += EncryptionSettingsToolStripMenuItem_Click;
            // 
            // multithreadingToolStripMenuItem
            // 
            multithreadingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { MultithreadingSettingsToolStripMenuItem1 });
            multithreadingToolStripMenuItem.Name = "multithreadingToolStripMenuItem";
            multithreadingToolStripMenuItem.Size = new Size(121, 24);
            multithreadingToolStripMenuItem.Text = "Multithreading";
            // 
            // MultithreadingSettingsToolStripMenuItem1
            // 
            MultithreadingSettingsToolStripMenuItem1.Name = "MultithreadingSettingsToolStripMenuItem1";
            MultithreadingSettingsToolStripMenuItem1.Size = new Size(224, 26);
            MultithreadingSettingsToolStripMenuItem1.Text = "Settings";
            MultithreadingSettingsToolStripMenuItem1.Click += MultithreadingSettingsToolStripMenuItem1_Click;
            // 
            // FSWToolStripMenuItem
            // 
            FSWToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { FSWSettingsToolStripMenuItem2 });
            FSWToolStripMenuItem.Name = "FSWToolStripMenuItem";
            FSWToolStripMenuItem.Size = new Size(52, 24);
            FSWToolStripMenuItem.Text = "FSW";
            // 
            // FSWSettingsToolStripMenuItem2
            // 
            FSWSettingsToolStripMenuItem2.Name = "FSWSettingsToolStripMenuItem2";
            FSWSettingsToolStripMenuItem2.Size = new Size(224, 26);
            FSWSettingsToolStripMenuItem2.Text = "Settings";
            FSWSettingsToolStripMenuItem2.Click += FSWSettingsToolStripMenuItem2_Click;
            // 
            // UCPanel
            // 
            UCPanel.Location = new Point(12, 31);
            UCPanel.Name = "UCPanel";
            UCPanel.Size = new Size(776, 407);
            UCPanel.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(UCPanel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "MainForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mainPageToolStripMenuItem;
        private ToolStripMenuItem encryptionToolStripMenuItem;
        private ToolStripMenuItem EncryptionSettingsToolStripMenuItem;
        private ToolStripMenuItem multithreadingToolStripMenuItem;
        private ToolStripMenuItem MultithreadingSettingsToolStripMenuItem1;
        private ToolStripMenuItem FSWToolStripMenuItem;
        private ToolStripMenuItem FSWSettingsToolStripMenuItem2;
        private Panel UCPanel;
    }
}