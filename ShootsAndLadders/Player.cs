using System;
using System.Collections.Generic;
using System.Text;

namespace ShootsAndLadders
{
    public class Player
    {
        private int Number;
        private Random Random;

        public int GetNumber()
        {
            return Number;
        }

        public void SetNumber(int value)
        {
            Number = value;
        }

        public int Move()
        {
            if (Random == null) {
                Random = new Random(Number);
            }
            var spaces = Random.Next(0, 6);
            Console.WriteLine($"Player {GetNumber()} spun a {spaces}.");
            return spaces;
        }
    }
}
