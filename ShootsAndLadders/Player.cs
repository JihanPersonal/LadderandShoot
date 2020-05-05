using System;
using System.Collections.Generic;
using System.Text;

namespace ShootsAndLadders
{
    public class Player
    {
        public Player()
        {
            currentPostion = 0;
        }
        private int currentPostion;
        public int CurrentPostion
        {
            get
            {
                return currentPostion;
            }
            set
            {
                currentPostion = value;
            }
        }
        private int Number;

        public int GetNumber()
        {
            return Number;
        }

        public void SetNumber(int value)
        {
            Number = value;
        }

        public int Move(Random random)
        {
            var spaces = random.Next(1, 7);
            Console.WriteLine($"Player {GetNumber()} spun a {spaces}.");
            return spaces;
        }
    }
}
