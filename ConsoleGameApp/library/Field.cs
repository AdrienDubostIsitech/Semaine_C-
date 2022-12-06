using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameApp.library
{
    class Field
    {
        public Case[,] fieldCase;
        public int xDimensions { get; set; }
        public int yDimensions { get; set; }

        public Field(int xDimensions, int yDimensions)
        { 
            this.xDimensions = xDimensions;
            this.yDimensions = yDimensions;
            this.fieldCase = new Case[yDimensions, xDimensions]; 
            for (int i = 0; i < yDimensions; i++)
            {
                for (int j = 0; j < xDimensions; j++) { 

                    Random rnd = new Random();
                    int BombOrNot = rnd.Next(1, 6);
                    if(BombOrNot <= 4)
                    {
                        this.fieldCase[i, j] = new Case(CaseType.None, stateEnum.Close, j, i);
                    } else
                    {
                        this.fieldCase[i, j] = new Case(CaseType.Bomb, stateEnum.Close, j, i);
                    }
                }
            }
        }
        
        public void DisplayField(String alphabet)
        {
            Console.Clear();
            for (int i = 0; i < yDimensions; i++)
            {
                Console.Write($" [{alphabet[i]}] "); 
            }
            Console.WriteLine("");
            for (int i = 0; i < yDimensions; i++)
            {
                Console.WriteLine("");
                for (int j = 0; j < xDimensions; j++)
                {
                    Console.Write($" [{this.fieldCase[i, j].State}] "); 
                }
               
                Console.Write($" {i + 1} ");
            }
        }

        public Case ChooseCase(string selectedCase)
        {
            int xDim;
            int yDim;
            if(Utils.alphabet.Contains(selectedCase[0]))
            {
                xDim = Utils.alphabet.IndexOf(selectedCase[0]); 
            }
            else
            {
                return null; 
            }
            yDim = Int32.Parse(selectedCase[0].ToString());
            if(yDim -1 > this.yDimensions)
            {
                return null; 
            }
            return this.fieldCase[yDim, xDim]; 
        }

        public void MakeActionToCase(Case selectedcase)
        {
            Console.WriteLine(" Choisissez une action à effectuer : ");
            Console.WriteLine(" Appuyez sur O sur pour ouvrir la case ");
            Console.WriteLine(" Appuyez sur F sur pour marquer la case ");
            string response = Console.ReadLine();
            response = response.ToUpper();
            char charAction = response[0]; 
            switch (charAction)
            {
                case 'O':
                    selectedcase.State = stateEnum.Open;
                    break;
                case 'F':
                    selectedcase.State = stateEnum.Flag;
                    break; 
                default:
                    Console.WriteLine("Action incorrecte veuillez recommencer"); 
                    break; 
            }
        }
    }
}
