namespace Encryption_Exchange_App.Functionalities
{
    public class MainFunctionalities
    {
        private RC6OFB rc6ofb = new RC6OFB();
        private Bifid bifid = new Bifid();
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
    }
}