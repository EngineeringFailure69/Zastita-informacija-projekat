namespace Encryption_Exchange_App
{
    public partial class Main : Form
    {
        private EncryptionFunctionalities encryptionFunctionalities;
        private FSWFunctionalities fSWFunctionalities;
        private TCPFunctionalities tCPFunctionalities;
        private GlobalFunctionalities globalFunctionalities;
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

            encryptionFunctionalities = new EncryptionFunctionalities(lblNumberOfEncryptedFiles, lblNumberOfDecryptedFiles, lblLastActivity, rtbAppLog);
            globalFunctionalities = new GlobalFunctionalities();

            rc6ofb = new RC6OFB();
            bifid = new Bifid();

            fSWFunctionalities = new FSWFunctionalities(this, cbEnableDisable, cbCreating, cbDeleting,
                cbRenaming, this, lvCurrentFiles, rbBifid, watcher, filesToUpload, rcbLog, lblNumber, 
                lblNumberOfEncryptedFiles, lblLastActivity,  rtbAppLog);

            tCPFunctionalities = new TCPFunctionalities(this, rbBifid, tbIPAddress, tbPort, lblClientStatus,
                 lblServerStatus, this, serverSocket, rtbClientSettings, rtbAppLog, rtbServerSettings);
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

            lblLastActivity.AutoSize = false;
            lblLastActivity.Width = 750;
            lblLastActivity.MaximumSize = new Size(750, 20);
            lblLastActivity.TextAlign = ContentAlignment.MiddleLeft;
            lblLastActivity.AutoEllipsis = true;

            lblFSWStatus.Text = "FSW neaktivan  |";
            lblEncryptingAlgoStatus.Text = "Bifid enkripcija aktivna";

            lvCurrentFiles.View = View.Details;
            lvCurrentFiles.Columns.Add("Naziv fajlova: ", lvCurrentFiles.Width, HorizontalAlignment.Left);
        }

        #region Menu
        private void mainPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl.SelectedTab = tabMainPage;
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Greska: {ex.Message}");
            }
        }
        private void encryptionSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try 
            {
                tabControl.SelectedTab = tabEncryptionSettingsPage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message}");
            }
        }
        private void FSWSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try 
            {
                tabControl.SelectedTab = tabFSWSettingsPage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message}");
            }
        }
        private void serverSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try 
            {
                tabControl.SelectedTab = tabTCPServerSettingsPage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message}");
            }
        }
        private void clientSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try 
            {
                tabControl.SelectedTab = tabTCPClientSettingsPage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message}");
            }
        }
        #endregion

        #region EncryptionFunctionalities
        private void btnSelectFileToEncryptDecrypt_Click_1(object sender, EventArgs e)
        {
            try 
            {
                encryptionFunctionalities.btnSelectFileToEncryptDecryptClick(lblFileAttributes, lblFileDateCreated,
                    lblFileDateModified, lblFileExtension, lblFileName, lblFilePath, lblFileSize, cbEnableDisable);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message}");
            }
        }
        private void btnEncryptSelectedFile_Click_1(object sender, EventArgs e)
        {
            try 
            {
                encryptionFunctionalities.btnEncryptSelectedFileClick(rbBifid, cbEnableDisable, rtbLog,
                    lblFileAttributes, lblFileDateCreated, lblFileDateModified, lblFileExtension, lblFileName,
                    lblFilePath, lblFileSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message}");
            }
        }
        private void btnDecryptSelectedFile_Click_1(object sender, EventArgs e)
        {
            try 
            {
                encryptionFunctionalities.btnDecryptSelectedFileClick(rbBifid, cbEnableDisable, rtbLog,
                    lblFileAttributes, lblFileDateCreated, lblFileDateModified, lblFileExtension, lblFileName,
                        lblFilePath, lblFileSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message}");
            }
        }
        private void rbBifid_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                lblEncryptingAlgoStatus.Text = (rbBifid.Checked) ? "Bifid encrypting active" : "RC6 + OFB encrypting active";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message}");
            }
        }
        #endregion

        #region FSWFunctionalities
        private void cbEnableDisable_CheckedChanged(object sender, EventArgs e)
        {
            try 
            {
                if (cbEnableDisable.Checked == true)
                {
                    lblStatus.BackColor = Color.Green;
                    lblStatus.Text = "Aktivan";
                    lblFSWStatus.Text = "FSW aktivan   |";
                    cbCreating.Enabled = true;
                    cbDeleting.Enabled = true;
                    cbRenaming.Enabled = true;
                    btnUploadDirectory.Enabled = true;

                    fSWFunctionalities.SetWatcher();
                }
                else if (cbEnableDisable.Checked == false)
                {
                    lblStatus.BackColor = Color.Red;
                    lblStatus.Text = "Stopiran";
                    lblFSWStatus.Text = "FSW neaktivan   |";
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
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message}");
            }
        }
        private void btnUploadDirectory_Click(object sender, EventArgs e)
        {
            try 
            {
                fSWFunctionalities.btnUploadFolder();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message}");
            }
        }
        private void cbCreating_CheckedChanged(object sender, EventArgs e)
        {
            try 
            {
                fSWFunctionalities.cbCreatingCheckChanged();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message}");
            }
        }
        private void cbDeleting_CheckedChanged(object sender, EventArgs e)
        {
            try 
            {
                fSWFunctionalities.cbDeletingCheckChanged();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message}");
            }
        }
        private void cbRenaming_CheckedChanged(object sender, EventArgs e)
        {
            try 
            {
                fSWFunctionalities.cbRenamingCheckChanged();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message}");
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("FSW folder ikona, malo stila ne moze da skodi ;)");
        }
        #endregion

        #region TCPFunctionalities
        private void btnChoseFile_Click(object sender, EventArgs e)
        {
            try 
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
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message}");
            }
        }
        private void btnSendFile_Click(object sender, EventArgs e)
        {
            try
            {
                Task task = Task.Run(() =>
                {
                    tCPFunctionalities.AdvanceKlijent(selectedFilePath);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message}");
            }
        }
        private void btnStartListening_Click(object sender, EventArgs e)
        {
            try 
            {
                Task task = Task.Run(() =>
                {
                    tCPFunctionalities.AdvanceServer();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message}");
            }
        }
        private void btnStopListening_Click(object sender, EventArgs e)
        {
            try
            {
                serverSocket?.Close();
                tCPFunctionalities.UpdateStatus(lblServerStatus, "Server je zaustavljen.");
                globalFunctionalities.FillTheLog(rtbAppLog, null, rtbServerSettings, null, "Server je zaustavljen", null, false, true);

            }
            catch (Exception ex)
            {
                tCPFunctionalities.UpdateStatus(lblServerStatus, $"Greska u prekidu slušanja: {ex.Message}");
                globalFunctionalities.FillTheLog(rtbAppLog, null, rtbServerSettings, null, $"Greska u prekidu slusanja: {ex.Message}", null, false, true);
            }
        }
        #endregion

        #region MainFunctionalities
        private void btnChoseTargetFolder_Click(object sender, EventArgs e)
        {
            try 
            {
                string folderPath = globalFunctionalities.ChoseFolder();
                fSWFunctionalities.SetTargetDirectory(folderPath);
                lblTargetFolder.Text += folderPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message}");
            }
        }
        private void btnChoseXFolder_Click(object sender, EventArgs e)
        {
            try 
            {
                string folderPath = globalFunctionalities.ChoseFolder();
                rc6ofb.SetXDirectory(folderPath);
                bifid.SetXDirectory(folderPath);
                lblOutputXFolder.Text += folderPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message}");
            }
        }
        #endregion
    }
}