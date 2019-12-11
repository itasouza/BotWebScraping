using System;

namespace BotInstagram
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Informe o número do perfil do Instagram");
            string nomeDoPerfil = Console.ReadLine();

            if (string.IsNullOrEmpty(nomeDoPerfil))
            {
                nomeDoPerfil = "i.love.code";
            }

            Profile profile = Instagram.GetProfileByUser(nomeDoPerfil);
            Console.WriteLine($"UserName = {profile.UserName }");

            Console.ReadKey();
        }
    }
}
