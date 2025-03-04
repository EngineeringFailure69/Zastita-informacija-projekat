using System.Windows.Forms;

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

        private void SetWatcher()
        {
            watcher.Path = folderFSWPath;

            watcher.Created += Watcher_Changed;
            watcher.Renamed += Watcher_Changed;
            watcher.Deleted += Watcher_Changed; //Deleted files can't be uploaded, but this is here as an example

            watcher.EnableRaisingEvents = true;

            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;
            watcher.EnableRaisingEvents = true;

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
            string[] allFiles = Directory.GetFiles(folderFSWPath);
            foreach (var f in allFiles)
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
        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            FileInfo fileInfo = new FileInfo(e.FullPath);
            while (!FileLoaded(fileInfo))
            {
                Thread.Sleep(1000);
            }
            filesToUpload.Enqueue(e.FullPath);
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

        }
    }
}