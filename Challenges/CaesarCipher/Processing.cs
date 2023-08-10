namespace CsharpChallenges.Challenges.CaesarCipher                                        
{
    internal class Processing
    {
        const int firstUpperAscii = 65;
        const int lastUpperAscii = 91;
        const int firstLowerAscii = 97;
        const int lastLowerAscii = 122;

        const int alphabetSize = 26;

        public static string Cipher(string text, int key)   
        {
            string encryptedText = "";

            foreach (char character in text)
            {
                int asciiValue = character;
                int encryptedValue = 0;

                if (IsUpperCase(asciiValue))
                {
                    encryptedValue = (asciiValue - firstUpperAscii + key) % alphabetSize + firstUpperAscii;
                }
                else if (IsLowerCase(asciiValue))
                {
                    encryptedValue = (asciiValue - firstLowerAscii + key) % alphabetSize + firstLowerAscii;
                }
                else
                {
                    encryptedValue = character;
                }

                char encryptedChar = (char)encryptedValue;
                encryptedText += encryptedChar;
            }


            return encryptedText;
        }

        public static string Decipher(string text, int key)
        {
            string decryptedText = "";

            foreach (char character in text)
            {
                int asciiValue = character;
                int decryptedValue = 0;

                if (IsUpperCase(asciiValue))
                {
                    decryptedValue = (asciiValue - firstUpperAscii - key + alphabetSize)
                        % alphabetSize + firstLowerAscii;
                }
                else if (IsLowerCase(asciiValue))
                {
                    decryptedValue = (asciiValue - firstLowerAscii - key + alphabetSize)
                        % alphabetSize + firstLowerAscii;
                }
                else
                {
                    decryptedValue = character;
                }

                char decryptedChar = (char)decryptedValue;
                decryptedText += decryptedChar;
            }

            return decryptedText;
        }

        public static bool IsUpperCase(int ascii)
        {
            return ascii is >= firstUpperAscii and <= lastUpperAscii;
        }

        public static bool IsLowerCase(int ascii)
        {
            return ascii is >= firstLowerAscii and <= lastLowerAscii;
        }
    }
}
