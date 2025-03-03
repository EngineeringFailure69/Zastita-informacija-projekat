using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encryption_Exchange_App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void LoadUserControl(UserControl uc)
        {
            UCPanel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            UCPanel.Controls.Add(uc);
        }

        private void mainPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCMain());
        }

        private void EncryptionSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCEncryption());
        }

        private void MultithreadingSettingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCMultithreading());
        }

        private void FSWSettingsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCFSW());
        }
    }
}
