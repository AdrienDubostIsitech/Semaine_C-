using System;
using ConsoleGameApp.library;

namespace ConsoleGameApp
{
    class Program
    {
        static bool isRunnning = true;


        public static char InputKeyboard()
        {
            String input = Console.ReadLine();
            input = input.ToUpper(); 
            return input[0]; 
        }

        public static void LaunchGame()
        {
            Console.Clear();
            Console.WriteLine("StartGame");
            PlayerAction action = new PlayerAction(); 
            Field field = new Field(9, 9);
            bool isCurrentGame = true; 
            while(isCurrentGame)
            {
                field.DisplayField(Utils.alphabet);
                isCurrentGame =  field.MakeActionToCase(field.ChooseCase(action.SelectCase())); 
            }
        }

        public static void menuFunction()
        {
            Console.WriteLine("################ Bienvenue au Démineur ###########################");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Appuyez sur A pour commencer le jeu");
            Console.WriteLine("Appuyez sur H pour de l'aide");
            Console.WriteLine("Appuyez sur Q pour quitter le jeu");
            char inputvalue = InputKeyboard();
            switch (inputvalue)
            {
                case 'A':
                    LaunchGame(); 
                    break;
                case 'H':
                    Console.Clear();
                    Console.WriteLine("Voici l'explication du jeu");
                    isRunnning = false;
                    break;
                case 'Q':
                    Console.Clear();
                    Console.WriteLine(" Merci d'avoir joué ! Bonne journée ! ");
                    isRunnning = false;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("la commande n'est pas autorisé ! Veuillez réessayez");
                    break;
            }
        }

        public static void Main(string[] args)
        {
            while(isRunnning)
            {
                menuFunction(); 
            }
        }
    }
}
