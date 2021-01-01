/*
 * Author: João Nuno Carvalho
 * Date:   2021.01.01
 * Description: A very simple game of Tic Tac Toe in C# programming language.
 * License: MIT Open Source License.
 */

using System;

namespace TicTacToe
{
    public class Player
    {
        private string name;
        private Symbols symbol;

        public Player(string name, bool firstPlayer)
        {
            this.name   = name;
            this.symbol = firstPlayer ? Symbols.X : Symbols.O;
        }

        public string AskMovePlayer()
        {
            string symbString = symbol == Symbols.X ? "X" : "O";
            return name + " move " + symbString + " [ex: \"A1\"]:";
        }

        public string getName()
        {
            return name;
        }

        public string getSymbol()
        {
            return symbol == Symbols.X ? "X" : "O";
        }

        public Symbols getSymbolEmum()
        {
            return symbol;
        }

        public bool isFirstPlayer()
        {
            return symbol == Symbols.X ? true : false;
        }
    }
}
