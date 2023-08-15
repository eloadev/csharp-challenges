using System.Text;

namespace CsharpChallenges.Challenges.Base64
{
    internal class Processing
    {
        const string Base64Table = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
        static List<string> Base64TableList = Base64Table.Select(c => c.ToString()).ToList();

        public static string Encode(string text)
        {
            string encodedText = "";

            string binaryText = ConvertToBinary(text);

            List<string> dividedBinary = DivideString(binaryText, 6).ToList();

            if (dividedBinary.Last().Length < 6)
            {
                int last = dividedBinary.Count - 1;
                dividedBinary[last] = dividedBinary[last].PadRight(6, '0');
            }

            List<string> base64List = new();
            foreach (string binary in dividedBinary)
            {
                string eigthBitsBinaryList = binary.PadLeft(8, '0');
                int decimalValue = Convert.ToInt32(eigthBitsBinaryList, 2);
                base64List.Add(Base64TableList[decimalValue]);
            }

            while ((base64List.Count % 4) != 0)
            {
                base64List.Add("=");
            }

            Console.WriteLine(string.Join("", base64List));

            return encodedText;
        }

        public static string Decode(string text)
        {
            string decodedText = "";

            List<string> binary6BitsList = new();
            foreach(char c in text)
            {
                int decimalValue = Base64TableList.FindIndex(cList => cList == c.ToString());
                string binaryValue = Convert.ToString(decimalValue, 2);
                string binary6Bits = binaryValue.PadLeft(6, '0');
                binary6BitsList.Add(binary6Bits);
            }

            string binaryText = string.Join("", binary6BitsList);
            List<string> binarioDividido = DivideString(binaryText, 8).ToList();

            foreach (string binary in binarioDividido)
            {
                byte[] binaryInBytes = GetBytesFromBinaryString(binary);
                string decodedBinary = Encoding.ASCII.GetString(binaryInBytes);
                decodedText += decodedBinary;
            }

            return decodedText;
        }

        private static string ConvertToBinary(string text)
        {
            string binaryText = "";

            foreach (char c in text)
            {
                binaryText += Convert.ToString((byte)c, 2).PadLeft(8, '0');
            }

            return binaryText;
        }

        static IEnumerable<string> DivideString(string str, int maxChunkSize)
        {
            for (int i = 0; i < str.Length; i += maxChunkSize)
                yield return str.Substring(i, Math.Min(maxChunkSize, str.Length - i));
        }

        public static byte[] GetBytesFromBinaryString(string binary)
        {
            var list = new List<byte>();

            for (int i = 0; i < binary.Length; i += 8)
            {
                string t = binary.Substring(i, 8);

                list.Add(Convert.ToByte(t, 2));
            }

            return list.ToArray();
        }
    }
}
