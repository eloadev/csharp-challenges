using CsharpChallenges.Utils;

namespace CsharpChallenges.Challenges.CaesarCipher
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
            string processedText = option == "1" ? Processing.Cipher(text, key) : Processing.Decipher(text, key);
            FileUtils.WriteFile(updatedFilePath, processedText);
        }

        private static string UpdateFilePath(string filePath, string option)
        {
            string extension = option == "1" ? "_cifrado.txt" : "_decifrado.txt";
            return filePath.Replace(".txt", extension);
        }
    }
}
