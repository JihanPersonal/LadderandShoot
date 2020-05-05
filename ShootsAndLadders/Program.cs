using System;
using System.Linq;
using System.Collections.Generic;
namespace ShootsAndLadders
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to shoots and ladders! How many players?");
                string input = Console.ReadLine();
                int numberOfPlayers = -1;
                bool valid = int.TryParse(input, out numberOfPlayers);
                if (!valid || numberOfPlayers < 1)
                {
                    Console.WriteLine("Please input a valid positive number");
                    Console.WriteLine("Would you like to try again? Y/N");
                    input = Console.ReadLine();
                    if (input.ToLower().StartsWith("n"))
                    {
                        return;
                    }
                    continue;
                }
                var game = new Game(numberOfPlayers);
                while (game.Winner == null)
                {
                    foreach (var player in game.Players)
                    {
                        player.Play(game);
                        if (game.Winner != null)
                            break;
                    }
                }
                var winner = game.Winner.GetNumber(); //= board.Squares.Last().Players.First().GetNumber();
                Console.WriteLine($"Player {winner} wins the game!");
                Console.WriteLine("Would you like to play again? Y/N");
                var playAgain = Console.ReadLine();
                if (playAgain.ToLower().StartsWith("n"))
                {
                    return;
                }
            }
        }
    }
}