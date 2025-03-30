namespace Encryption_Exchange_App
{
    public partial class Main : Form
    {
        private EncryptionFunctionalities encryptionFunctionalities;
        private FSWFunctionalities fSWFunctionalities;
        private TCPFunctionalities tCPFunctionalities;
        private GlobalFunctionalities globalFunctionalities;
        private MainFunctionalities mainFunctionalities;
        private RC6OFB rc6ofb;
        private Bifid bifid;

        private string selectedFilePath = string.Empty;

        private FileSystemWatcher watcher;
        private Queue<String> filesToUpload;

        private Socket serverSocket;

        public Main()
        {
            InitializeComponent();
            StartStyle();

            watcher = new FileSystemWatcher();
            filesToUpload = new Queue<string>();
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            mainFunctionalities = new MainFunctionalities();
            encryptionFunctionalities = new EncryptionFunctionalities(lblNumberOfEncryptedFiles, lblNumberOfDecryptedFiles, lblLastActivity, rtbAppLog);
            globalFunctionalities = new GlobalFunctionalities();

            rc6ofb = new RC6OFB();
            bifid = new Bifid();

            fSWFunctionalities = new FSWFunctionalities(this, cbEnableDisable, cbCreating, cbDeleting,
                cbRenaming, this, lvCurrentFiles, rbBifid, watcher, filesToUpload, rcbLog, lblNumber, 
                lblNumberOfEncryptedFiles, lblLastActivity,  rtbAppLog);

            tCPFunctionalities = new TCPFunctionalities(this, rbBifid, tbIPAddress, tbPort, lblClientStatus,
                 lblServerStatus, this, serverSocket);
        }

        public void StartStyle()
        {
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;

            lblStatus.Text = "";
            lblStatus.Enabled = false;
            label1.Enabled = false;
            cbCreating.Enabled = false;
            cbDeleting.Enabled = false;
            cbRenaming.Enabled = false;
            btnUploadDirectory.Enabled = false;
            lblNumber.Text = "";

            lblFilePath.AutoSize = false;
            lblFilePath.Width = 520;
            lblFilePath.MaximumSize = new Size(520, 20);
            lblFilePath.TextAlign = ContentAlignment.MiddleLeft; // Poravnanje teksta
            lblFilePath.AutoEllipsis = true; // Prikazuje "..." ako tekst ne stane

            lblFileName.AutoSize = false;
            lblFileName.Width = 520;
            lblFileName.MaximumSize = new Size(520, 20);
            lblFileName.TextAlign = ContentAlignment.MiddleLeft;
            lblFileName.AutoEllipsis = true;

            lblFSWStatus.Text = "FSW inactive   |";
            lblEncryptingAlgoStatus.Text = "Bifid encrypting active";

            lvCurrentFiles.View = View.Details;
            lvCurrentFiles.Columns.Add("File names: ", lvCurrentFiles.Width, HorizontalAlignment.Left);
        }

        #region Menu
        private void mainPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabMainPage;
        }
        private void encryptionSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabEncryptionSettingsPage;
        }
        private void FSWSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabFSWSettingsPage;
        }
        private void TCPSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabTCPSettingsPage;
        }
        private void serverSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabTCPServerSettingsPage;
        }
        private void clientSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabTCPClientSettingsPage;
        }
        #endregion

        #region EncryptionFunctionalities
        private void btnSelectFileToEncryptDecrypt_Click_1(object sender, EventArgs e)
        {
            encryptionFunctionalities.btnSelectFileToEncryptDecryptClick(lblFileAttributes, lblFileDateCreated,
                lblFileDateModified, lblFileExtension, lblFileName, lblFilePath, lblFileSize, cbEnableDisable);
        }
        private void btnEncryptSelectedFile_Click_1(object sender, EventArgs e)
        {
            encryptionFunctionalities.btnEncryptSelectedFileClick(rbBifid, cbEnableDisable, rtbLog,
                lblFileAttributes, lblFileDateCreated, lblFileDateModified, lblFileExtension, lblFileName,
                lblFilePath, lblFileSize);
        }
        private void btnDecryptSelectedFile_Click_1(object sender, EventArgs e)
        {
            encryptionFunctionalities.btnDecryptSelectedFileClick(rbBifid, cbEnableDisable, rtbLog,
            lblFileAttributes, lblFileDateCreated, lblFileDateModified, lblFileExtension, lblFileName,
            lblFilePath, lblFileSize);
        }
        private void rbBifid_CheckedChanged(object sender, EventArgs e)
        {
            lblEncryptingAlgoStatus.Text = (rbBifid.Checked) ? "Bifid encrypting active" : "RC6 + OFB encrypting active";
        }
        #endregion

        #region FSWFunctionalities
        private void cbEnableDisable_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEnableDisable.Checked == true)
            {
                lblStatus.BackColor = Color.Green;
                lblStatus.Text = "Running";
                lblFSWStatus.Text = "FSW active     |";
                cbCreating.Enabled = true;
                cbDeleting.Enabled = true;
                cbRenaming.Enabled = true;
                btnUploadDirectory.Enabled = true;

                fSWFunctionalities.SetWatcher();
            }
            else if (cbEnableDisable.Checked == false)
            {
                lblStatus.BackColor = Color.Red;
                lblStatus.Text = "Stopped";
                lblFSWStatus.Text = "FSW inactive   |";
                cbCreating.Enabled = false;
                cbDeleting.Enabled = false;
                cbRenaming.Enabled = false;
                cbCreating.Checked = false;
                cbDeleting.Checked = false;
                cbRenaming.Checked = false;
                btnUploadDirectory.Enabled = false;

                lvCurrentFiles.Items.Clear();
                fSWFunctionalities.EmptyQueue();
            }
        }
        private void btnUploadDirectory_Click(object sender, EventArgs e)
        {
            fSWFunctionalities.btnUploadFolder();
        }
        private void cbCreating_CheckedChanged(object sender, EventArgs e)
        {
            fSWFunctionalities.cbCreatingCheckChanged();
        }
        private void cbDeleting_CheckedChanged(object sender, EventArgs e)
        {
            fSWFunctionalities.cbDeletingCheckChanged();
        }
        private void cbRenaming_CheckedChanged(object sender, EventArgs e)
        {
            fSWFunctionalities.cbRenamingCheckChanged();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("FSW folder icon, you know, a lil bit of style won't hurt ;)");
        }
        #endregion

        #region TCPFunctionalities
        private void btnChoseFile_Click(object sender, EventArgs e)
        {
            if (cbEnableDisable.Checked == false)
            {
                selectedFilePath = globalFunctionalities.ChoseFile();
                this.lblChosenFile.Text = selectedFilePath;

                tCPFunctionalities.UpdateStatus(lblClientStatus, $"Odabran je fajl: {lblChosenFile.Text}");
            }
            else
            {
                MessageBox.Show("FSW mora biti iskljucen");
            }
        }
        private void btnSendFile_Click(object sender, EventArgs e)
        {
            Task task = Task.Run(() =>
            {
                tCPFunctionalities.AdvanceKlijent(selectedFilePath);
            });
        }
        private void btnStartListening_Click(object sender, EventArgs e)
        {
            Task task = Task.Run(() =>
            {
                tCPFunctionalities.AdvanceServer();
            });
        }
        private void btnStopListening_Click(object sender, EventArgs e)
        {
            try
            {
                serverSocket?.Close();
                tCPFunctionalities.UpdateStatus(lblServerStatus, "Server je zaustavljen.");
            }
            catch (Exception ex)
            {
                tCPFunctionalities.UpdateStatus(lblServerStatus, $"Greška u prekidu slušanja: {ex.Message}");
            }
        }
        #endregion

        #region MainFunctionalities
        private void btnChoseTargetFolder_Click(object sender, EventArgs e)
        {
            string folderPath = globalFunctionalities.ChoseFolder();
            fSWFunctionalities.SetTargetDirectory(folderPath);
            lblTargetFolder.Text += folderPath;
        }
        private void btnChoseXFolder_Click(object sender, EventArgs e)
        {
            string folderPath = globalFunctionalities.ChoseFolder();
            rc6ofb.SetXDirectory(folderPath);
            bifid.SetXDirectory(folderPath);
            lblOutputXFolder.Text += folderPath;
        }
        #endregion
    }
}