namespace Encryption_Exchange_App.EncryptionDecryption_Algorithms
{
    public class SHA_1
    {
        public static uint LeftRotate(uint value, int bits)
        {
            return (value << bits) | (value >> (32 - bits));
        }
        public static byte[] GetBytesBigEndian(uint value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }
            return bytes;
        }
        public byte[] GenerateHash(byte[] input)
        {
            #region Promenljive stanja

            uint h0 = 0x67452301;
            uint h1 = 0xEFCDAB89;
            uint h2 = 0x98BADCFE;
            uint h3 = 0x10325476;
            uint h4 = 0xC3D2E1F0;

            #endregion

            #region Preprocesiranje

            ulong originalInputLength = (ulong)input.Length * 8; //Originalna duzina inputa u bitovima
            List<byte> extendedInput = new List<byte>(input);
            extendedInput.Add(0x80);

            byte[] byteArray = extendedInput.ToArray();
            while ((extendedInput.Count * 8) % 512 != 448)
                extendedInput.Add(0x00);

            byte[] lengthBytes = BitConverter.GetBytes(originalInputLength);

            // Ako je sistem little-endian, obrcem ga u Big-Endian
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(lengthBytes);
            }

            // Dodajte bajtove u listu
            extendedInput.AddRange(lengthBytes);

            #endregion

            #region Obrada svakog 512-bitnog bloka

            byteArray = extendedInput.ToArray();

            //Delim na 512-bitne blokove, odnosno, 64-bajtne blokove (64 * 8 = 512)
            for (int i = 0; i < byteArray.Length; i += 64)
            {
                uint[] w = new uint[80];
                //Delim na 16 32-bitnih reci
                for (int j = 0; j < 16; j++)
                {
                    int index = i + j * 4;  // i - pocetni indeks u trenutnom 512-bitnom bloku, j * 4 pomera indeks za 4 bajta na svaku sledecu rec, 4*8=3
                    //Izdvajamo 32-bitnu rec tako sto kompletanu 512-bitnu rec pomeramo ulevo za odredjeni
                    //broj bitova da bi dosli do zeljenog bajta.
                    w[j] = ((uint)byteArray[index] << 24) | ((uint)byteArray[index + 1] << 16)
                        | ((uint)byteArray[index + 2] << 8) | (uint)byteArray[index + 3];
                }

                //Prosirenje na 80 reci
                for (int j = 16; j < 80; j++)
                {
                    w[j] = LeftRotate(w[j - 3] ^ w[j - 8] ^ w[j - 14] ^ w[j - 16], 1);
                }

                // Inicijalizacija pet radnih promenljivih
                uint a = h0;
                uint b = h1;
                uint c = h2;
                uint d = h3;
                uint e = h4;

                //Runde
                for (int j = 0; j < 80; j++)
                {
                    uint f, k;
                    if (j < 20)
                    {
                        f = (uint)((b & c) | ((-b) & d));
                        k = 0x5A827999;
                    }
                    else if (j >= 20 && j < 40)
                    {
                        f = (uint)b ^ c ^ d;
                        k = 0x6ED9EBA1;
                    }
                    else if (j >= 40 && j < 60)
                    {
                        f = (uint)(b & c) | (b & d) | (c & d);
                        k = 0x8F1BBCDC;
                    }
                    else
                    {
                        f = (uint)b ^ c ^ d;
                        k = 0xCA62C1D6;
                    }

                    //Preracunavanje promenljivvih stanja
                    uint temp = LeftRotate(a, 5) + f + e + k + w[j];
                    e = d;
                    d = c;
                    c = LeftRotate(b, 30);
                    b = a;
                    a = temp;
                }

                //Dodavanje rezultata u inicijalizacnione promenljive
                h0 += a;
                h1 += b;
                h2 += c;
                h3 += d;
                h4 += e;
            }

            //Kreiranje hash-a
            byte[] hash = new byte[20];
            Array.Copy(GetBytesBigEndian(h0), 0, hash, 0, 4);
            Array.Copy(GetBytesBigEndian(h1), 0, hash, 4, 4);
            Array.Copy(GetBytesBigEndian(h2), 0, hash, 8, 4);
            Array.Copy(GetBytesBigEndian(h3), 0, hash, 12, 4);
            Array.Copy(GetBytesBigEndian(h4), 0, hash, 16, 4);

            #endregion

            return hash;
        }
    }
}