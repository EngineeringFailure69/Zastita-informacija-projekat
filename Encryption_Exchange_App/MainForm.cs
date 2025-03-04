namespace Encryption_Exchange_App
{
    public partial class MainForm : Form
    {
        public bool IsFSWEnabled = false;

        public MainForm()
        {
            InitializeComponent();
            LoadUserControl(new UCMain());
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
            LoadUserControl(new UCFSW(this));
        }
    }
}
