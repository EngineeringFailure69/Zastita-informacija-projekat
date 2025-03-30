namespace Encryption_Exchange_App.EncryptionDecryption_Algorithms
{
    public class Bifid
    {
        #region BifidDeclarations
        private static string folderFSWPath = @"C:\Users\Windows\Desktop\X\";
        string sentence = string.Empty, encrypted = string.Empty, decrypted = string.Empty;
        const string alphabet = "abcdefghiklmnopqrstuvwxyz";
        List<int> rows = new List<int>();
        List<int> cols = new List<int>();
        List<int> code = new List<int>();
        List<char> letters = new List<char>(alphabet);
        GlobalFunctionalities globalFunctionalities = new GlobalFunctionalities();
        #endregion

        #region BifidEnkripcija/Dekripcija
        public void SetXDirectory(string xDirectory)
        {
            folderFSWPath = xDirectory;
        }
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
        #endregion
    }
}