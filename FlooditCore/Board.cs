using System;
using IGameCore;

namespace Floodit.Core
{
    public class Board : IBoard
    {
        protected int[,] _board;
        protected int _size;

        public int[,] GetBoard()
        {
            return _board;
        }

        public int GetStartColor()
        {
            return _board[0, 0];
        }


        public Board()
        {
        }

        public void InitialBoard(int[,] _input)
        {
            this._size = _input.GetLength(0);
            this._board = new int[_size, _size];

            for (int i = 0; i < _size; i++)
                for (int j = 0; j < _size; j++)
                    _board[i, j] = _input[i, j];
        }

        public void PrintBoard()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                    Console.Write(_board[i, j].ToString() + ",");

                Console.WriteLine();
            }
        }
    }
}
