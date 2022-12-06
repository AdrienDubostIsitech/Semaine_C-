using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics; 
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft; 

namespace ConsoleGameApp.library
{
    class Field
    {
        public Case[,] fieldCase;
        public int XDimensions { get; set; }
        public int YDimensions { get; set; }
        public int countOpenCase { get; set; }
        public int NonBombCase { get; set; }
        public Stopwatch timer { get; set; }

        public Field(int xDimensions, int yDimensions)
        {
            this.countOpenCase = 0;
            this.NonBombCase = 0;
            this.timer = new Stopwatch(); 
            this.XDimensions = xDimensions;
            this.YDimensions = yDimensions;
            this.fieldCase = new Case[yDimensions, xDimensions]; 
            for (int i = 0; i < yDimensions; i++)
            {
                for (int j = 0; j < xDimensions; j++) { 

                    Random rnd = new Random();
                    int BombOrNot = rnd.Next(1, 6);
                    if(BombOrNot <= 6)
                    {
                        this.fieldCase[i, j] = new Case(CaseType.None, stateEnum.Close, j, i);
                        NonBombCase += 1; 
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
            for (int i = 0; i < YDimensions; i++)
            {
                Console.Write($" [{alphabet[i]}] "); 
            }
            Console.WriteLine("");
            for (int i = 0; i < YDimensions; i++)
            {
                Console.WriteLine("");
                for (int j = 0; j < XDimensions; j++)
                {
                    if(this.fieldCase[i, j].State == stateEnum.Open)
                    {
                        Console.Write($" [{this.fieldCase[i, j].bombNear}] ");
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
            if(yDim -1 > this.YDimensions)
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
                    this.countOpenCase += 1; 
                    return saveCheck(selectedcase); 
                case 'F':
                    selectedcase.State = stateEnum.Flag;
                    return true; 
                default:
                    Console.WriteLine("Action incorrecte veuillez recommencer");
                    return true; 
            }
        }

        public bool saveCheck(Case selectedcase)
        {
            if(selectedcase.Type == CaseType.Bomb)
            {
                EndGame(false); 
                return false;
            }
            CheckNearBomb(selectedcase.xValue, selectedcase.yValue);
            if(this.countOpenCase == this.NonBombCase)
            {
                EndGame(true);
                return false; 
            }
            return true; 
        }

        public void EndGame(bool resultGame)
        {
            if(resultGame == false)
            {
                Console.WriteLine(" Vous avez perdu ! Pas de chance ! Une autre partie ? "); 
            }
            else
            {
                Console.WriteLine(" Vous avez gagné !  Felicitations ! ");
                this.timer.Stop();
                double score = Math.Round(this.timer.Elapsed.TotalSeconds);
                HighScore objectscore = NewHighScore(score);
                ManageHighScore(objectscore); 
                Console.WriteLine($" Vous avez mis : {score} secondes"); 
            }
        }

        public void CheckNearBomb(int xDim, int yDim)
        {
            
            int count = 0;
            if (xDim >= 1)
            {
                if (this.fieldCase[yDim, xDim - 1].Type == CaseType.Bomb)
                {
                    count += 1; 
                }
            }
            if(xDim < this.XDimensions -1)
            {
                if (this.fieldCase[yDim, xDim + 1].Type == CaseType.Bomb)
                {
                    count += 1;
                }
            }
            if (yDim >= 1)
            {
                if (this.fieldCase[yDim -1, xDim].Type == CaseType.Bomb)
                {
                    count += 1;
                }
            }
            if (yDim < this.XDimensions -1)
            {
                if (this.fieldCase[yDim + 1, xDim].Type == CaseType.Bomb)
                {
                    count += 1;
                }
            }

            this.fieldCase[yDim, xDim].bombNear = count; 

            if (count == 0)
            {
                if (xDim >= 1)
                {
                    if (this.fieldCase[yDim, xDim - 1].Type != CaseType.Bomb && this.fieldCase[yDim, xDim - 1].State != stateEnum.Open)
                    {
                        this.fieldCase[yDim, xDim - 1].State = stateEnum.Open;
                        this.countOpenCase += 1; 
                        CheckNearBomb(xDim - 1, yDim);
                        
                    }
                }
                if (xDim < this.XDimensions - 1)
                {
                    if (this.fieldCase[yDim, xDim + 1].Type != CaseType.Bomb && this.fieldCase[yDim, xDim + 1].State != stateEnum.Open)
                    {
                        this.fieldCase[yDim, xDim + 1].State = stateEnum.Open;
                        this.countOpenCase += 1;
                        CheckNearBomb(xDim + 1, yDim);
                       
                    }
                }
                if (yDim >= 1)
                {
                    if (this.fieldCase[yDim - 1, xDim].Type != CaseType.Bomb && this.fieldCase[yDim - 1, xDim].State != stateEnum.Open)
                    {
                        this.fieldCase[yDim - 1, xDim].State = stateEnum.Open;
                        this.countOpenCase += 1;
                        CheckNearBomb(xDim, yDim -1);
                        
                    }
                }
                if (yDim < this.XDimensions - 1)
                {
                    if (this.fieldCase[yDim + 1, xDim].Type != CaseType.Bomb && this.fieldCase[yDim + 1, xDim].State != stateEnum.Open)
                    {
                        this.fieldCase[yDim + 1, xDim].State = stateEnum.Open;
                        this.countOpenCase += 1;
                        CheckNearBomb(xDim, yDim + 1);
                        
                    }
                }
            } 
        }

        public void ManageHighScore(HighScore newScore)
        {
            StreamReader reader = new StreamReader("HighScore.json");
            string jsonString = reader.ReadToEnd();
            List<HighScore> highscores = JsonConvert.DeserializeObject<List<HighScore>>(jsonString);
            highscores.Add(newScore);
            reader.Close(); 
            IEnumerable<HighScore> query = from highscore in highscores
                                           orderby highscore.score
                                           select highscore;
            string jsonArray = JsonConvert.SerializeObject(query.ToArray());
            System.IO.File.WriteAllText("HighScore.json", jsonArray); 
        }

        public HighScore NewHighScore(double score)
        {
            HighScore newscore = new HighScore(score);
            return newscore; 
        }

    }
}
