namespace Encryption_Exchange_App.Functionalities
{
    public class FSWFunctionalities
    {
        Main forma;
        private CheckBox cbEnableDisable;
        private Control uiControl;
        private ListView lvCurrentFiles;
        private RadioButton rbBifid;
        private CheckBox cbDeleting;
        private CheckBox cbCreating;
        private CheckBox cbRenaming;
        private RichTextBox rcbLog;
        private RichTextBox rtbAppLog;
        private Label lblNumber;
        private Label lblNumberOfEncryptedFiles;
        private Label lblLastActivity;
        private FileSystemWatcher watcher;
        private Queue<String> filesToUpload;
        private int counter = 0;
        private int encryptionCouter = 0;
        public FSWFunctionalities(Main forma, CheckBox cbEnableDisable, CheckBox cbCreating,
            CheckBox cbDeleting, CheckBox cbRenaming, Control uiControl, ListView lvCurrentFiles,
            RadioButton rbBifid, FileSystemWatcher watcher, Queue<string> filesToUpload, 
            RichTextBox rcbLog, Label lblNumber, Label lblNumberOfEncryptedFiles, Label lblLastActivity, 
            RichTextBox rtbAppLog)
        {
            this.forma = forma;
            this.cbEnableDisable = cbEnableDisable;
            this.uiControl = uiControl;
            this.lvCurrentFiles = lvCurrentFiles;
            this.rbBifid = rbBifid;
            this.cbCreating = cbCreating;
            this.cbDeleting = cbDeleting;
            this.cbRenaming = cbRenaming;
            this.watcher = watcher;
            this.filesToUpload = filesToUpload;
            this.rcbLog = rcbLog;
            this.lblNumber = lblNumber;
            this.lblNumberOfEncryptedFiles = lblNumberOfEncryptedFiles;
            this.lblLastActivity = lblLastActivity;
            this.rtbAppLog = rtbAppLog;
        }

        private EncryptionFunctionalities encryptionFunctionalities = new EncryptionFunctionalities(null, null, null, null);
        private GlobalFunctionalities globalFunctionalities = new GlobalFunctionalities();

        private static string folderFSWPath1 = @"C:\Users\Windows\Desktop\Target";

        public void SetTargetDirectory(string targetDirectory) 
        {
            folderFSWPath1 = targetDirectory;
        }
        public void btnUploadFolder()
        {
            try
            {
                EmptyQueue();
                string? selectedFolder = globalFunctionalities.ChoseFolder();
                folderFSWPath1 = selectedFolder!;
                if (cbEnableDisable.Checked)
                {
                    lvCurrentFiles.Items.Clear();
                    SetWatcher();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Greska: {ex.Message} - btnUploadFolder funkcija");
            }
        }
        public void cbCreatingCheckChanged() 
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message} - cbCreatingCheckChanged funkcija");
            }
        }
        public void cbDeletingCheckChanged() 
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message} - cbDeletingCheckChanged funkcija");
            }
        }
        public void cbRenamingCheckChanged() 
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message} - cbRenamingCheckChanged funkcija");
            }
        }
        public void CopyQueue()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message} - CopyQueue funkcija");
            }
        }
        public void SetWatcher()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message} - SetWatcher funkcija");
            }
        }
        public void FillQueue()
        {
            try
            {
                string[] allFiles = Directory.GetFiles(folderFSWPath1);
                foreach (var f in allFiles)
                    filesToUpload.Enqueue(f);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message} - FillQueue funkcija");
            }
        }
        public void EmptyQueue()
        {
            try
            {
                while (filesToUpload.Count > 0)
                    filesToUpload.Dequeue();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message} - EmptyQueue funkcija");
            }
        }
        public void ShowQueue()
        {
            try
            {
                if (!uiControl.IsHandleCreated)
                {
                    return;
                }

                if (uiControl.InvokeRequired)
                {
                    uiControl.Invoke(new Action(() => ShowQueue()));
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
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message} - ShowQueue funkcija");
            }
        }
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                bool EncryptedDecrypted = true;
                bool FSWActive = this.cbEnableDisable.Checked;
                bool rbChecked;
                bool extension;
                string labelText = string.Empty;
                string appLogText = string.Empty;
                if (this.rbBifid.Checked == true)
                    rbChecked = false;
                else
                    rbChecked = true;
                FileInfo fileInfo = new FileInfo(e.FullPath);
                while (!FileLoaded(fileInfo))
                {
                    Thread.Sleep(1000);
                }
                filesToUpload.Enqueue(e.FullPath);
                ShowQueue();

                counter += 1;
                lblNumber.Text = counter.ToString();
                encryptionFunctionalities.HandleNewFile(e.FullPath, EncryptedDecrypted, null, rbChecked, FSWActive);
                UpdateLabel(e.FullPath);
                extension = globalFunctionalities.CheckExtension(e.FullPath, rbBifid);
                if (rbBifid.Checked == true && extension == true)
                    labelText = $"Fajl {e.FullPath} kreiran i kriptovan koriscenjem Bifid cypher-a";
                else if (rbBifid.Checked == true && extension == false)
                    labelText = $"Fajl {e.FullPath} kreiran, ali ne moze biti sifrovan koriscenjem Bifid cypher-a zato sto nije txt fajl";
                else
                    labelText = $"Fajl {e.FullPath} kreiran i kriptovan koriscenjem RC6 + OFB algoritma";
                globalFunctionalities.FillTheLog(rtbAppLog, rcbLog, null, fileInfo.CreationTime.ToString(), $"Kreiran fajl: {fileInfo.Name}", labelText, true, false);
                globalFunctionalities.SetLabelText(lblLastActivity, labelText);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message} - Watcher_Created handler");
            }
        }
        private void Watcher_ChangedFileName(object sender, RenamedEventArgs e)
        {
            try
            {
                string oldfile = Path.GetFileName(e.OldFullPath);
                string newfile = Path.GetFileName(e.FullPath);
                string labelText = string.Empty;
                DateTime currentTime = DateTime.Now;
                string formattedTime = currentTime.ToString("HH:mm:ss");
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
                counter += 1;
                lblNumber.Text = counter.ToString();
                labelText = $"Fajlu {oldfile} promenjeno ime u {newfile}";
                globalFunctionalities.FillTheLog(rtbAppLog, rcbLog, null, formattedTime, $"Promenjeno ime fajla: iz {oldfile} u {newfile}", labelText, true, false);
                globalFunctionalities.SetLabelText(lblLastActivity, labelText);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message} - Watcher_ChangedFileName handler");
            }
        }
        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            try
            {
                string file = Path.GetFileName(e.FullPath);
                FileInfo fileInfo = new FileInfo(e.FullPath);
                Queue<string> updatedQueue = new Queue<string>();
                DateTime currentTime = DateTime.Now;
                string formattedTime = currentTime.ToString("HH:mm:ss");
                string labelText = string.Empty;

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
                counter += 1;
                lblNumber.Text = counter.ToString();
                labelText = $"Fajl {e.FullPath} uklonjen iz podrazumevanog Target foldera, ili foldera koji ste sami odabrali";
                globalFunctionalities.FillTheLog(rtbAppLog, rcbLog, null, formattedTime, $"Uklonjen fajl: {fileInfo.Name}", labelText, true, false);
                globalFunctionalities.SetLabelText(lblLastActivity, labelText);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message} - Watcher_Deleted handler");
            }
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
                MessageBox.Show($"Greska: FileLoaded funkcija");
                return false;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return true;
        }
        public void UpdateLabel(string inputFile) 
        {
            string extension = Path.GetExtension(inputFile);
            if ((extension == ".txt") && rbBifid.Checked == true) //ako je fajl txt
            {
                encryptionCouter += 1;
                lblNumberOfEncryptedFiles.Text = encryptionCouter.ToString();
            }
            else if (rbBifid.Checked == false) 
            {
                encryptionCouter += 1;
                lblNumberOfEncryptedFiles.Text = encryptionCouter.ToString();
            }
            else //ako nije txt
            {
            }
        }
    }
}