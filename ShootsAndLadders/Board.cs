using System;
using System.Collections.Generic;
using System.Text;
namespace ShootsAndLadders
{
    public sealed class Board
    {
        public List<Square> Squares { get; set; }
        public Random Dice { get; }
        private static Board board;

        public int MaxSize;
        public static Board GetBoard()
        {
            if (board == null)
                board = new Board();
            return board;
        }
        public int RollDice()
        {
            return Dice.Next(1, 7);
        }
        private Board(int size = 100)
        {
            Dice = new Random();
            Squares = new List<Square>();
            MaxSize = size;
            for (var j = 0; j <= MaxSize; j++)
            {
                var newSquare = new Square();
                Squares.Add(newSquare);
                if (j == 10)
                {
                    newSquare.LadderTo = 18;
                }
                else if (j == 20)
                {
                    newSquare.ShootTo = 14;
                }
                else if (j == 24)
                {
                    newSquare.LadderTo = 35;
                }
                else if (j == 30)
                {
                    newSquare.LadderTo = 40;
                }
                else if (j == 32)
                {
                    newSquare.ShootTo = 15;
                }
                else if (j == 41)
                {
                    newSquare.LadderTo = 57;
                }
                else if (j == 45)
                {
                    newSquare.LadderTo = 55;
                }
                else if (j == 48)
                {
                    newSquare.LadderTo = 60;
                }
                else if (j == 50)
                {
                    newSquare.ShootTo = 25;
                }
                else if (j == 51)
                {
                    newSquare.ShootTo = 64;
                }
                else if (j == 61)
                {
                    newSquare.ShootTo = 43;
                }
                else if (j == 63)
                {
                    newSquare.LadderTo = 70;
                }
                else if (j == 78)
                {
                    newSquare.ShootTo = 65;
                }
                else if (j == 80)
                {
                    newSquare.LadderTo = 100;
                }
                else if (j == 48)
                {
                    newSquare.LadderTo = 53;
                }
            }
        }
    }
}
