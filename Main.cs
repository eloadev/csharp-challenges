using CsharpChallenges.Challenges.CaesarCipher;
using CsharpChallenges.Challenges.Base64;

namespace CsharpChallenges
{
    class MainClass
    {
        static void Main()
        {
            Console.WriteLine("-------- Bem-vindo(a) --------");

            while (true)
            {
                Console.WriteLine("Escolha a aplicação a ser executada:  ");
                Console.WriteLine("1 - Cifrar e decifrar arquivos utilizando Cifra de César");
                Console.WriteLine("2 - Codificar e decodificar arquivos utilizando Base64");
                Console.WriteLine("3 - Fechar programa");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("----- Cifra de César -----");
                        new CaesarCipher().Run();
                        break;
                    case "2":
                        Console.WriteLine("----- Base64 -----");
                        new Base64().Run();
                        break;
                    case "3":
                        Console.WriteLine("----- Fechando programa -----");
                        return;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
            
        }
    }
}