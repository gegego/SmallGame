using System;
using IGameCore;
using Floodit.Core;

namespace coreProg
{
    class Program
    {
        static void Main(string[] args)
        {
            IBoard _board = new BoardFloodit();

            ((BoardFloodit)_board).InitialBoard(10, 5);
            _board.PrintBoard();

            GameFloodit _game = new GameFloodit();

            //while(true){
            //    string input = Console.ReadLine();
            //    int color = Convert.ToInt32(input);
            //    _game.Step(_board, color);
            //    _board.PrintBoard();
            //    Console.WriteLine(_game.GetScore(_board));
            //    if(_game.isWin(_board)){
            //        break;
            //    }
            //}

            PlayerGreed _palyer = new PlayerGreed();
            _palyer.AutoPlay(_game, (BoardFloodit)_board);        }
    }
}
