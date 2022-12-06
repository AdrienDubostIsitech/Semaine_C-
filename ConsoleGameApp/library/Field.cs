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
                    if(this.fieldCase[i, j].State == stateEnum.Open)
                    {
                        Console.Write($" [{CheckNearBomb(j, i)}] ");
                    }
                    else
                    {
                        Console.Write($" [{((char)this.fieldCase[i, j].Type)}] ");
                    }
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
            yDim = Int32.Parse(selectedCase[1].ToString());
            if(yDim -1 > this.yDimensions)
            {
                return null; 
            }
            return this.fieldCase[yDim - 1, xDim]; 
        }

        public bool MakeActionToCase(Case selectedcase)
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
                    return saveCheck(selectedcase); 
                    break;
                case 'F':
                    selectedcase.State = stateEnum.Flag;
                    return true; 
                    break; 
                default:
                    Console.WriteLine("Action incorrecte veuillez recommencer");
                    return true; 
                    break; 
            }
        }

        public bool saveCheck(Case selectedcase)
        {
            if(selectedcase.Type == CaseType.Bomb)
            {
                return false; 
            }
            return true; 
        }

        public int CheckNearBomb(int xDim, int yDim)
        {
            int count = 0; 
            if(xDim > 1)
            {
                if (this.fieldCase[yDim, xDim - 1].Type == CaseType.Bomb)
                {
                    count += 1; 
                }
            }
            if(xDim < this.xDimensions)
            {
                if (this.fieldCase[yDim, xDim + 1].Type == CaseType.Bomb)
                {
                    count += 1;
                }
            }
            if (yDim > 1)
            {
                if (this.fieldCase[yDim -1, xDim].Type == CaseType.Bomb)
                {
                    count += 1;
                }
            }
            if (yDim < this.xDimensions)
            {
                if (this.fieldCase[yDim + 1, xDim].Type == CaseType.Bomb)
                {
                    count += 1;
                }
            }

            return count; 
        }
    }
}
