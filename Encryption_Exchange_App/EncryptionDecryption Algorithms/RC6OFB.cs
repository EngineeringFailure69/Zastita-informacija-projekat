namespace Encryption_Exchange_App.EncryptionDecryption_Algorithms
{
    public class RC6OFB
    {
        #region RC6Declarations
        private const int w = 32;
        private const int r = 20;
        private static readonly uint P32 = 0xB7E15163;
        private static readonly uint Q32 = 0x9E3779B9;
        private static string folderFSWPath = @"C:\Users\Windows\Desktop\X\";
        #endregion

        #region RC6Enkripcija/Dekripcija
        public void SetXDirectory(string xDirectory)
        {
            folderFSWPath = xDirectory;
        }
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
            try
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
            catch (Exception ex) 
            {
                MessageBox.Show($"Greska: {ex.Message} - RC6OFBEncryptFile funkcija");
                return null;
            }
        }
        public void RC6OFBDecryptFile(string encryptedFile, string savePath)
        {
            try
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
                string decryptedFile = savePath + origExtension;

                File.WriteAllBytes(decryptedFile, decryptedText);

                MessageBox.Show($"Fajl {encryptedFile} je dešifrovan u {decryptedFile}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska: {ex.Message} - RC6OFBDecryptFile funkcija");
            }
        }
        public void EncryptDecryptRC6(string filePath, bool EncryptDecrypt, string? savePath, bool? FSWActive)
        {
            try
            {
                MessageBox.Show($"Novi fajl detektovan, putanja: {filePath}");
                MessageBox.Show("EncryptDecrypt = " + EncryptDecrypt.ToString());
                string decryptPath = string.Empty;
                if (EncryptDecrypt == true && FSWActive == false)
                {
                    Task task = Task.Run(() =>
                    {
                        MessageBox.Show("Enkripcija pokrenuta");
                        decryptPath = RC6OFBEncryptFile(filePath);
                        MessageBox.Show($"Novi fajl za dekriptovanje: {decryptPath}");
                    });
                }
                else if (EncryptDecrypt == false && FSWActive == false)
                    if (string.IsNullOrEmpty(savePath))
                        MessageBox.Show("Niste odabrali mesto gde ce se fajl sacuvati nakon dekripcije");
                    else
                    {
                        Task task = Task.Run(() =>
                        {
                            RC6OFBDecryptFile(filePath, savePath);
                            MessageBox.Show("Dekripcija zavrsena");
                        });
                    }
                else if (FSWActive == true && EncryptDecrypt == true)
                {
                    Task task = Task.Run(() =>
                    {
                        MessageBox.Show("Enkripcija pokrenuta");
                        decryptPath = RC6OFBEncryptFile(filePath);
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
        #endregion
    }
}