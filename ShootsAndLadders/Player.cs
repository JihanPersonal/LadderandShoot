using System;
using System.Collections.Generic;
using System.Text;

namespace ShootsAndLadders
{
    public class Player
    {
        private int Number;
        //private Random Random;

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
            // if (Random == null)
            // {
            //Random = new Random(Number);
            //}
            var spaces = random.Next(1, 7);
            Console.WriteLine($"Player {GetNumber()} spun a {spaces}.");
            return spaces;
        }
    }
}
