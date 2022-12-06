using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameApp.library
{
    public enum CaseType
    {
        Bomb = 'B',
        None = 'N'
    }
    public enum stateEnum
    {
        Open = 'O',
        Close = 'X',
        Flag = 'F'
    }

    class Case
    {
        public int xValue { get; set; }
        public int yValue { get; set; }
        public CaseType Type { get; set; }
        public stateEnum State { get; set; }
        public int bombNear { get; set; } 

        public Case(CaseType type, stateEnum state, int x, int y)
        {
            this.xValue = x;
            this.yValue = y; 
            this.Type = type;
            this.State = state; 
        }
    }
}
