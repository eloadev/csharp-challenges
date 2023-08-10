using CsharpChallenges.Challenges.CaesarCipher;

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
                Console.WriteLine("3 - Fechar programa");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("----- Cifra de César -----");
                        new CaesarCipher().Run();
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