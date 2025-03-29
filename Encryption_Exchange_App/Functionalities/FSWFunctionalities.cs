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
        private Label lblNumber;
        private Label lblNumberOfEncryptedFiles;
        private FileSystemWatcher watcher;
        private Queue<String> filesToUpload;
        private int counter = 0;
        private int encryptionCouter = 0;
        public FSWFunctionalities(Main forma, CheckBox cbEnableDisable, CheckBox cbCreating,
            CheckBox cbDeleting, CheckBox cbRenaming, Control uiControl, ListView lvCurrentFiles,
            RadioButton rbBifid, FileSystemWatcher watcher, Queue<string> filesToUpload, 
            RichTextBox rcbLog, Label lblNumber, Label lblNumberOfEncryptedFiles)
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
        }

        private EncryptionFunctionalities encryptionFunctionalities = new EncryptionFunctionalities(null, null);
        private GlobalFunctionalities globalFunctionalities = new GlobalFunctionalities();

        private static string folderFSWPath1 = @"C:\Users\Windows\Desktop\Target";

        public void btnUploadFolder()
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
        public void cbCreatingCheckChanged() 
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
        public void cbDeletingCheckChanged() 
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
        public void cbRenamingCheckChanged() 
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
        public void SetWatcher()
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
            while (filesToUpload.Count > 0)
                filesToUpload.Dequeue();
        }
        public void ShowQueue()
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
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            bool EncryptedDecrypted = true;
            bool FSWActive = this.cbEnableDisable.Checked;
            bool rbChecked;
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
            globalFunctionalities.FillTheLog(rcbLog, fileInfo.CreationTime.ToString(), $"Created file: {fileInfo.Name}", null,  true);
        }
        private void Watcher_ChangedFileName(object sender, RenamedEventArgs e)
        {
            string oldfile = Path.GetFileName(e.OldFullPath);
            string newfile = Path.GetFileName(e.FullPath);
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
            globalFunctionalities.FillTheLog(rcbLog, formattedTime, $"Changed file name: from {oldfile} to {newfile}", null, true);
        }
        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            string file = Path.GetFileName(e.FullPath);
            FileInfo fileInfo = new FileInfo(e.FullPath);
            Queue<string> updatedQueue = new Queue<string>();
            DateTime currentTime = DateTime.Now;
            string formattedTime = currentTime.ToString("HH:mm:ss");

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
            globalFunctionalities.FillTheLog(rcbLog, formattedTime, $"Deleted file: {fileInfo.Name}",null, true);
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
        public void UpdateLabel(string inputFile) 
        {
            string extension = Path.GetExtension(inputFile);
            if ((extension == ".txt" || extension == ".html") && rbBifid.Checked == true) //ako je fajl txt
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
                MessageBox.Show("FSW test labela update");
            }
        }
    }
}