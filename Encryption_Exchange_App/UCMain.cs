namespace Encryption_Exchange_App
{
    public partial class UCMain : UserControl
    {
        private MainForm mainForm;
        #region Declarations
        string sentence, encrypted, decrypted;
        private static string folderFSWPath = @"C:\Users\Windows\Desktop\X";
        string alphabet = "abcdefghiklmnopqrstuvwxyz";
        //char[,] square;
        List<int> rows;
        List<int> cols;
        List<int> code;
        List<char> letters;
        //Random rand;
        #endregion
        public UCMain(MainForm mainForm)
        {
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
            InitializeComponent();
            this.mainForm = mainForm;
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
        public List<int> BifidEncrypt(string input, char[,] square)
        {
            sentence = input;

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
                encrypted += letter;
            }

            return code;
        }
        public string BifidDecrypt(string input, char[,] square)
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
        public void BifidEncryptFile(string inputFile)
        {
            byte[] fileBytes = File.ReadAllBytes(inputFile); 
            string base64 = Convert.ToBase64String(fileBytes);

            char[,] square = generateSquare(); 

            List<int> encrypted = BifidEncrypt(base64, square);

            string squareString = ConvertSquareToString(square);
            string outputFile = folderFSWPath + ".bifid";
            File.WriteAllText(outputFile, squareString + Environment.NewLine + encrypted); 

            MessageBox.Show($"Fajl {inputFile} je šifrovan kao {outputFile}");
        }
        public void BifidDecryptFile(string encryptedFile)
        {
            string[] fileContent = File.ReadAllLines(encryptedFile); 
            string squareString = fileContent[0]; 
            string encryptedText = fileContent[1];

            char[,] square = ConvertStringToSquare(squareString);

            string decryptedBase64 = BifidDecrypt(encryptedText, square);

            byte[] fileBytes = Convert.FromBase64String(decryptedBase64);

            string outputFile = encryptedFile.Replace(".bifid", "");

            File.WriteAllBytes(outputFile, fileBytes);

            MessageBox.Show($"Fajl {outputFile} je uspešno dešifrovan!");
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
        public void HandleNewFile(string filePath) 
        {
            MessageBox.Show($"New file detected, path to it: {filePath}");
            BifidEncryptFile(filePath);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //BifidEncrypt();
            //BifidDecrypt();
            //ResetData();
        }
    }
}
