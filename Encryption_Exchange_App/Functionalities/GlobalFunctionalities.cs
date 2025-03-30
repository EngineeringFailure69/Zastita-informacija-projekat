using Encryption_Exchange_App.EncryptionDecryption_Algorithms;

namespace Encryption_Exchange_App.Functionalities
{
    public class GlobalFunctionalities
    {
        public void FillTheLog(RichTextBox rtbAppLog, RichTextBox rtbLog, string? time, string action, string? appLogAction, bool? isFSW)
        {
            if (isFSW == true)
            {
                rtbAppLog.AppendText($"[{time}] " + appLogAction + "\r\n");
                rtbAppLog.ScrollToCaret();
                rtbLog.AppendText($"[{time}] " + action + "\r\n");
                rtbLog.ScrollToCaret();
            }
            else
            {
                DateTime currentTime = DateTime.Now;
                string formattedTime = currentTime.ToString("HH:mm:ss");
                string formattedAction = string.Empty;
                //action += (rbChecked == true) ? "RC6+OFB algorithm" : "Bifid cypher";
                if (string.IsNullOrEmpty(appLogAction))
                    formattedAction = action;
                else
                    formattedAction = appLogAction;
                rtbAppLog.AppendText($"[{formattedTime}] " + formattedAction + "\r\n");
                rtbAppLog.ScrollToCaret();
                rtbLog.AppendText($"[{formattedTime}] " + formattedAction + "\r\n");
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
        public void SetLabelText(Label labelToSet, string text) 
        {
            DateTime currentTime = DateTime.Now;
            string formattedTime = currentTime.ToString("HH:mm:ss");
            labelToSet.Text = $"Last activity: [{formattedTime}] " + text;
        }
        public bool CheckExtension(string inputFile, RadioButton rbBifid)
        {
            string extension = Path.GetExtension(inputFile);
            if ((extension == ".txt" || extension == ".html") && rbBifid.Checked == true) //ako je fajl txt
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}