using System;
using System.Collections.Generic;
namespace ShootsAndLadders
{
    public class Game
    {
        //Players of this game
        public List<Player> Players;
        //Winner of this game 
        public Player Winner;
        //Board of this game
        private Board board;
        public Game(int numberOfPlayers)
        {
            Winner = null;
            board = Board.GetBoard();
            setPlayers(numberOfPlayers);
        }

        public void MovePlayer(Player player)
        {
            var spaces = board.RollDice();
            Console.WriteLine($"Player {player.GetNumber()} spun a {spaces}.");
            var newposition = player.CurrentPostion + spaces;
            if (newposition > board.MaxSize)
            {
                newposition = player.CurrentPostion;
            }
            Console.WriteLine($"Player {player.GetNumber()} moved to square {newposition}.");
            player.CurrentPostion = newposition;

            //Check whether need to take ladder or shoot
            TakeLadderorShoot(player);

            //Check whether the player win the game
            CheckWinning(player);
        }

        //Main logic to update players postion
        private void TakeLadderorShoot(Player player)
        {
            int currentposition = player.CurrentPostion;
            int newposition = currentposition;
            if (board.Squares[currentposition].LadderTo.HasValue)
            {
                newposition = board.Squares[currentposition].LadderTo.GetValueOrDefault();
                Console.WriteLine($"You took a ladder to {newposition}!");
            }
            if (board.Squares[currentposition].ShootTo.HasValue)
            {
                newposition = board.Squares[currentposition].ShootTo.GetValueOrDefault();
                Console.WriteLine($"You got Shoot to {newposition}!");
            }
            player.CurrentPostion = newposition;
        }

        //Check whether anyplay win the game
        private void CheckWinning(Player player)
        {
            if (player.CurrentPostion == board.MaxSize)
            {
                this.Winner = player;
            }
        }
        //Initialzie the game
        private void setPlayers(int numberOfPlayers)
        {
            Players = new List<Player>();
            for (int i = 1; i <= numberOfPlayers; i++)
            {
                var nextPlayer = new Player();
                nextPlayer.SetNumber(i);
                Players.Add(nextPlayer);
            }
        }

    }
}