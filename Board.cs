/*
 * Author: João Nuno Carvalho
 * Date:   2021.01.01
 * Description: A very simple game of Tic Tac Toe in C# programming language.
 * License: MIT Open Source License.
 */

using System;

namespace TicTacToe
{
    public class Board
    {
        Player first;
        Player second;
        int[] board = {0,0,0, 0,0,0, 0,0,0};

        public Board(Player playerA, Player playerB)
        {
            first  = playerA.isFirstPlayer() ? playerA : playerB;
            second = playerA.isFirstPlayer() ? playerB : playerA;
        }

        public void startGame()
        {
            Player winner;
            bool flagDrow;

            DisplayState();
            while (true)
            {
                bool res;
                string pos;

                do
                {
                    Console.WriteLine("");
                    Console.WriteLine(first.AskMovePlayer());
                    pos = Console.ReadLine();
                    res = AddMove(first, pos);
                    if (!res)
                        Console.WriteLine("Invalid move!");
                } while (!res);
                DisplayState();
                if (IsFinished(out winner, out flagDrow))
                    break;

                do
                {
                    Console.WriteLine("");
                    Console.WriteLine(second.AskMovePlayer());
                    pos = Console.ReadLine();
                    res = AddMove(second, pos);
                    if (!res)
                        Console.WriteLine("Invalid move!");
                } while (!res);
                DisplayState();
                if (IsFinished(out winner, out flagDrow))
                    break;

            }

            Console.WriteLine("");
            if (winner != null)
            {
                Console.WriteLine("Congratulations the winner is {0}.", winner.getName());
            } else if (flagDrow)
            {
                Console.WriteLine("The game terminated with a tie.");
            }            
        }

        private void DisplayState()
        {
            string strOut = String.Format(
@"   1   2   3
  - - - - - -
A: {0} | {1} | {2}
  -----------
B: {3} | {4} | {5}
  -----------
C: {6} | {7} | {8}",
                cell(0),
                cell(1),
                cell(2),
                cell(3),
                cell(4),
                cell(5),
                cell(6),
                cell(7),
                cell(8)
                );
            Console.WriteLine(strOut);
        }

        private string cell(int pos)
        {
            switch (board[pos])
            {
                case 1:
                    return "X";
                case 2:
                    return "O";
                default:
                    return " ";
            }
        }

        private bool IsFinished(out Player winner, out bool flagDrow)
        {
            for (int val = 1; val <= 2; val++) {
                if    ((board[0] == val && board[1] == val && board[2] == val) // Horizontal
                    || (board[3] == val && board[4] == val && board[5] == val)
                    || (board[6] == val && board[7] == val && board[8] == val)

                    || (board[0] == val && board[3] == val && board[6] == val) // Vertical
                    || (board[1] == val && board[4] == val && board[7] == val)
                    || (board[2] == val && board[5] == val && board[8] == val)

                    || (board[0] == val && board[4] == val && board[8] == val)  // Crossed
                    || (board[2] == val && board[4] == val && board[6] == val))
                    {
                        winner = val == 1 ? first : second;
                        flagDrow = false;
                        return true;
                    }
            }
            foreach(int value in board){
                if (value == 0)
                {
                    flagDrow = false;
                    winner = null;
                    return false;
                } 
            }
            flagDrow = true;
            winner = null;
            return true;
        }

        private bool AddMove(Player player, string pos)
        {
            int index = -1;
            pos = pos.Trim().ToUpper();
            switch (pos)
            {
                case "A1":
                    index = 0;
                    break;
                case "A2":
                    index = 1;
                    break;
                case "A3":
                    index = 2;
                    break;
                case "B1":
                    index = 3;
                    break;
                case "B2":
                    index = 4;
                    break;
                case "B3":
                    index = 5;
                    break;
                case "C1":
                    index = 6;
                    break;
                case "C2":
                    index = 7;
                    break;
                case "C3":
                    index = 8;
                    break;
            }
            if (index == -1)
                return false; // Invalid move
            if (board[index] != 0)
                return false; // Invalid move
            board[index] = player.isFirstPlayer() ? 1 : 2;
            return true;
        }
    }
}
