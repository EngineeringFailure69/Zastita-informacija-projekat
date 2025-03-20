namespace Encryption_Exchange_App
{
    public partial class Main : Form
    {
        private RC6OFB rc6ofb;
        private Bifid bifid;

        private static string folderFSWPath = @"C:\Users\Windows\Desktop\X\";
        private static string folderFSWPath1 = @"C:\Users\Windows\Desktop\Target";
        private string selectedFilePath = string.Empty;

        private FileSystemWatcher watcher;
        private Queue<String> filesToUpload;
        public Main()
        {
            InitializeComponent();
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;

            rc6ofb = new RC6OFB();
            bifid = new Bifid();

            watcher = new FileSystemWatcher();
            filesToUpload = new Queue<string>();

            lblStatus.Text = "";
            lblStatus.Enabled = false;
            label1.Enabled = false;
            cbCreating.Enabled = false;
            cbDataChange.Enabled = false;
            cbDeleting.Enabled = false;
            cbRenaming.Enabled = false;
            btnUploadDirectory.Enabled = false;

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
        public void HandleNewFile(string filePath, bool EncryptDecrypt, string? savePath)
        {
            if (rbRC6OFB.Checked == true)
            {
                EncryptDecryptRC6(filePath, EncryptDecrypt, savePath);
            }
            else if (rbBifid.Checked == true)
            {
                EncryptDecryptBifid(filePath, EncryptDecrypt, savePath);
            }
            else
            {
                MessageBox.Show("Greska prilikom enkripcije ili dekripcije");
            }

            //MessageBox.Show($"New file detected, path to it: {filePath}");
            //MessageBox.Show("EncryptDecrypt = " + EncryptDecrypt.ToString());
            //string decryptPath = string.Empty;
            //if (EncryptDecrypt == true && mainForm.IsFSWEnabled == false)
            //{
            //    decryptPath = RC6OFBEncryptFile(filePath);
            //    MessageBox.Show($"New file to decrypt: {decryptPath}");
            //}
            //else if (EncryptDecrypt == false && mainForm.IsFSWEnabled == false)
            //    if (string.IsNullOrEmpty(savePath))
            //        MessageBox.Show("Niste odabrali mesto gde ce se fajl sacuvati nakon dekripcije");
            //    else
            //        RC6OFBDecryptFile(filePath, savePath);
            //else if (mainForm.IsFSWEnabled == true && EncryptDecrypt == true) 
            //{
            //    decryptPath = RC6OFBEncryptFile(filePath);
            //    MessageBox.Show($"New file to decrypt: {decryptPath}");
            //}
            //else
            //{
            //    MessageBox.Show("Greska prilikom enkripcije ili dekripcije");
            //}
        }
        public void EncryptDecryptRC6(string filePath, bool EncryptDecrypt, string? savePath)
        {
            MessageBox.Show($"New file detected, path to it: {filePath}");
            MessageBox.Show("EncryptDecrypt = " + EncryptDecrypt.ToString());
            string decryptPath = string.Empty;
            if (EncryptDecrypt == true && cbEnableDisable.Checked == false)
            {
                Task task = Task.Run(() =>
                {
                    MessageBox.Show("Encryption started");
                    decryptPath = rc6ofb.RC6OFBEncryptFile(filePath);
                    MessageBox.Show($"New file to decrypt: {decryptPath}");
                });
                //decryptPath = RC6OFBEncryptFile(filePath);
                //MessageBox.Show($"New file to decrypt: {decryptPath}");
            }
            else if (EncryptDecrypt == false && cbEnableDisable.Checked == false)
                if (string.IsNullOrEmpty(savePath))
                    MessageBox.Show("Niste odabrali mesto gde ce se fajl sacuvati nakon dekripcije");
                else
                {
                    Task task = Task.Run(() =>
                    {
                        rc6ofb.RC6OFBDecryptFile(filePath, savePath);
                        MessageBox.Show("Decryption over");
                    });
                }
            // RC6OFBDecryptFile(filePath, savePath);
            else if (cbEnableDisable.Checked == true && EncryptDecrypt == true)
            {
                Task task = Task.Run(() =>
                {
                    MessageBox.Show("Encryption started");
                    decryptPath = rc6ofb.RC6OFBEncryptFile(filePath);
                    MessageBox.Show($"New file to decrypt: {decryptPath}");
                });
            }
            else
            {
                MessageBox.Show("Greska prilikom enkripcije ili dekripcije RC6");
            }
        }
        public void EncryptDecryptBifid(string filePath, bool EncryptDecrypt, string? savePath)
        {
            MessageBox.Show($"New file detected, path to it: {filePath}");
            MessageBox.Show("EncryptDecrypt = " + EncryptDecrypt.ToString());
            string decryptPath = string.Empty;
            if (EncryptDecrypt == true && cbEnableDisable.Checked == false)
            {
                Task task = Task.Run(() =>
                {
                    MessageBox.Show("Encryption started");
                    decryptPath = bifid.BifidEncryptFile(filePath);
                    MessageBox.Show($"New file to decrypt: {decryptPath}");
                });
                //decryptPath = BifidEncryptFile(filePath);
                //MessageBox.Show($"New file to decrypt: {decryptPath}");
            }
            else if (EncryptDecrypt == false && cbEnableDisable.Checked == false)
                if (string.IsNullOrEmpty(savePath))
                    MessageBox.Show("Niste odabrali mesto gde ce se fajl sacuvati nakon dekripcije");
                else
                {
                    Task task = Task.Run(() =>
                    {
                        MessageBox.Show("Decryption started");
                        bifid.BifidDecryptFile(filePath, savePath);
                        MessageBox.Show($"Decryption over, file {filePath} decrypted");
                    });
                    //MessageBox.Show("Decryption started");
                    //BifidDecryptFile(filePath, savePath);
                    //MessageBox.Show($"New file to decrypt: {decryptPath}");
                }
            //BifidDecryptFile(filePath, savePath);
            else if (cbEnableDisable.Checked == true && EncryptDecrypt == true)
            {
                Task task = Task.Run(() =>
                {
                    MessageBox.Show("Encryption started");
                    decryptPath = bifid.BifidEncryptFile(filePath);
                    MessageBox.Show($"Encryption over, new file to decrypt: {decryptPath}");
                });
                //decryptPath = BifidEncryptFile(filePath);
                //MessageBox.Show($"New file to decrypt: {decryptPath}");
            }
            else
            {
                MessageBox.Show("Greska prilikom enkripcije ili dekripcije Bifid");
            }
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
            string selectedFile = selectedFilePath;
            if (string.IsNullOrEmpty(selectedFile))
                MessageBox.Show("Niste odabrali fajl");
            else if (cbEnableDisable.Checked == false)
            {
                HandleNewFile(selectedFile, EncryptDecrypt, null);
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
                        if (string.IsNullOrEmpty(savePath))
                            MessageBox.Show("Niste odabrali mesto gde ce se fajl sacuvati nakon dekripcije");
                        else
                        {
                            HandleNewFile(selectedFile, EncryptDecrypt, savePath);
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
        public void Refresh()
        {
            //cbEnableDisable.Checked = mainForm.IsFSWEnabled;

            if (cbEnableDisable.Checked == true)
            {
                lblStatus.Text = "Running";
                cbCreating.Enabled = true;
                cbDataChange.Enabled = true;
                cbDeleting.Enabled = true;
                cbRenaming.Enabled = true;
                btnUploadDirectory.Enabled = true;

                FillQueue();
                ShowQueue();
                EmptyQueue();
            }
            else
            {
                lblStatus.Text = "Stopped";
                lvCurrentFiles.Items.Clear();
            }
        }
        public void CopyQueue()
        {
            Queue<string> updatedQueue = new Queue<string>();

            while (filesToUpload.Count > 0)
            {
                string queuedFile = filesToUpload.Dequeue();
                updatedQueue.Enqueue(queuedFile);
            }

            filesToUpload = updatedQueue;
            ShowQueue();
        }
        private void SetWatcher()
        {
            watcher.Path = folderFSWPath1;

            if (cbEnableDisable.Checked == true)
            {
                watcher.Created -= Watcher_Created;
                watcher.Renamed -= Watcher_ChangedFileName;
                watcher.Deleted -= Watcher_Deleted;

                if (cbCreating.Checked == true)
                    watcher.Created += Watcher_Created;
                if (cbRenaming.Checked == true)
                    watcher.Renamed += Watcher_ChangedFileName;
                if (cbDeleting.Checked == true)
                    watcher.Deleted += Watcher_Deleted;
            }

            watcher.EnableRaisingEvents = true;

            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;

            FillQueue();
            ShowQueue();
        }
        public void FillQueue()
        {
            string[] allFiles = Directory.GetFiles(folderFSWPath1);
            foreach (var f in allFiles)
                filesToUpload.Enqueue(f);
        }
        public void EmptyQueue()
        {
            //string[] allFiles = Directory.GetFiles(folderFSWPath);
            //foreach (var f in allFiles)
            while (filesToUpload.Count > 0)
                filesToUpload.Dequeue();
        }
        public void ShowQueue()
        {
            if (!this.IsHandleCreated)
            {
                return;
            }

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(ShowQueue));
            }
            else
            {
                if (lvCurrentFiles.Items.Count != 0)
                {
                    lvCurrentFiles.Invoke(new Action(() => lvCurrentFiles.Items.Clear()));
                }

                foreach (var fileName in filesToUpload)
                {
                    string[] name = fileName.Split('\\');
                    lvCurrentFiles.Invoke(new Action(() => lvCurrentFiles.Items.Add(name.Last())));
                }
            }
        }
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            bool EncryptedDecrypted = true;
            FileInfo fileInfo = new FileInfo(e.FullPath);
            while (!FileLoaded(fileInfo))
            {
                Thread.Sleep(1000);
            }
            filesToUpload.Enqueue(e.FullPath);
            ShowQueue();

            HandleNewFile(e.FullPath, EncryptedDecrypted, null);
        }
        private void Watcher_ChangedFileName(object sender, RenamedEventArgs e)
        {
            string oldfile = Path.GetFileName(e.OldFullPath);
            string newfile = Path.GetFileName(e.FullPath);

            Queue<string> updatedQueue = new Queue<string>();

            while (filesToUpload.Count > 0)
            {
                string queuedFile = filesToUpload.Dequeue();
                if (Path.GetFileName(queuedFile) == oldfile)
                {
                    updatedQueue.Enqueue(e.FullPath);
                }
                else
                {
                    updatedQueue.Enqueue(queuedFile);
                }
            }

            filesToUpload = updatedQueue;

            ShowQueue();
        }
        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            string file = Path.GetFileName(e.FullPath);

            Queue<string> updatedQueue = new Queue<string>();

            while (filesToUpload.Count > 0)
            {
                string queuedFile = filesToUpload.Dequeue();
                if (Path.GetFileName(queuedFile) != file)
                {
                    updatedQueue.Enqueue(queuedFile);
                }
            }

            filesToUpload = updatedQueue;

            ShowQueue();
        }
        private bool FileLoaded(FileInfo file)
        {
            FileStream stream = null;
            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return false;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return true;
        }
        private void cbEnableDisable_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEnableDisable.Checked == true)
            {
                lblStatus.Text = "Running";
                cbCreating.Enabled = true;
                cbDataChange.Enabled = true;
                cbDeleting.Enabled = true;
                cbRenaming.Enabled = true;
                btnUploadDirectory.Enabled = true;

                SetWatcher();
            }
            else if (cbEnableDisable.Checked == false)
            {
                lblStatus.Text = "Stopped";
                cbCreating.Enabled = false;
                cbDataChange.Enabled = false;
                cbDeleting.Enabled = false;
                cbRenaming.Enabled = false;
                cbCreating.Checked = false;
                cbDataChange.Checked = false;
                cbDeleting.Checked = false;
                cbRenaming.Checked = false;
                btnUploadDirectory.Enabled = false;
                lvCurrentFiles.Items.Clear();
                EmptyQueue();
            }
        }
        private void btnUploadDirectory_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "All files (*.*)|*.*";
                ofd.Title = "Select a file from the directory";
                ofd.CheckFileExists = false;
                ofd.FileName = "Select Folder";
                EmptyQueue();

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string? selectedFolder = Path.GetDirectoryName(ofd.FileName);
                    folderFSWPath1 = selectedFolder!;
                    label2.Text = folderFSWPath1;

                    if (cbEnableDisable.Checked)
                    {
                        lvCurrentFiles.Items.Clear();
                        SetWatcher();
                    }
                }
            }
        }
        private void cbCreating_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEnableDisable.Checked == true && cbCreating.Checked == true)
            {
                EmptyQueue();
                SetWatcher();
            }
            else if (cbEnableDisable.Checked == true && cbCreating.Checked == false)
            {
                watcher.Created -= Watcher_Created;
            }
        }
        private void cbDeleting_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEnableDisable.Checked == true && cbDeleting.Checked == true)
            {
                EmptyQueue();
                SetWatcher();
            }
            else if (cbEnableDisable.Checked == true && cbDeleting.Checked == false)
            {
                watcher.Deleted -= Watcher_Deleted;
            }
        }
        private void cbRenaming_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEnableDisable.Checked == true && cbRenaming.Checked == true)
            {
                EmptyQueue();
                SetWatcher();
            }
            else if (cbEnableDisable.Checked == true && cbRenaming.Checked == false)
            {
                watcher.Renamed -= Watcher_ChangedFileName;
            }
        }
        #endregion
    }
}
