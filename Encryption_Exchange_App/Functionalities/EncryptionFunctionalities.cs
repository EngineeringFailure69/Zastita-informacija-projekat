namespace Encryption_Exchange_App.Functionalities
{
    public class EncryptionFunctionalities
    {
        private Label lblNumberOfEncryptedFiles;
        private Label lblNumberOfDecryptedFiles;

        public EncryptionFunctionalities(Label? lblNumberOfEncryptedFiles, Label? lblNumberOfDecryptedFiles) 
        {
            this.lblNumberOfEncryptedFiles = lblNumberOfEncryptedFiles!;
            this.lblNumberOfDecryptedFiles = lblNumberOfDecryptedFiles!;
        }

        private RC6OFB rc6ofb = new RC6OFB();
        private Bifid bifid = new Bifid();
        private GlobalFunctionalities globalFunctionalities = new GlobalFunctionalities();

        private string selectedFilePath = string.Empty;
        private int encryptionCounter = 0;
        private int decryptionCounter = 0;

        public void HandleNewFile(string filePath, bool EncryptDecrypt, string? savePath, bool? rbChecked, bool? FSWActive)
        {
            if (rbChecked == true)
            {
                EncryptDecryptRC6(filePath, EncryptDecrypt, savePath, FSWActive);
            }
            else if (rbChecked == false)
            {
                EncryptDecryptBifid(filePath, EncryptDecrypt, savePath, FSWActive);
            }
            else
            {
                MessageBox.Show("Greska prilikom enkripcije ili dekripcije");
            }
        }
        public void EncryptDecryptRC6(string filePath, bool EncryptDecrypt, string? savePath, bool? FSWActive)
        {
            MessageBox.Show($"New file detected, path to it: {filePath}");
            MessageBox.Show("EncryptDecrypt = " + EncryptDecrypt.ToString());
            string decryptPath = string.Empty;
            if (EncryptDecrypt == true && FSWActive == false)
            {
                Task task = Task.Run(() =>
                {
                    MessageBox.Show("Encryption started");
                    decryptPath = rc6ofb.RC6OFBEncryptFile(filePath);
                    MessageBox.Show($"New file to decrypt: {decryptPath}");
                    encryptionCounter += 1;
                    lblNumberOfEncryptedFiles.Text = encryptionCounter.ToString();
                });
            }
            else if (EncryptDecrypt == false && FSWActive == false)
                if (string.IsNullOrEmpty(savePath))
                    MessageBox.Show("Niste odabrali mesto gde ce se fajl sacuvati nakon dekripcije");
                else
                {
                    Task task = Task.Run(() =>
                    {
                        rc6ofb.RC6OFBDecryptFile(filePath, savePath);
                        MessageBox.Show("Decryption over");
                        decryptionCounter += 1;
                        lblNumberOfDecryptedFiles.Text = decryptionCounter.ToString();
                    });
                }
            else if (FSWActive == true && EncryptDecrypt == true)
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
        public void EncryptDecryptBifid(string filePath, bool EncryptDecrypt, string? savePath, bool? FSWActive)
        {
            MessageBox.Show($"New file detected, path to it: {filePath}");
            MessageBox.Show("EncryptDecrypt = " + EncryptDecrypt.ToString());
            string decryptPath = string.Empty;
            if (EncryptDecrypt == true && FSWActive == false)
            {
                Task task = Task.Run(() =>
                {
                    MessageBox.Show("Encryption started");
                    decryptPath = bifid.BifidEncryptFile(filePath);
                    MessageBox.Show($"New file to decrypt: {decryptPath}");
                    encryptionCounter += 1;
                    lblNumberOfEncryptedFiles.Text = encryptionCounter.ToString();
                });
            }
            else if (EncryptDecrypt == false && FSWActive == false)
                if (string.IsNullOrEmpty(savePath))
                    MessageBox.Show("Niste odabrali mesto gde ce se fajl sacuvati nakon dekripcije");
                else
                {
                    Task task = Task.Run(() =>
                    {
                        MessageBox.Show("Decryption started");
                        bifid.BifidDecryptFile(filePath, savePath);
                        MessageBox.Show($"Decryption over, file {filePath} decrypted");
                        decryptionCounter += 1;
                        lblNumberOfDecryptedFiles.Text = decryptionCounter.ToString();
                    });
                }
            else if (FSWActive == true && EncryptDecrypt == true)
            {
                Task task = Task.Run(() =>
                {
                    MessageBox.Show("Encryption started");
                    decryptPath = bifid.BifidEncryptFile(filePath);
                    MessageBox.Show($"Encryption over, new file to decrypt: {decryptPath}");
                });
            }
            else
            {
                MessageBox.Show("Greska prilikom enkripcije ili dekripcije Bifid");
            }
        }
        public void ClearLabels(Label lblFileAttributes, Label lblFileDateCreated, Label lblFileDateModified, 
            Label lblFileExtension, Label lblFileName, Label lblFilePath, Label lblFileSize)
        {
            lblFileAttributes.Text = "Attributes: ";
            lblFileDateCreated.Text = "Date created: ";
            lblFileDateModified.Text = "Date modified: ";
            lblFileExtension.Text = "Extension: ";
            lblFileName.Text = "File name: ";
            lblFilePath.Text = "Path: ";
            lblFileSize.Text = "File size: ";
        }
        public void btnSelectFileToEncryptDecryptClick(Label lblFileAttributes, Label lblFileDateCreated,
            Label lblFileDateModified, Label lblFileExtension, Label lblFileName, Label lblFilePath, 
            Label lblFileSize, CheckBox cbEnableDisable)
        {
            ClearLabels(lblFileAttributes, lblFileDateCreated, lblFileDateModified, lblFileExtension, 
                lblFileName, lblFilePath, lblFileSize);

            string selectedFile = globalFunctionalities.ChoseFile();
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
                MessageBox.Show($"Putanja: {selectedFile}");
            }
            else
            {
                MessageBox.Show("FSW mora biti iskljucen");
            }
        }
        public void btnEncryptSelectedFileClick(RadioButton rbBifid, CheckBox cbEnableDisable, RichTextBox rtbLog, 
            Label lblFileAttributes, Label lblFileDateCreated, Label lblFileDateModified, Label lblFileExtension, 
            Label lblFileName, Label lblFilePath, Label lblFileSize)
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

                HandleNewFile(selectedFile, EncryptDecrypt, null, rbChecked, FSWActive);
                globalFunctionalities.FillTheLog(rtbLog, null, $"File {selectedFile} encrypted using ", rbChecked, false);
                ClearLabels(lblFileAttributes, lblFileDateCreated, lblFileDateModified, lblFileExtension, 
                    lblFileName, lblFilePath, lblFileSize);
            }
            else
            {
                MessageBox.Show("FSW mora biti iskljucen");
            }
        }
        public void btnDecryptSelectedFileClick(RadioButton rbBifid, CheckBox cbEnableDisable, RichTextBox rtbLog,
            Label lblFileAttributes, Label lblFileDateCreated, Label lblFileDateModified, Label lblFileExtension,
            Label lblFileName, Label lblFilePath, Label lblFileSize) 
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
                            HandleNewFile(selectedFile, EncryptDecrypt, savePath, rbChecked, FSWActive);
                            globalFunctionalities.FillTheLog(rtbLog, null, $"File {selectedFile} decrypted using ", rbChecked, false);
                            ClearLabels(lblFileAttributes, lblFileDateCreated, lblFileDateModified, 
                                lblFileExtension, lblFileName, lblFilePath, lblFileSize);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("FSW mora biti isključen");
            }
        }
    }
}