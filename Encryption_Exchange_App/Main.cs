namespace Encryption_Exchange_App
{
    public partial class Main : Form
    {
        private RC6OFB rc6ofb;
        private Bifid bifid;
        private MainFunctionalities mainFunctionalities;
        private FSWFunctionalities fSWFunctionalities;
        private SHA_1 sha1;

        private static string folderFSWPath = @"C:\Users\Windows\Desktop\X\";
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

            rc6ofb = new RC6OFB();
            bifid = new Bifid();
            mainFunctionalities = new MainFunctionalities();
            sha1 = new SHA_1(); 

            fSWFunctionalities = new FSWFunctionalities(this, cbEnableDisable, cbCreating, cbDeleting,
                cbRenaming, this, lvCurrentFiles, rbBifid, watcher, filesToUpload);

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
                lblStatus.Text = "Running";
                cbCreating.Enabled = true;
                cbDataChange.Enabled = true;
                cbDeleting.Enabled = true;
                cbRenaming.Enabled = true;
                btnUploadDirectory.Enabled = true;

                fSWFunctionalities.SetWatcher();
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
        public async Task AdvanceKlijent()
        {
            try
            {
                string fileToEncrypt = selectedFilePath; //dodato
                string fileToSend = string.Empty;
                if (rbBifid.Checked==true)
                    fileToSend = bifid.BifidEncryptFile(fileToEncrypt); //dodato
                else
                    fileToSend = rc6ofb.RC6OFBEncryptFile(fileToEncrypt); //dodato

                using (Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    await clientSocket.ConnectAsync(this.tbIPAddress.Text, Int32.Parse(this.tbPort.Text));
                    UpdateStatus(lblClientStatus, "Povezan sa serverom");

                    using (NetworkStream networkStream = new NetworkStream(clientSocket))
                    using (BinaryReader reader = new BinaryReader(networkStream))
                    using (BinaryWriter writer = new BinaryWriter(networkStream))
                    {
                        //string filePath = this.lblChosenFile.Text;  //vrati
                        string filePath = fileToSend; //dodato
                        string fileName = Path.GetFileName(filePath);
                        long fileSize = new FileInfo(filePath).Length;
                        byte[] hash = sha1.GenerateHash(File.ReadAllBytes(filePath));
                        int hashLength = hash.Length;

                        //Slanje metapodataka
                        writer.Write(fileName);
                        writer.Write(fileSize);
                        writer.Write(hashLength);
                        writer.Write(hash);

                        //Slanje fajla u blokovima
                        using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                        {
                            byte[] buffer = new byte[4096];
                            int bytesRead;

                            while ((bytesRead = await fileStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await networkStream.WriteAsync(buffer, 0, bytesRead);
                            }
                        }

                        //Odgovor servera
                        string response = reader.ReadString();
                        File.Delete(filePath);
                        UpdateStatus(lblClientStatus, $"Server response: {response}");
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateStatus(lblClientStatus, $"Error: {ex.Message}");
            }
        }
        public async Task AdvanceServer()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                serverSocket.Bind(new IPEndPoint(IPAddress.Any, Int32.Parse(this.tbPort.Text)));
                serverSocket.Listen(5);
                UpdateStatus(lblServerStatus, "Server je spreman i osluškuje konekcije");

                while (true)
                {
                    Socket clientSocket = await serverSocket.AcceptAsync();
                    Task.Run(() => HandleClientAsyncAdvance(clientSocket));
                }
            }
            catch (Exception ex)
            {
                UpdateStatus(lblServerStatus, $"Error: {ex.Message}");
            }
            finally
            {
                serverSocket.Close();
            }
        }
        private async Task HandleClientAsyncAdvance(Socket clientSocket)
        {
            try
            {
                using (NetworkStream networkStream = new NetworkStream(clientSocket))
                using (BinaryReader reader = new BinaryReader(networkStream))
                using (BinaryWriter writer = new BinaryWriter(networkStream))
                {
                    string fileName = reader.ReadString();
                    long fileSize = reader.ReadInt64();
                    int hashLength = reader.ReadInt32();
                    byte[] expectedHash = reader.ReadBytes(hashLength);

                    UpdateStatus(lblServerStatus, $"Preuzimanje i provera fajla: {fileName} ({fileSize} bytes)");

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        byte[] buffer = new byte[4096];
                        long totalBytesReceived = 0;

                        while (totalBytesReceived < fileSize)
                        {
                            int bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length);
                            if (bytesRead == 0) break;

                            await memoryStream.WriteAsync(buffer, 0, bytesRead);
                            totalBytesReceived += bytesRead;
                        }

                        if (totalBytesReceived != fileSize)
                        {
                            UpdateStatus(lblServerStatus, "Greska: velicina primljenog fajla ne odgovara ocekivanoj");
                            writer.Write("Fajl nije uspesno preuzet: neodgovarajuća velicina");
                            return;
                        }

                        byte[] receivedData = memoryStream.ToArray();
                        byte[] generatedHash = sha1.GenerateHash(receivedData);

                        if (!generatedHash.SequenceEqual(expectedHash))
                        {
                            UpdateStatus(lblServerStatus, "Greska: hash vrednosti se ne poklapaju");
                            writer.Write("Fajl nije uspesno preuzet: hash vrednosti se ne poklapaju");
                            return;
                        }

                        string savePath = Path.Combine(Directory.GetCurrentDirectory(), "Received_" + fileName);
                        File.WriteAllBytes(savePath, receivedData);

                        UpdateStatus(lblServerStatus, $"Fajl {fileName} uspešno preuzet i verifikovan");
                        writer.Write("Fajl je uspešno preuzet i verifikovan");
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateStatus(lblServerStatus, $"Error handling client: {ex.Message}");
            }
            finally
            {
                clientSocket.Close();
            }
        }
        private void UpdateStatus(Label statusLabel, string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => statusLabel.Text = message));
            }
            else
            {
                statusLabel.Text = message;
            }
        }
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

                    UpdateStatus(lblClientStatus, $"Odabran je fajl {lblChosenFile.Text}");

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
                AdvanceKlijent();
            });
        }
        private void btnStartListening_Click(object sender, EventArgs e)
        {
            Task task = Task.Run(() =>
            {
                AdvanceServer();
            });
        }
        private void btnStopListening_Click(object sender, EventArgs e)
        {
            try
            {
                serverSocket?.Close();
                UpdateStatus(lblServerStatus, "Server je zaustavljen.");
            }
            catch (Exception ex)
            {
                UpdateStatus(lblServerStatus, $"Greška u prekidu slušanja: {ex.Message}");
            }
        }
        #endregion
    }
}