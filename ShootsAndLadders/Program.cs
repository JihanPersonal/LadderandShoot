using System;
using System.Linq;
using System.Collections.Generic;
namespace ShootsAndLadders
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            while (true)
            {
                Console.WriteLine("Welcome to shoots and ladders! How many players?");
                string numberOfPlayers = Console.ReadLine();

                // int num = int.Parse(numberOfPlayers);
                // List<int> res = new List<int>();
                // while (num > 0)
                // {
                //     num--;
                //     res.Add(random.Next(1, 7));
                // }
                // Console.WriteLine("Folowwing is the result: *********************");
                // res.ForEach(i => Console.WriteLine(i));

                var board = new Board(int.Parse(numberOfPlayers));
                while (!board.Squares.Last().Players.Any())
                {
                    foreach (var player in board.Players)
                    {
                        var currentSquare = board.Squares.Single(x => x.Players.Any(y => y.GetNumber() == player.GetNumber()));
                        var currentSquareIndex = board.Squares.IndexOf(currentSquare);
                        var move = player.Move(random);
                        var newSquare = currentSquareIndex + move;
                        if (newSquare >= board.Squares.Count())
                        {
                            newSquare = currentSquareIndex;
                        }
                        currentSquare.Players.Remove(player);
                        Console.WriteLine($"Player {player.GetNumber()} moved to square {newSquare}.");
                        if (board.Squares[newSquare].LadderTo.HasValue)
                        {
                            newSquare = board.Squares[newSquare].LadderTo.GetValueOrDefault();
                            Console.WriteLine($"You took a ladder to {newSquare}!");
                        }
                        if (board.Squares[newSquare].ShootTo.HasValue)
                        {
                            newSquare = board.Squares[newSquare].ShootTo.GetValueOrDefault();
                            Console.WriteLine($"You took a ladder to {newSquare}!");
                        }
                        board.Squares[newSquare].Players.Add(player);
                    }
                }
                var winner = board.Squares.Last().Players.First().GetNumber();
                Console.WriteLine($"Play {winner} wins the game!");
                Console.WriteLine("Would you like to play again? Y/n");
                var playAgain = Console.ReadLine();
                if (playAgain.StartsWith("N"))
                {
                    return;
                }
            }
        }
    }
}