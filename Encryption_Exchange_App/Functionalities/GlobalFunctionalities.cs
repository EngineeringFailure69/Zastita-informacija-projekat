namespace Encryption_Exchange_App.Functionalities
{
    public class GlobalFunctionalities
    {
        public void FillTheLog(RichTextBox rtbLog, string? time, string action, bool? rbChecked, bool? isFSW)
        {
            if (isFSW == true)
            {
                rtbLog.AppendText($"[{time}] " + action + "\r\n");
                rtbLog.ScrollToCaret();
            }
            else
            {
                DateTime currentTime = DateTime.Now;
                string formattedTime = currentTime.ToString("HH:mm:ss");
                action += (rbChecked == true) ? "RC6+OFB algorithm" : "Bifid cypher";
                rtbLog.AppendText($"[{formattedTime}] " + action + "\r\n");
                rtbLog.ScrollToCaret();
            }
        }
        public string ChoseFile() 
        {
            string returnFilePath = string.Empty;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "All files (*.*)|*.*";
                ofd.Title = "Select a file you want to send";
                ofd.CheckFileExists = true;
                ofd.FileName = "Select Folder";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string selectedFile = ofd.FileName;
                    returnFilePath = selectedFile;
                }
                else
                {
                    MessageBox.Show("Greska prilikom izbora fajla");
                }

            }
            return returnFilePath;
        }
        public string ChoseFolder() 
        {
            string? selectedFolder = string.Empty;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "All files (*.*)|*.*";
                ofd.Title = "Select a file from the directory";
                ofd.CheckFileExists = false;
                ofd.FileName = "Select Folder";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedFolder = Path.GetDirectoryName(ofd.FileName);
                }
            }
            return selectedFolder;
        }
    }
}