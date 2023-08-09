namespace CsharpChallenges
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------- Bem-vindo(a) --------");
            Console.WriteLine("Escolha a aplicação a ser executada:  ");
            Console.WriteLine("1 - Criptografia e descriptografia de arquivos utilizando Cifra de César");
            Console.WriteLine("2 - ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("----- Cifra de César -----");
                    CaesarCipher caesarCipher = new CaesarCipher();
                    caesarCipher.Run();
                    break;
                case "2":
                    Console.WriteLine("----- xxx -----");
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }
    }
}