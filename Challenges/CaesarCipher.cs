using CsharpChallenges.Utils;
using System;

namespace CsharpChallenges.Challenges
{
    internal class CaesarCipher
    {
        public CaesarCipher()
        {
        }

        internal void Run()
        {
            while (true)
            {
                string option = GetActionOption();

                switch (option)
                {
                    case "1":
                    case "2":
                        ProcessFile(option);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }

        private string GetActionOption()
        {
            Console.WriteLine("\nQual ação você deseja realizar?");
            Console.WriteLine("1 - cifrar");
            Console.WriteLine("2 - decifrar");
            Console.WriteLine("3 - voltar");
            string? option = Console.ReadLine();

            if (string.IsNullOrEmpty(option) || !IsValidOption(option))
            {
                Console.WriteLine("Opção inválida");
                return GetActionOption();
            }

            return option;
        }

        private static bool IsValidOption(string option)
        {
            return option == "1" || option == "2" || option == "3";
        }

        private static void ProcessFile(string option)
        {
            Console.WriteLine("Informe o caminho do arquivo");
            Console.WriteLine(@"Exemplo: C:\Users\User\Desktop\arquivo.txt");
            string? filePath = Console.ReadLine();

            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                Console.WriteLine("Arquivo não encontrado");
                return;
            }

            string text = FileUtils.ReadFile(filePath);

            Console.WriteLine("\nInforme a chave para cifrar/decifrar");
            if (!int.TryParse(Console.ReadLine(), out int key))
            {
                Console.WriteLine("Chave inválida");
                return;
            }

            string updatedFilePath = UpdateFilePath(filePath, option);
            string processedText = (option == "1") ? Cipher(text, key) : Decipher(text, key);
            FileUtils.WriteFile(updatedFilePath, processedText);
        }

        private static string UpdateFilePath(string filePath, string option)
        {
            string extension = (option == "1") ? "_cifrado.txt" : "_decifrado.txt";
            return filePath.Replace(".txt", extension);
        }

        private static string Cipher(string text, int key)
        {
            string encryptedText = "";

            foreach (char character in text)
            {
                int asciiValue = character;
                int encryptedValue = 0;

                if (IsUpperCase(asciiValue))
                {
                    encryptedValue = (asciiValue - 65 + key) % 26 + 65;
                }
                else if (IsLowerCase(asciiValue))
                {
                    encryptedValue = (asciiValue - 97 + key) % 26 + 97;
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

        private static string Decipher(string text, int key)
        {
            string decryptedText = "";

            foreach (char character in text)
            {
                int asciiValue = character;
                int decryptedValue = 0;

                if (IsUpperCase(asciiValue))
                {
                    decryptedValue = (asciiValue - 65 - key + 26) % 26 + 65;
                }
                else if (IsLowerCase(asciiValue))
                {
                    decryptedValue = (asciiValue - 97 - key + 26) % 26 + 97;
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

        private static bool IsUpperCase(int ascii)
        {
            return ascii is >= 65 and <= 91;
        }

        private static bool IsLowerCase(int ascii)
        {
            return ascii is >= 97 and <= 122;
        }
    }
}
