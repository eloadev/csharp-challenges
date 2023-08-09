using System;

namespace CsharpChallenges
{
    internal class CaesarCipher
    {
        IEnumerable<int> uppercaseRange = Enumerable.Range(65, 91);
        IEnumerable<int> lowercaseRange = Enumerable.Range(97, 122);

        public CaesarCipher()
        {
        }

        internal void Run()
        {
            Console.WriteLine("Informe o caminho do arquivo");
            Console.WriteLine("Exemplo: C:\\Users\\User\\Desktop\\arquivo.txt");
            string? filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Arquivo não encontrado");
                Run();
            }

            Console.WriteLine("\nQual ação você deseja realizar?");
            Console.WriteLine("1 - criptografar");
            Console.WriteLine("2 - descriptografar");
            string? option = Console.ReadLine();

            Console.WriteLine("\nInforme a chave de criptografia/descriptografia");
            int key = int.Parse(Console.ReadLine());

            string text = ReadFile(filePath);

            switch (option)
            {
                case "1":
                    Encrypt(text, key);
                    break;
                case "2":
                    Decrypt(text, key);
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }

        private string ReadFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        private string Encrypt(string text, int key)
        {
            string EncryptedText = "";

            foreach (char character in text){
                int asciiValue = (int)character;
                int encryptedValue = 0;
                
                if (IsUpperCase(asciiValue))
                {
                    encryptedValue = (asciiValue - 65 + key) % 26 + 65;
                }
                else if (IsLowerCase(asciiValue))
                {
                    encryptedValue = (asciiValue - 97 + key) % 26 + 97;
                }
                else {
                    encryptedValue = character;
                }

                char encryptedChar = (char)encryptedValue;
                EncryptedText += encryptedChar;
            }
                
            
            return EncryptedText;
        }

        private string Decrypt(string text, int key)
        {
            string DecryptedText = "";
            return DecryptedText;
        }

        private bool IsUpperCase(int ascii)
        {
            return ascii is >= 65 and <= 91;
        }
        private bool IsLowerCase(int ascii)
        {
            return ascii is >= 97 and <= 122;
        }

        private void CustomBaseCalculus(int number, int key)
        {

        }
    }
}
