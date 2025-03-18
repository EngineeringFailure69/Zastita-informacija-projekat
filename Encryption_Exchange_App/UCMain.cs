namespace Encryption_Exchange_App
{
    public partial class UCMain : UserControl
    {
        private MainForm mainForm;
        private static string folderFSWPath = @"C:\Users\Windows\Desktop\X\";
        private static string folderFSWPath1 = @"C:\Users\Windows\Desktop\X\";
        private string selectedFilePath = string.Empty;
        #region BifidDeclarations
        string sentence, encrypted, decrypted;
        string alphabet = "abcdefghiklmnopqrstuvwxyz";
        //char[,] square;
        List<int> rows;
        List<int> cols;
        List<int> code;
        List<char> letters;
        //Random rand;
        #endregion
        #region RC6Declarations
        private const int w = 32;
        private const int r = 20;
        private static readonly uint P32 = 0xB7E15163;
        private static readonly uint Q32 = 0x9E3779B9;
        #endregion
        public UCMain(MainForm mainForm)
        {
            #region BifidInitialization
            sentence = string.Empty;
            decrypted = string.Empty;
            encrypted = string.Empty;
            //rand = new Random();
            //string alphabet = "abcdefghiklmnopqrstuvwxyz";
            letters = new List<char>(alphabet);
            rows = new List<int>();
            cols = new List<int>();
            code = new List<int>();
            //square = new char[5, 5];
            #endregion
            InitializeComponent();
            this.mainForm = mainForm;
        }
        #region BifidEnkripcija/Dekripcija
        public char[,] generateSquare()
        {
            letters = new List<char>(alphabet);
            Random rand = new Random();
            char[,] square = new char[5, 5];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    int index = rand.Next(letters.Count);
                    char letter = letters[index];

                    square[i, j] = letter;

                    letters.RemoveAt(index);
                }
            }
            return square;
        }
        public string BifidEncrypt(string input, char[,] square)
        {
            sentence = input;
            rows.Clear();
            cols.Clear();
            code.Clear();
            string encryptedText = string.Empty;

            int k = 0;
            while (k < sentence.Length)
            {
                bool found = false;

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if ((square[i, j] == sentence[k] && sentence[k] != ' ') || sentence[k] == 'j')
                        {
                            if (sentence[k] == 'j')
                            {
                                for (int l = 0; l < 5; l++)
                                {
                                    for (int m = 0; m < 5; m++)
                                    {
                                        if (square[l, m] == 'i')
                                        {
                                            rows.Add(l);
                                            cols.Add(m);
                                            found = true;
                                            break;
                                        }
                                    }
                                    if (found) break;
                                }
                            }
                            else
                            {
                                rows.Add(i);
                                cols.Add(j);
                                found = true;
                            }
                            break;
                        }
                    }
                    if (found) break;
                }
                k++;
            }

            int rowsCount = rows.Count;
            int colsCount = cols.Count;
            int a = 0, b = 0;

            while (a < rowsCount || b < colsCount)
            {
                for (int r = 0; r < 5 && a < rowsCount; r++, a++)
                {
                    code.Add(rows[a]);
                }

                for (int c = 0; c < 5 && b < colsCount; c++, b++)
                {
                    code.Add(cols[b]);
                }
            }

            for (int i = 0; i < code.Count; i = i + 2)
            {
                char letter = square[code[i], code[i + 1]];
                encryptedText += letter;
            }

            return encryptedText;
        }
        public string BifidDecrypt(List<int> code, char[,] square)
        {
            decrypted = string.Empty;
            List<int> decRows = new List<int>();
            List<int> decCols = new List<int>();

            int Count = code.Count;
            int checkLength = Count;
            int a = 0, b = 0;

            while (a < Count || b < Count)
            {
                if (checkLength < 10)
                {
                    a = b;
                    for (int r = 0; r < checkLength / 2 && a < (Count - (checkLength / 2)); r++, a++)
                        decRows.Add(code[a]);
                    b = a;
                    for (int c = 0; c < checkLength / 2 && b < Count; c++, b++)
                        decCols.Add(code[b]);
                }
                else if (checkLength >= 10)
                {
                    a = b;
                    for (int r = 0; r < 5 && a < Count; r++, a++)
                        decRows.Add(code[a]);
                    b = a;
                    for (int c = 0; c < 5 && b < Count; c++, b++)
                        decCols.Add(code[b]);
                }
                checkLength -= 10;
            }

            for (int i = 0; i < Count / 2; i++)
            {
                char letter = square[decRows[i], decCols[i]];
                decrypted += letter;
            }

            return decrypted;
        }
        public string BifidEncryptFile(string inputFile)
        {
            string fileContent = string.Empty;
            string extension = Path.GetExtension(inputFile);
            if (extension == ".txt" || extension == ".html") //ako je fajl txt
            {
                fileContent = File.ReadAllText(inputFile);
            }
            else //ako nije txt
            {
                MessageBox.Show($"Fajl {inputFile} ne moze biti sifrovan jer nije .txt fajl");
                return null;
            }
            char[,] square = generateSquare();

            string encryptedText = BifidEncrypt(fileContent, square);


            string squareString = ConvertSquareToString(square);
            string encryptedIndices = string.Empty;
            foreach (var number in code)
            {
                encryptedIndices += number;
            }

            string encryptedFile = Path.Combine(folderFSWPath, Path.GetFileName(inputFile) + ".enc");
            File.WriteAllText(encryptedFile, squareString + Environment.NewLine + encryptedIndices + Environment.NewLine + encryptedText); 

            MessageBox.Show($"Fajl {inputFile} je šifrovan kao {encryptedFile}");
            return encryptedFile;
        }
        public void BifidDecryptFile(string encryptedFile, string savePath)
        {
            try
            {
                string[] fileContent = File.ReadAllLines(encryptedFile);

                string squareString = fileContent[0];
                string encryptedIndices = fileContent[1];

                char[,] square = ConvertStringToSquare(squareString);
                List<int> code = new List<int>();

                for (int i = 0; i < encryptedIndices.Length; i += 1)
                {
                    string numStr = encryptedIndices.Substring(i, 1);
                    if (int.TryParse(numStr, out int number))
                    {
                        code.Add(number);
                    }
                    else
                    {
                        MessageBox.Show($"Neispravan broj u šifrovanom indeksu: {numStr}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                string decryptedText = BifidDecrypt(code, square);

                //string outputFolder = Path.GetDirectoryName(folderFSWPath1);
                //if (!Directory.Exists(outputFolder))
                //{
                //    Directory.CreateDirectory(outputFolder);
                //}

                //skidam ekstenziju 
                string originalFileName = Path.GetFileNameWithoutExtension(encryptedFile);
                string origExtension = Path.GetExtension(originalFileName);
                //string decryptedFile = Path.Combine(savePath, originalFileName);
                string decryptedFile = savePath + origExtension;

                File.WriteAllText(decryptedFile, decryptedText);

                MessageBox.Show($"Fajl {encryptedFile} je dešifrovan u {decryptedFile}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške: {ex.Message}\n{ex.StackTrace}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private char[,] ConvertStringToSquare(string squareString)
        {
            char[,] square = new char[5, 5];
            int index = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    square[i, j] = squareString[index++];
                }
            }
            return square;
        }
        public void PrintSquare(char[,] square)
        {
            int size = square.GetLength(0);
            string output = "Kvadrat:\n";

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    output += square[i, j] + " ";
                }
                output += "\n";
            }

            MessageBox.Show(output, "Provera kvadrata");
        }
        private string ConvertSquareToString(char[,] square)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    sb.Append(square[i, j]);
                }
            }
            return sb.ToString();
        }
        //public void ResetData()
        //{
        //    sentence = textBox1.Text;
        //    encrypted = string.Empty;
        //    decrypted = string.Empty;
        //    rows.Clear();
        //    cols.Clear();
        //    code.Clear();

        //    string alphabet = "abcdefghiklmnopqrstuvwxyz";
        //    letters = new List<char>(alphabet);

        //    square = new char[5, 5];
        //}
        #endregion

        #region RC6Enkripcija/Dekripcija
        public byte[] GenerateKeyAndIV(int length)
        {
            byte[] randomBytes = new byte[length];
            using (RandomNumberGenerator rndng = RandomNumberGenerator.Create())
            {
                rndng.GetBytes(randomBytes);
            }
            return randomBytes;
        }
        public uint[] KeyExpansion(byte[] key)
        {
            int c = (int)Math.Ceiling(key.Length / 4.0); 
            uint[] L = new uint[c];
            Array.Clear(L, 0, L.Length);

            for (int i = 0; i < key.Length / 4; i++)
                L[i] = BitConverter.ToUInt32(key, i * 4);

            uint[] S = new uint[2 * r + 4];
            S[0] = P32;
            for (int i = 1; i < S.Length; i++)
                S[i] = S[i - 1] + Q32;

            uint A = 0, B = 0;
            int iIndex = 0, jIndex = 0;
            int loops = 3 * Math.Max(S.Length, L.Length);

            for (int k = 0; k < loops; k++)
            {
                S[iIndex] = RotateLeft(S[iIndex] + A + B, 3);
                A = S[iIndex];
                iIndex = (iIndex + 1) % S.Length;

                L[jIndex] = RotateLeft(L[jIndex] + A + B, (int)((A + B) & 31));
                B = L[jIndex];
                jIndex = (jIndex + 1) % L.Length;
            }
            return S;
        }
        public byte[] RC6EncryptIV(byte[] block, uint[] S)
        {
            if (block.Length != 16)
                throw new ArgumentException("Block mora biti tačno 16 bajtova!");

            uint A = BitConverter.ToUInt32(block, 0);
            uint B = BitConverter.ToUInt32(block, 4);
            uint C = BitConverter.ToUInt32(block, 8);
            uint D = BitConverter.ToUInt32(block, 12);

            B += S[0];
            D += S[1];

            for (int i = 1; i <= r; i++)  
            {
                uint t = RotateLeft(B * (2 * B + 1), 5);
                uint u = RotateLeft(D * (2 * D + 1), 5);

                A = RotateLeft(A ^ t, (int)(u & 31)) + S[2 * i];
                C = RotateLeft(C ^ u, (int)(t & 31)) + S[2 * i + 1];

                uint temp = A;
                A = B;
                B = C;
                C = D;
                D = temp;
            }

            A += S[2 * r + 2];
            C += S[2 * r + 3];

            byte[] encryptedBlock = new byte[16];
            Array.Copy(BitConverter.GetBytes(A), 0, encryptedBlock, 0, 4);
            Array.Copy(BitConverter.GetBytes(B), 0, encryptedBlock, 4, 4);
            Array.Copy(BitConverter.GetBytes(C), 0, encryptedBlock, 8, 4);
            Array.Copy(BitConverter.GetBytes(D), 0, encryptedBlock, 12, 4);

            return encryptedBlock;
        }
        public uint RotateLeft(uint value, int shift)
        {
            shift = shift & 31; 
            return (value << shift) | (value >> (32 - shift));
        }
        public byte[] GenerateKeystream(byte[] IV, int length, uint[] S)
        {
            byte[] keystream = new byte[length];
            byte[] currentBlock = IV;

            for (int i = 0; i < length; i += 16)
            {
                currentBlock = RC6EncryptIV(currentBlock, S); 
                Array.Copy(currentBlock, 0, keystream, i, Math.Min(16, length - i));
            }
            return keystream;
        }
        public byte[] Encrypt(byte[] plaintext, byte[] IV, uint[] S)
        {
            byte[] keystream = GenerateKeystream(IV, plaintext.Length, S);
            byte[] ciphertext = new byte[plaintext.Length];

            for (int i = 0; i < plaintext.Length; i++)
                ciphertext[i] = (byte)(plaintext[i] ^ keystream[i]);

            return ciphertext;
        }
        public byte[] Decrypt(byte[] ciphertext, byte[] IV, uint[] S)
        {
            byte[] keystream = GenerateKeystream(IV, ciphertext.Length, S);
            byte[] decryptedText = new byte[ciphertext.Length];

            for (int i = 0; i < ciphertext.Length; i++)
                decryptedText[i] = (byte)(ciphertext[i] ^ keystream[i]);

            return decryptedText;
        }
        public string RC6OFBEncryptFile(string inputFile)
        {
            byte[] fileContent = File.ReadAllBytes(inputFile);
            int length = 16;
            byte[] key = GenerateKeyAndIV(length);
            byte[] IV = GenerateKeyAndIV(length);

            uint[] expandedKey = KeyExpansion(key);
            byte[] encryptedIV = RC6EncryptIV(IV, expandedKey);
            byte[] encryptedText = Encrypt(fileContent, encryptedIV, expandedKey);

            byte[] expandedKeyBytes = expandedKey.SelectMany(BitConverter.GetBytes).ToArray();
            string expandedKeyBase64 = Convert.ToBase64String(expandedKeyBytes);

            //string encryptedFile = folderFSWPath;
            string encryptedFile = Path.Combine(folderFSWPath, Path.GetFileName(inputFile) + ".enc");

            File.WriteAllLines(encryptedFile, new string[]
            {
                expandedKeyBase64,
                Convert.ToBase64String(encryptedIV),
                Convert.ToBase64String(encryptedText)
            });

            MessageBox.Show($"Fajl {inputFile} je šifrovan kao {encryptedFile}.");
            return encryptedFile;
        }
        public void RC6OFBDecryptFile(string encryptedFile, string savePath)
        {
            string[] lines = File.ReadAllLines(encryptedFile);
            if (lines.Length < 3)
                throw new Exception("Neispravan format šifrovanog fajla.");

            byte[] expandedKeyBytes = Convert.FromBase64String(lines[0]);
            uint[] expandedKey = new uint[expandedKeyBytes.Length / 4];
            Buffer.BlockCopy(expandedKeyBytes, 0, expandedKey, 0, expandedKeyBytes.Length);

            byte[] encryptedIV = Convert.FromBase64String(lines[1]);
            byte[] encryptedText = Convert.FromBase64String(lines[2]);
            byte[] decryptedText = Decrypt(encryptedText, encryptedIV, expandedKey);

            //Skidam ekstenziju
            string originalFileName = Path.GetFileNameWithoutExtension(encryptedFile);
            string origExtension = Path.GetExtension(originalFileName);
            //string decryptedFile = Path.Combine(savePath, originalFileName);
            string decryptedFile = savePath + origExtension;

            File.WriteAllBytes(decryptedFile, decryptedText);

            MessageBox.Show($"Fajl {encryptedFile} je dešifrovan u {decryptedFile}");
        }
        #endregion

        #region Funkcionalnosti
        public void ClearLabels() 
        {
            lblFileAttributes.Text = "Attributes: ";
            lblFileDateCreated.Text = "Date created: ";
            lblFileDateModified.Text = "Date modified: ";
            lblFileExtension.Text = "Extension: ";
            lblFileName.Text = "File name: ";
            lblFilePath.Text = "Path: ";
            lblFileSize.Text = "File size: ";
        }
        public void HandleNewFile(string filePath, bool EncryptDecrypt, string? savePath)
        {
            if (mainForm.RC6Checked == true)
            {
                EncryptDecryptRC6(filePath, EncryptDecrypt, savePath);
            }
            else if (mainForm.BifidChecked == true) 
            {
                EncryptDecryptBifid(filePath, EncryptDecrypt, savePath);
            }
            else
            {
                MessageBox.Show("Greska prilikom enkripcije ili dekripcije");
            }
            //MessageBox.Show($"New file detected, path to it: {filePath}");
            //MessageBox.Show("EncryptDecrypt = " + EncryptDecrypt.ToString());
            //string decryptPath = string.Empty;
            //if (EncryptDecrypt == true && mainForm.IsFSWEnabled == false)
            //{
            //    decryptPath = RC6OFBEncryptFile(filePath);
            //    MessageBox.Show($"New file to decrypt: {decryptPath}");
            //}
            //else if (EncryptDecrypt == false && mainForm.IsFSWEnabled == false)
            //    if (string.IsNullOrEmpty(savePath))
            //        MessageBox.Show("Niste odabrali mesto gde ce se fajl sacuvati nakon dekripcije");
            //    else
            //        RC6OFBDecryptFile(filePath, savePath);
            //else if (mainForm.IsFSWEnabled == true && EncryptDecrypt == true) 
            //{
            //    decryptPath = RC6OFBEncryptFile(filePath);
            //    MessageBox.Show($"New file to decrypt: {decryptPath}");
            //}
            //else
            //{
            //    MessageBox.Show("Greska prilikom enkripcije ili dekripcije");
            //}
        }
        public void EncryptDecryptRC6(string filePath, bool EncryptDecrypt, string? savePath) 
        {
            MessageBox.Show($"New file detected, path to it: {filePath}");
            MessageBox.Show("EncryptDecrypt = " + EncryptDecrypt.ToString());
            string decryptPath = string.Empty;
            if (EncryptDecrypt == true && mainForm.IsFSWEnabled == false)
            {
                Task task = Task.Run(() =>
                {
                    MessageBox.Show("Encryption started");
                    decryptPath = RC6OFBEncryptFile(filePath);
                    MessageBox.Show($"New file to decrypt: {decryptPath}");
                });
                //decryptPath = RC6OFBEncryptFile(filePath);
                //MessageBox.Show($"New file to decrypt: {decryptPath}");
            }
            else if (EncryptDecrypt == false && mainForm.IsFSWEnabled == false)
                if (string.IsNullOrEmpty(savePath))
                    MessageBox.Show("Niste odabrali mesto gde ce se fajl sacuvati nakon dekripcije");
                else 
                {
                    Task task = Task.Run(() =>
                    {
                        RC6OFBDecryptFile(filePath, savePath);
                        MessageBox.Show("Decryption over");
                    });
                } 
                   // RC6OFBDecryptFile(filePath, savePath);
            else if (mainForm.IsFSWEnabled == true && EncryptDecrypt == true)
            {
                Task task = Task.Run(() =>
                {
                    MessageBox.Show("Encryption started");
                    decryptPath = RC6OFBEncryptFile(filePath);
                    MessageBox.Show($"New file to decrypt: {decryptPath}");
                });
            }
            else
            {
                MessageBox.Show("Greska prilikom enkripcije ili dekripcije RC6");
            }
        }
        public void EncryptDecryptBifid(string filePath, bool EncryptDecrypt, string? savePath)
        {
            MessageBox.Show($"New file detected, path to it: {filePath}");
            MessageBox.Show("EncryptDecrypt = " + EncryptDecrypt.ToString());
            string decryptPath = string.Empty;
            if (EncryptDecrypt == true && mainForm.IsFSWEnabled == false)
            {
                Task task = Task.Run(() =>
                {
                    MessageBox.Show("Encryption started");
                    decryptPath = BifidEncryptFile(filePath);
                    MessageBox.Show($"New file to decrypt: {decryptPath}");
                });
                //decryptPath = BifidEncryptFile(filePath);
                //MessageBox.Show($"New file to decrypt: {decryptPath}");
            }
            else if (EncryptDecrypt == false && mainForm.IsFSWEnabled == false)
                if (string.IsNullOrEmpty(savePath))
                    MessageBox.Show("Niste odabrali mesto gde ce se fajl sacuvati nakon dekripcije");
                else 
                {
                    Task task = Task.Run(() =>
                    {
                        MessageBox.Show("Decryption started");
                        BifidDecryptFile(filePath, savePath);
                        MessageBox.Show($"Decryption over, file {filePath} decrypted");
                    });
                    //MessageBox.Show("Decryption started");
                    //BifidDecryptFile(filePath, savePath);
                    //MessageBox.Show($"New file to decrypt: {decryptPath}");
                }
                    //BifidDecryptFile(filePath, savePath);
            else if (mainForm.IsFSWEnabled == true && EncryptDecrypt == true)
            {
                Task task = Task.Run(() =>
                {
                    MessageBox.Show("Encryption started");
                    decryptPath = BifidEncryptFile(filePath);
                    MessageBox.Show($"Encryption over, new file to decrypt: {decryptPath}");
                });
                //decryptPath = BifidEncryptFile(filePath);
                //MessageBox.Show($"New file to decrypt: {decryptPath}");
            }
            else
            {
                MessageBox.Show("Greska prilikom enkripcije ili dekripcije Bifid");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //int length = 16;
            //byte[] key = GenerateKeyAndIV(length);
            //byte[] IV = GenerateKeyAndIV(length);

            //uint[] expandedKey = KeyExpansion(key);
            //byte[] encryptedIV = RC6EncryptIV(IV, expandedKey);

            //byte[] plaintext = Encoding.UTF8.GetBytes(textBox1.Text);
            //byte[] ciphertext = Encrypt(plaintext, encryptedIV, expandedKey);
            //textBox2.Text = BitConverter.ToString(ciphertext).Replace("-", "");
            //byte[] decryptedText = Decrypt(ciphertext, encryptedIV, expandedKey);
            //textBox3.Text = Encoding.UTF8.GetString(decryptedText);
        }
        private void btnSelectFileToEncrypt_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "All files (*.*)|*.*";
                ofd.Title = "Select a file from the directory";
                ofd.CheckFileExists = true;
                ofd.FileName = "Select Folder";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string selectedFile = ofd.FileName;
                    if (mainForm.IsFSWEnabled == false)
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
                        MessageBox.Show($"Putanja: {selectedFilePath}");
                    }
                    else
                    {
                        MessageBox.Show("FSW mora biti iskljucen");
                    }
                }
            }
        }
        private void btnEncryptSelectedFile_Click(object sender, EventArgs e)
        {
            bool EncryptDecrypt = true;
            string selectedFile = selectedFilePath;
            if (string.IsNullOrEmpty(selectedFile))
                MessageBox.Show("Niste odabrali fajl");
            else if (mainForm.IsFSWEnabled == false)
            {
                mainForm.ReceiveNewFile(selectedFile, EncryptDecrypt, null);
                ClearLabels();
            }
            else
            {
                MessageBox.Show("FSW mora biti iskljucen");
            }
        }
        private void btnDecryptSelectedFile_Click(object sender, EventArgs e)
        {
            bool EncryptDecrypt = false;
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
            if (mainForm.IsFSWEnabled == false)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Title = "Sačuvaj dekriptovani fajl kao";
                    sfd.Filter = "All files (*.*)|*.*";
                    sfd.FileName = Path.GetFileNameWithoutExtension(selectedFile);

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        string savePath = sfd.FileName;
                        if (string.IsNullOrEmpty(savePath))
                            MessageBox.Show("Niste odabrali mesto gde ce se fajl sacuvati nakon dekripcije");
                        else 
                        {
                            mainForm.ReceiveNewFile(selectedFile, EncryptDecrypt, savePath);
                            ClearLabels();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("FSW mora biti isključen");
            }
        }
        #endregion
    }
}
