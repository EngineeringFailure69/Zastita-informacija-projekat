namespace Encryption_Exchange_App.Functionalities
{
    public class EncryptionFunctionalities
    {
        private Label lblNumberOfEncryptedFiles;
        private Label lblNumberOfDecryptedFiles;
        private Label lblLastActivity;
        private RichTextBox rtbAppLog;

        public EncryptionFunctionalities(Label? lblNumberOfEncryptedFiles, Label? lblNumberOfDecryptedFiles, Label? lblLastActivity, RichTextBox? rtbAppLog)
        {
            this.lblNumberOfEncryptedFiles = lblNumberOfEncryptedFiles!;
            this.lblNumberOfDecryptedFiles = lblNumberOfDecryptedFiles!;
            this.lblLastActivity = lblLastActivity!;
            this.rtbAppLog = rtbAppLog!;
        }

        private RC6OFB rc6ofb = new RC6OFB();
        private Bifid bifid = new Bifid();
        private GlobalFunctionalities globalFunctionalities = new GlobalFunctionalities();

        private string selectedFilePath = string.Empty;
        private int encryptionCounter = 0;
        private int decryptionCounter = 0;

        public void HandleNewFile(string filePath, bool EncryptDecrypt, string? savePath, bool? rbChecked, bool? FSWActive)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message} - HandleNewFile funkcija");
            }
        }
        public void EncryptDecryptRC6(string filePath, bool EncryptDecrypt, string? savePath, bool? FSWActive)
        {
            try
            {

                MessageBox.Show($"Novi fajl detektovan, putanja: {filePath}");
                string decryptPath = string.Empty;
                if (EncryptDecrypt == true && FSWActive == false)
                {
                    Task task = Task.Run(() =>
                    {
                        MessageBox.Show("Enkripcija pokrenuta:");
                        decryptPath = rc6ofb.RC6OFBEncryptFile(filePath);
                        MessageBox.Show($"Novi fajl za dekriptovanje: {decryptPath}");
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
                            MessageBox.Show("Dekripcija zavrsena");
                            decryptionCounter += 1;
                            lblNumberOfDecryptedFiles.Text = decryptionCounter.ToString();
                        });
                    }
                else if (FSWActive == true && EncryptDecrypt == true)
                {
                    Task task = Task.Run(() =>
                    {
                        MessageBox.Show("Enkripcija  pokrenuta: ");
                        decryptPath = rc6ofb.RC6OFBEncryptFile(filePath);
                        MessageBox.Show($"Novi fajl za dekriptovanje: {decryptPath}");
                    });
                }
                else
                {
                    MessageBox.Show("Greska prilikom enkripcije ili dekripcije RC6");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message} - EncryptDecryptRC6 funkcija");
            }
        }
        public void EncryptDecryptBifid(string filePath, bool EncryptDecrypt, string? savePath, bool? FSWActive)
        {
            try
            {
                MessageBox.Show($"Novi fajl detektovan, putanja: {filePath}");
                string decryptPath = string.Empty;
                if (EncryptDecrypt == true && FSWActive == false)
                {
                    Task task = Task.Run(() =>
                    {
                        MessageBox.Show("Ekripcija pokrenuta");
                        decryptPath = bifid.BifidEncryptFile(filePath);
                        MessageBox.Show($"Novi fajl za dekriptovanje: {decryptPath}");
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
                            MessageBox.Show("Dekripcija pokrenuta");
                            bifid.BifidDecryptFile(filePath, savePath);
                            MessageBox.Show($"Dekripcija  zavrsena, fajl {filePath} dekriptovan");
                            decryptionCounter += 1;
                            lblNumberOfDecryptedFiles.Text = decryptionCounter.ToString();
                        });
                    }
                else if (FSWActive == true && EncryptDecrypt == true)
                {
                    Task task = Task.Run(() =>
                    {
                        MessageBox.Show("Enkripcija pokrenuta");
                        decryptPath = bifid.BifidEncryptFile(filePath);
                        MessageBox.Show($"Enkripcija zavrsena, novi fajl za dekriptovanje: {decryptPath}");
                    });
                }
                else
                {
                    MessageBox.Show("Greska prilikom enkripcije ili dekripcije Bifid");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message} - EncryptDecryptBifid funkcija");
            }
        }
        public void ClearLabels(Label lblFileAttributes, Label lblFileDateCreated, Label lblFileDateModified,
            Label lblFileExtension, Label lblFileName, Label lblFilePath, Label lblFileSize)
        {
            lblFileAttributes.Text = "Atributi: ";
            lblFileDateCreated.Text = "Datum kreiranja: ";
            lblFileDateModified.Text = "Datum modifikacije: ";
            lblFileExtension.Text = "Ekstenzija: ";
            lblFileName.Text = "Ime fajla: ";
            lblFilePath.Text = "Putanja: ";
            lblFileSize.Text = "Velicina fajla: ";
        }
        public void btnSelectFileToEncryptDecryptClick(Label lblFileAttributes, Label lblFileDateCreated,
            Label lblFileDateModified, Label lblFileExtension, Label lblFileName, Label lblFilePath,
            Label lblFileSize, CheckBox cbEnableDisable)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message} - btnSelectFileToEncryptDecryptClick funkcija");
            }
        }
        public void btnEncryptSelectedFileClick(RadioButton rbBifid, CheckBox cbEnableDisable, RichTextBox rtbLog,
            Label lblFileAttributes, Label lblFileDateCreated, Label lblFileDateModified, Label lblFileExtension,
            Label lblFileName, Label lblFilePath, Label lblFileSize)
        {
            try
            {
                bool EncryptDecrypt = true;
                bool FSWActive = cbEnableDisable.Checked;
                bool rbChecked;
                bool fileExtension;
                string appLogText = string.Empty;
                string labelText = string.Empty;
                if (rbBifid.Checked == true)
                    rbChecked = false;
                else
                    rbChecked = true;
                string selectedFile = selectedFilePath;
                if (string.IsNullOrEmpty(selectedFile))
                    MessageBox.Show("Niste odabrali fajl");

                //sifrovanje i popunjavanje log-ova i labele
                else if (cbEnableDisable.Checked == false)
                {
                    fileExtension = globalFunctionalities.CheckExtension(selectedFile, rbBifid);
                    if (rbBifid.Checked == true && fileExtension == true)
                        appLogText = $"Fajl {selectedFile} enkriptovan koriscenjem Bifid cypher-a i sacuvan u X folderu";
                    else if (rbBifid.Checked == true && fileExtension == false)
                        appLogText = $"Fajl {selectedFile} ne moze biti kriptovan koriscenjem Bifid cypher-a zato sto nije txt fajl";
                    else
                        appLogText = $"Fajl {selectedFile} enkriptovan koriscenjem RC6 + OFB algoritmai sacuvan u X folder";

                    HandleNewFile(selectedFile, EncryptDecrypt, null, rbChecked, FSWActive); //sifrovanje

                    globalFunctionalities.FillTheLog(rtbAppLog, rtbLog, null, null, $"Fajl {selectedFile} enkriptovan koriscenjem ", appLogText, false, false);
                    globalFunctionalities.SetLabelText(lblLastActivity, appLogText);
                    ClearLabels(lblFileAttributes, lblFileDateCreated, lblFileDateModified, lblFileExtension,
                        lblFileName, lblFilePath, lblFileSize);
                }
                else
                {
                    MessageBox.Show("FSW mora biti iskljucen");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message} - btnEncryptSelectedFileClick funkcija");
            }
        }
        public void btnDecryptSelectedFileClick(RadioButton rbBifid, CheckBox cbEnableDisable, RichTextBox rtbLog,
            Label lblFileAttributes, Label lblFileDateCreated, Label lblFileDateModified, Label lblFileExtension,
            Label lblFileName, Label lblFilePath, Label lblFileSize)
        {
            try
            {
                bool EncryptDecrypt = false;
                bool FSWActive = cbEnableDisable.Checked;
                bool rbChecked;
                string labelText;
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
                    string savePath = globalFunctionalities.SaveFile(selectedFile);
                    if (string.IsNullOrEmpty(savePath))
                        MessageBox.Show("Niste odabrali mesto gde ce se fajl sacuvati nakon dekripcije");
                    else
                    {
                        labelText = (rbBifid.Checked == true) ? $"Fajl {selectedFile} dekriptovan koriscenjem Bifid cypher-a" : $"Fajl {selectedFile} dekriptovan koriscenjem RC6 + OFB algoritma";
                        globalFunctionalities.SetLabelText(lblLastActivity, labelText);
                        HandleNewFile(selectedFile, EncryptDecrypt, savePath, rbChecked, FSWActive);
                        globalFunctionalities.FillTheLog(rtbAppLog, rtbLog, null, null, labelText + $" i sacuvan je na lokaciji {savePath}", null, false, false);
                        ClearLabels(lblFileAttributes, lblFileDateCreated, lblFileDateModified,
                            lblFileExtension, lblFileName, lblFilePath, lblFileSize);
                    }
                }
                else
                {
                    MessageBox.Show("FSW mora biti iskljucen");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message} - btnDecryptSelectedFileClick funkcija");
            }
        }
    }
}