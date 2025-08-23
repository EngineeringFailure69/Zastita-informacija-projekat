namespace Encryption_Exchange_App.Functionalities
{
    public class GlobalFunctionalities
    {
        public void FillTheLog(RichTextBox? rtbAppLog, RichTextBox? rtbLog, RichTextBox? rtbTCPSettings, string? time, string action, string? appLogAction, bool? isFSW,  bool? isTCP)
        {
            string formattedTime = ReturnTime();
            if (isFSW == true && isTCP == false)
            {
                rtbAppLog!.AppendText($"[{time}] " + appLogAction + "\r\n");
                rtbAppLog.ScrollToCaret();
                rtbLog!.AppendText($"[{time}] " + action + "\r\n");
                rtbLog.ScrollToCaret();
            }
            else if (isFSW == false && isTCP == true)
            {
                rtbTCPSettings!.AppendText($"[{formattedTime}] " + action + "\r\n");
                rtbTCPSettings.ScrollToCaret();
                rtbAppLog!.AppendText($"[{formattedTime}] " + action + "\r\n");
                rtbAppLog.ScrollToCaret();
            }
            else
            {
                string formattedAction = string.Empty;
                if (string.IsNullOrEmpty(appLogAction))
                    formattedAction = action;
                else
                    formattedAction = appLogAction;
                rtbAppLog!.AppendText($"[{formattedTime}] " + formattedAction + "\r\n");
                rtbAppLog.ScrollToCaret();
                rtbLog!.AppendText($"[{formattedTime}] " + formattedAction + "\r\n");
                rtbLog.ScrollToCaret();
            }
        }
        public string ChoseFile() 
        {
            try
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
            catch (Exception ex) 
            {
                MessageBox.Show($"Greska: {ex.Message} - ChoseFile funkcija");
                return "Greksa kod izbora fajla";
            }
        }
        public string ChoseFolder() 
        {
            try
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
                    else
                    {
                        MessageBox.Show("Greska prilikom izbora foldera");
                    }
                }
                return selectedFolder;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message} - ChoseFolder funkcija");
                return "Greksa kod izbora foldera";
            }
        }
        public void SetLabelText(Label labelToSet, string text) 
        {
            DateTime currentTime = DateTime.Now;
            string formattedTime = currentTime.ToString("HH:mm:ss");
            labelToSet.Text = $"Poslednja aktivnost: [{formattedTime}] " + text;
        }
        public bool CheckExtension(string inputFile, RadioButton rbBifid)
        {
            string extension = Path.GetExtension(inputFile);
            if ((extension == ".txt") && rbBifid.Checked == true) //ako je fajl txt
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string ReturnTime()
        {
            DateTime currentTime = DateTime.Now;
            string formattedTime = currentTime.ToString("HH:mm:ss");
            return formattedTime;
        }
        public string SaveFile(string selectedFile)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    string savePath = string.Empty;
                    sfd.Title = "Sacuvaj dekriptovani fajl kao";
                    sfd.Filter = "All files (*.*)|*.*";
                    sfd.FileName = Path.GetFileNameWithoutExtension(selectedFile);

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        savePath = sfd.FileName;
                        MessageBox.Show($"Save putanja: {savePath}");
                        
                    }
                    return savePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message} - SaveFile funkcija");
                return null;
            }
        }
    }
}