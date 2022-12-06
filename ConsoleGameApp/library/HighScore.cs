using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameApp.library
{
    class HighScore
    {
        public double score { get; set; }

        public HighScore(double score)
        {
            this.score = score; 
        }
    }
}
