namespace Encryption_Exchange_App
{
    public partial class UCFSW : UserControl
    {
        private MainForm mainForm;
        private static string folderFSWPath = @"C:\Users\Windows\Desktop\Target";
        private FileSystemWatcher watcher;
        private Queue<String> filesToUpload;
        // private ServiceReference1.Service1Client proxy;
        public UCFSW(MainForm mainForm)
        {
            InitializeComponent();

            this.mainForm = mainForm;
            watcher = new FileSystemWatcher();
            filesToUpload = new Queue<string>();
            //proxy = new ServiceReference1.Service1Client();
            cbEnableDisable.Checked = mainForm.IsFSWEnabled;
            cbCreating.Checked = mainForm.IsCreatingChecked;
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

            //this.VisibleChanged += UCFSW_VisibleChanged_1;
            Refresh();
        }

        public void Refresh()
        {
            cbEnableDisable.Checked = mainForm.IsFSWEnabled;

            if (mainForm.IsFSWEnabled)
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
            watcher.Path = folderFSWPath;

            if (mainForm.IsFSWEnabled == true && cbEnableDisable.Checked == true)
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
            string[] allFiles = Directory.GetFiles(folderFSWPath);
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
                return; // Izlazi iz funkcije ako kontrola još nije kreirana
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
            FileInfo fileInfo = new FileInfo(e.FullPath);
            while (!FileLoaded(fileInfo))
            {
                Thread.Sleep(1000);
            }
            filesToUpload.Enqueue(e.FullPath);
            ShowQueue();

            mainForm.ReceiveNewFile(e.FullPath);
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
            mainForm.IsFSWEnabled = cbEnableDisable.Checked;
            if (mainForm.IsFSWEnabled == true && cbEnableDisable.Checked == true)
            {
                lblStatus.Text = "Running";
                cbCreating.Enabled = true;
                cbDataChange.Enabled = true;
                cbDeleting.Enabled = true;
                cbRenaming.Enabled = true;
                btnUploadDirectory.Enabled = true;

                SetWatcher();
            }
            else if (mainForm.IsFSWEnabled == false && cbEnableDisable.Checked == false)
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
                    folderFSWPath = selectedFolder!;
                    label2.Text = folderFSWPath;

                    if (mainForm.IsFSWEnabled && cbEnableDisable.Checked)
                    {
                        lvCurrentFiles.Items.Clear();
                        SetWatcher();
                    }
                }
            }
        }
        private void UCFSW_VisibleChanged(object sender, EventArgs e)
        {
        }
        private void UCFSW_VisibleChanged_1(object sender, EventArgs e)
        {
        }
        private void cbCreating_CheckedChanged(object sender, EventArgs e)
        {
            mainForm.IsCreatingChecked = cbCreating.Checked;
            if (mainForm.IsFSWEnabled == true && cbEnableDisable.Checked == true && cbCreating.Checked == true)
            {
                EmptyQueue();
                SetWatcher();
            }
            else if (mainForm.IsFSWEnabled == true && cbEnableDisable.Checked == true && cbCreating.Checked == false)
            {
                watcher.Created -= Watcher_Created;
            }
        }
        private void cbDeleting_CheckedChanged(object sender, EventArgs e)
        {
            if (mainForm.IsFSWEnabled == true && cbEnableDisable.Checked == true && cbDeleting.Checked == true)
            {
                EmptyQueue();
                SetWatcher();
            }
            else if (mainForm.IsFSWEnabled == true && cbEnableDisable.Checked == true && cbDeleting.Checked == false)
            {
                watcher.Deleted -= Watcher_Deleted;
            }
        }
        private void cbRenaming_CheckedChanged(object sender, EventArgs e)
        {
            if (mainForm.IsFSWEnabled == true && cbEnableDisable.Checked == true && cbRenaming.Checked == true)
            {
                EmptyQueue();
                SetWatcher();
            }
            else if (mainForm.IsFSWEnabled == true && cbEnableDisable.Checked == true && cbRenaming.Checked == false)
            {
                watcher.Renamed -= Watcher_ChangedFileName;
            }
        }
    }
}