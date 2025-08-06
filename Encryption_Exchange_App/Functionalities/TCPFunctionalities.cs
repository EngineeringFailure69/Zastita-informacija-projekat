namespace Encryption_Exchange_App.Functionalities
{
    public class TCPFunctionalities
    {
        private RC6OFB rc6ofb = new RC6OFB();
        private Bifid bifid = new Bifid();
        private SHA_1 sha1 = new SHA_1();

        GlobalFunctionalities globalFunctionalities = new GlobalFunctionalities();

        private Socket serverSocket;
        private Main mainForm;
        private RadioButton rbBifid;
        private TextBox tbIPAddress;
        private TextBox tbPort;
        private Label lblClientStatus;
        private Label lblServerStatus;
        private Control uiControl;
        private RichTextBox rtbClientSettings;
        private RichTextBox rtbServerSettings;
        private RichTextBox rtbAppLog;

        public TCPFunctionalities(Main mainForm, RadioButton rbBifid, TextBox tbIPAddress, 
            TextBox tbPort, Label lblClientStatus, Label lblServerStatus, Control uiControl, Socket serverSocket, 
            RichTextBox rtbClientSettings, RichTextBox rtbAppLog, RichTextBox rtbServerSettings) 
        {
            this.mainForm = mainForm;
            this.rbBifid = rbBifid;
            this.tbIPAddress = tbIPAddress;
            this.tbPort = tbPort;
            this.lblClientStatus = lblClientStatus;
            this.lblServerStatus = lblServerStatus;
            this.uiControl = uiControl;
            this.serverSocket = serverSocket;
            this.rtbClientSettings = rtbClientSettings;
            this.rtbAppLog = rtbAppLog;
            this.rtbServerSettings = rtbServerSettings;
        }

        public async Task AdvanceKlijent(string selectedFilePath)
        {
            try
            {
                string fileToEncrypt = selectedFilePath; //dodato
                string fileToSend = string.Empty;
                if (rbBifid.Checked == true)
                    fileToSend = bifid.BifidEncryptFile(fileToEncrypt); //dodato
                else
                    fileToSend = rc6ofb.RC6OFBEncryptFile(fileToEncrypt); //dodato

                using (Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    await clientSocket.ConnectAsync(this.tbIPAddress.Text, Int32.Parse(this.tbPort.Text));
                    UpdateStatus(lblClientStatus, "Povezan sa serverom");

                    using (NetworkStream networkStream = new NetworkStream(clientSocket))
                    using (BinaryReader reader = new BinaryReader(networkStream))
                    using (BinaryWriter writer = new BinaryWriter(networkStream))
                    {
                        //string filePath = this.lblChosenFile.Text;  //vrati
                        string filePath = fileToSend; //dodato
                        string fileName = Path.GetFileName(filePath);
                        long fileSize = new FileInfo(filePath).Length;
                        byte[] hash = sha1.GenerateHash(File.ReadAllBytes(filePath));
                        int hashLength = hash.Length;

                        //Slanje metapodataka
                        writer.Write(fileName);
                        writer.Write(fileSize);
                        writer.Write(hashLength);
                        writer.Write(hash);

                        //Slanje fajla u blokovima
                        using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                        {
                            byte[] buffer = new byte[4096];
                            int bytesRead;

                            while ((bytesRead = await fileStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await networkStream.WriteAsync(buffer, 0, bytesRead);
                            }
                        }

                        globalFunctionalities.FillTheLog(rtbAppLog, null, rtbClientSettings, null, $"Fajl {filePath} poslat", null, false, true);
                        //Odgovor servera
                        string response = reader.ReadString();
                        File.Delete(filePath);
                        UpdateStatus(lblClientStatus, $"Odgovor servera: {response}");
                        globalFunctionalities.FillTheLog(rtbAppLog, null, rtbClientSettings, null, $"Odgovor servera: {response}", null, false, true);
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateStatus(lblClientStatus, $"Greska: {ex.Message} - AdvanceKlijent funkcija");
            }
        }
        public async Task AdvanceServer()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                serverSocket.Bind(new IPEndPoint(IPAddress.Any, Int32.Parse(this.tbPort.Text)));
                serverSocket.Listen(5);
                UpdateStatus(lblServerStatus, "Server je spreman i osluskuje konekcije");
                globalFunctionalities.FillTheLog(rtbAppLog, null, rtbServerSettings, null, "Server je spreman i osluskuje konekcije", null, false, true);

                while (true)
                {
                    Socket clientSocket = await serverSocket.AcceptAsync();
                    Task.Run(() => HandleClientAsyncAdvance(clientSocket));
                }
            }
            catch (Exception ex)
            {
                UpdateStatus(lblServerStatus, $"Greska: {ex.Message} - AdvanceServer funkcija");
                globalFunctionalities.FillTheLog(rtbAppLog, null, rtbServerSettings, null, $"Greska: {ex.Message}", null, false, true);

            }
            finally
            {
                serverSocket.Close();
            }
        }
        public async Task HandleClientAsyncAdvance(Socket clientSocket)
        {
            try
            {
                using (NetworkStream networkStream = new NetworkStream(clientSocket))
                using (BinaryReader reader = new BinaryReader(networkStream))
                using (BinaryWriter writer = new BinaryWriter(networkStream))
                {
                    string fileName = reader.ReadString();
                    long fileSize = reader.ReadInt64();
                    int hashLength = reader.ReadInt32();
                    byte[] expectedHash = reader.ReadBytes(hashLength);

                    UpdateStatus(lblServerStatus, $"Preuzimanje i provera fajla: {fileName} ({fileSize} bytes)");
                    globalFunctionalities.FillTheLog(rtbAppLog, null, rtbServerSettings, null, $"Preuzimanje i provera fajla: {fileName} ({fileSize} bytes)", null, false, true);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        byte[] buffer = new byte[4096];
                        long totalBytesReceived = 0;

                        while (totalBytesReceived < fileSize)
                        {
                            int bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length);
                            if (bytesRead == 0) break;

                            await memoryStream.WriteAsync(buffer, 0, bytesRead);
                            totalBytesReceived += bytesRead;
                        }

                        if (totalBytesReceived != fileSize)
                        {
                            UpdateStatus(lblServerStatus, "Greska: velicina primljenog fajla ne odgovara ocekivanoj");
                            writer.Write("Fajl nije uspesno preuzet: neodgovarajuća velicina");
                            globalFunctionalities.FillTheLog(rtbAppLog, null, rtbServerSettings, null, $"Greska: velicina primljenog fajla: {fileName} ne odgovara ocekivanoj", null, false, true);
                            return;
                        }

                        byte[] receivedData = memoryStream.ToArray();
                        byte[] generatedHash = sha1.GenerateHash(receivedData);

                        if (!generatedHash.SequenceEqual(expectedHash))
                        {
                            UpdateStatus(lblServerStatus, "Greska: hash vrednosti se ne poklapaju");
                            writer.Write("Fajl nije uspesno preuzet: hash vrednosti se ne poklapaju");
                            globalFunctionalities.FillTheLog(rtbAppLog, null, rtbServerSettings, null, $"Greska: Fajl {fileName} nije uspesno preuzet: hash vrednosti se ne poklapaju", null, false, true);
                            return;
                        }

                        string savePath = Path.Combine(Directory.GetCurrentDirectory(), "Received_" + fileName);
                        File.WriteAllBytes(savePath, receivedData);

                        UpdateStatus(lblServerStatus, $"Fajl {fileName} uspesno preuzet i verifikovan");
                        writer.Write("Fajl je uspesno preuzet i verifikovan");
                        globalFunctionalities.FillTheLog(rtbAppLog, null, rtbServerSettings, null, $"Fajl {fileName} uspesno preuzet i verifikovan", null, false, true);
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateStatus(lblServerStatus, $"Greska: {ex.Message} - HandleClientAsyncAdvance funkcija");
                globalFunctionalities.FillTheLog(rtbAppLog, null, rtbServerSettings, null, $"Greska pri radu sa klijentom: {ex.Message}", null, false, true);

            }
            finally
            {
                clientSocket.Close();
            }
        }
        public void UpdateStatus(Label statusLabel, string message)
        {
            try
            {
                if (uiControl.InvokeRequired)
                {
                    uiControl.Invoke(new Action(() => statusLabel.Text = message));
                }
                else
                {
                    statusLabel.Text = message;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Greska: {ex.Message} - UpdateStatus funkcija");
            }
        }
    }
}