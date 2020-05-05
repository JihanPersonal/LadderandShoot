using System;
using System.Collections.Generic;
using System.Text;

namespace ShootsAndLadders
{
    public class Board
    {
        public List<Square> Squares { get; set; }
        public List<Player> Players { get; set; }
        private Random random;
        public Board(int numberOfPlayers)
        {
            random = new Random();
            Players = new List<Player>();
            Squares = new List<Square>();
            //FIXED: Start at 1, Starting at Player 0 was bad.
            for (int i = 1; i <= numberOfPlayers; i++)
            {
                var nextPlayer = new Player();
                nextPlayer.SetNumber(i);
                Players.Add(nextPlayer);
            }

            for (var j = 0; j <= 100; j++)
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

            Squares[0].Players.AddRange(Players);
        }
    }
}
