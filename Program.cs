/*
 * Author: João Nuno Carvalho
 * Date:   2021.01.01
 * Description: A very simple game of Tic Tac Toe in C# programming language.
 * License: MIT Open Source License.
 */

using System;

namespace TicTacToe
{
    public enum Symbols
    {
        None = 0,
        X    = 1,
        O    = 2
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the game Tic Tac Toe...");
            Random rnd = new Random();
            string option;
            do
            {
                // Start game
                Console.WriteLine("Name of player A?");
                string namePlayerA = Console.ReadLine();
                Console.WriteLine("Name of player B?");
                string namePlayerB = Console.ReadLine();
                // Player A
                bool flagFirst = rnd.Next(2) == 0 ? true : false ; 
                Player playerA = new Player(namePlayerA, flagFirst);
                // Player B
                flagFirst = !flagFirst;
                Player playerB = new Player(namePlayerB, flagFirst);
                Board board = new Board(playerA, playerB);
                board.startGame();

                Console.WriteLine("\nPress \"C\" to play another game?");
                option = Console.ReadLine();
            } while ( option.Trim().ToUpper() == "C");
            Console.WriteLine("...End and have a nice day!");
        }
    }
}
