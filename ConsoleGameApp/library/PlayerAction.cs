using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameApp.library
{
    class PlayerAction
    {
        public PlayerAction()
        {

        }

        public string SelectCase()
        {
            Console.WriteLine(""); 
            Console.WriteLine("Choisissez sur quel case vous voulez agir : ");
            string inputCasePosition = Console.ReadLine();
            if(inputCasePosition.Length > 2 || inputCasePosition.Length < 2)
            {
                SelectCase(); 
            }
            else
            {
                inputCasePosition = inputCasePosition.ToUpper(); 
            }
            return inputCasePosition; 
        }
    }
}
