namespace Encryption_Exchange_App
{
    public partial class Main : Form
    {
        //private RC6OFB rc6ofb;
        //private Bifid bifid;
        private MainFunctionalities mainFunctionalities;
        private FSWFunctionalities fSWFunctionalities;
        //private SHA_1 sha1;
        private TCPFunctionalities tCPFunctionalities;

        //private static string folderFSWPath = @"C:\Users\Windows\Desktop\X\";
        //private static string folderFSWPath1 = @"C:\Users\Windows\Desktop\Target";
        private string selectedFilePath = string.Empty;

        private FileSystemWatcher watcher;
        private Queue<String> filesToUpload;

        private Socket serverSocket;
        //private static string folderFSWPath1 = @"C:\Users\Windows\Desktop\X\";

        public Main()
        {
            InitializeComponent();
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;

            watcher = new FileSystemWatcher();
            filesToUpload = new Queue<string>();
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //rc6ofb = new RC6OFB();
            //bifid = new Bifid();
            mainFunctionalities = new MainFunctionalities();
            //sha1 = new SHA_1(); 

            fSWFunctionalities = new FSWFunctionalities(this, cbEnableDisable, cbCreating, cbDeleting,
                cbRenaming, this, lvCurrentFiles, rbBifid, watcher, filesToUpload, rcbLog, lblNumber);

            tCPFunctionalities = new TCPFunctionalities(this, rbBifid, tbIPAddress, tbPort, lblClientStatus,
                 lblServerStatus, this, serverSocket);

            lblStatus.Text = "";
            lblStatus.Enabled = false;
            label1.Enabled = false;
            cbCreating.Enabled = false;
            //cbDataChange.Enabled = false;
            cbDeleting.Enabled = false;
            cbRenaming.Enabled = false;
            btnUploadDirectory.Enabled = false;
            //lblActive.Text = "";
            lblNumber.Text = "";

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

        #region MainFunctionalities
        public void ClearLabels()
        {
            lblFileAttributes.Text = "Attributes: ";
            lblFileDateCreated.Text = "Date created: ";
            lblFileDateModified.Text = "Date modified: ";
            lblFileExtension.Text = "Extension: ";
            lblFileName.Text = "File name: ";
            lblFilePath.Text = "Path: ";
            lblFileSize.Text = "File size: ";
        }
        private void btnSelectFileToEncryptDecrypt_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "All files (*.*)|*.*";
                ofd.Title = "Select a file from the directory";
                ofd.CheckFileExists = true;
                ofd.FileName = "Select Folder";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string selectedFile = ofd.FileName;
                    if (cbEnableDisable.Checked == false)
                    {
                        lblFilePath.Text = "Path: " + selectedFile;
                        FileInfo fi = new FileInfo(selectedFile);
                        long fileSize = fi.Length; // velicina fajla u bajtovima
                        lblFileSize.Text = lblFileSize.Text + (fileSize / 1000).ToString() + "KB";
                        string fileName = fi.Name; // ime fajla
                        lblFileName.Text = lblFileName.Text + fileName;
                        string fileExtension = fi.Extension; // ekstenzija fajla
                        lblFileExtension.Text = lblFileExtension.Text + fileExtension;
                        string fileDateCreated = fi.CreationTime.ToString(); // datum i vreme kreiranja 
                        lblFileDateCreated.Text = lblFileDateCreated.Text + fileDateCreated;
                        string fileDateModified = fi.LastWriteTime.ToString(); // datum i vreme poslednje promene 
                        lblFileDateModified.Text += fileDateModified;
                        string fileAttributes = fi.Attributes.ToString(); // atributi
                        lblFileAttributes.Text += fileAttributes;
                        selectedFilePath = selectedFile;
                        MessageBox.Show($"Putanja: {selectedFilePath}");
                    }
                    else
                    {
                        MessageBox.Show("FSW mora biti iskljucen");
                    }
                }
            }
        }
        private void btnEncryptSelectedFile_Click(object sender, EventArgs e)
        {
            bool EncryptDecrypt = true;
            bool FSWActive = cbEnableDisable.Checked;
            bool rbChecked;
            if (rbBifid.Checked == true)
                rbChecked = false;
            else
                rbChecked = true;
            string selectedFile = selectedFilePath;
            if (string.IsNullOrEmpty(selectedFile))
                MessageBox.Show("Niste odabrali fajl");
            else if (cbEnableDisable.Checked == false)
            {
                mainFunctionalities.HandleNewFile(selectedFile, EncryptDecrypt, null, rbChecked, FSWActive);
                ClearLabels();
            }
            else
            {
                MessageBox.Show("FSW mora biti iskljucen");
            }
        }
        private void btnDecryptSelectedFile_Click(object sender, EventArgs e)
        {
            bool EncryptDecrypt = false;
            bool FSWActive = cbEnableDisable.Checked;
            bool rbChecked;
            if (rbBifid.Checked == true)
                rbChecked = false;
            else
                rbChecked = true;
            string selectedFile = selectedFilePath;
            if (string.IsNullOrEmpty(selectedFile))
            {
                MessageBox.Show("Niste odabrali fajl");
                return;
            }
            string extension = Path.GetExtension(selectedFile);
            if (extension != ".enc")
            {
                MessageBox.Show("Fajl koji je odabran nije kriptovan jer nema .enc ekstenziju");
                return;
            }
            if (cbEnableDisable.Checked == false)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Title = "Sačuvaj dekriptovani fajl kao";
                    sfd.Filter = "All files (*.*)|*.*";
                    sfd.FileName = Path.GetFileNameWithoutExtension(selectedFile);

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        string savePath = sfd.FileName;
                        MessageBox.Show($"Save putanja: {savePath}");
                        if (string.IsNullOrEmpty(savePath))
                            MessageBox.Show("Niste odabrali mesto gde ce se fajl sacuvati nakon dekripcije");
                        else
                        {
                            mainFunctionalities.HandleNewFile(selectedFile, EncryptDecrypt, savePath, rbChecked, FSWActive);
                            ClearLabels();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("FSW mora biti isključen");
            }
        }
        #endregion

        #region FSWFunctionalities
        private void cbEnableDisable_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEnableDisable.Checked == true)
            {
                lblStatus.BackColor = Color.Green;
                lblStatus.Text = "Running";
                cbCreating.Enabled = true;
                //cbDataChange.Enabled = true;
                cbDeleting.Enabled = true;
                cbRenaming.Enabled = true;
                btnUploadDirectory.Enabled = true;
                //lblActive.Text = "Active tracking";

                fSWFunctionalities.SetWatcher();
            }
            else if (cbEnableDisable.Checked == false)
            {
                lblStatus.BackColor = Color.Red;
                lblStatus.Text = "Stopped";
                cbCreating.Enabled = false;
                //cbDataChange.Enabled = false;
                cbDeleting.Enabled = false;
                cbRenaming.Enabled = false;
                cbCreating.Checked = false;
                //cbDataChange.Checked = false;
                cbDeleting.Checked = false;
                cbRenaming.Checked = false;
                btnUploadDirectory.Enabled = false;
                //lblActive.Text = "";
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
        #endregion

        #region TCPFunctionalities
        private void btnChoseFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "All files (*.*)|*.*";
                ofd.Title = "Select a file you want to send";
                ofd.CheckFileExists = true;
                ofd.FileName = "Select Folder";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    this.lblChosenFile.Text = ofd.FileName;
                    string selectedFile = ofd.FileName;
                    selectedFilePath = selectedFile;

                    tCPFunctionalities.UpdateStatus(lblClientStatus, $"Odabran je fajl {lblChosenFile.Text}");
                }
                else
                {
                    MessageBox.Show("FSW mora biti iskljucen");
                }

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}