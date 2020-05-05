using System;
using System.Linq;
using System.Collections.Generic;
namespace ShootsAndLadders
{
    class Program
    {
        static void Main(string[] args)
        {
            var dice = new Random();
            while (true)
            {
                Console.WriteLine("Welcome to shoots and ladders! How many players?");
                string numberOfPlayers = Console.ReadLine();

                var board = new Board(int.Parse(numberOfPlayers), dice);
                while (board.GameStatus == Status.Undergoing)
                {
                    foreach (var player in board.Players)
                    {
                        var currentSquare = player.CurrentPostion;
                        var move = player.Move(board.Dice);
                        var newSquare = currentSquare + move;
                        if (newSquare >= board.Squares.Count())
                        {
                            newSquare = currentSquare;
                        }
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
                        player.CurrentPostion = newSquare;
                        if (player.CurrentPostion == 100)
                        {
                            board.GameStatus = Status.Win;
                            break;
                        }
                    }
                }
                var winner = board.Players.First(p => p.CurrentPostion == 100).GetNumber(); //= board.Squares.Last().Players.First().GetNumber();
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