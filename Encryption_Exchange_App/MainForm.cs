namespace Encryption_Exchange_App
{
    public partial class MainForm : Form
    {
        public bool IsFSWEnabled = false;
        public bool IsCreatingChecked = false;
        UCMain uCMain;
        public MainForm()
        {
            InitializeComponent();
            uCMain = new UCMain(this);
            LoadUserControl(new UCMain(this));
        }
        private void LoadUserControl(UserControl uc)
        {
            UCPanel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            UCPanel.Controls.Add(uc);
        }
        public void ReceiveNewFile(string filePath, bool EncryptDecrypt, string? savePath)
        {
            uCMain.HandleNewFile(filePath, EncryptDecrypt, savePath);
        }
        private void mainPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCMain(this));
        }
        private void EncryptionSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCEncryption(this));
        }
        private void MultithreadingSettingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCMultithreading());
        }
        private void FSWSettingsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCFSW(this));
        }
    }
}
