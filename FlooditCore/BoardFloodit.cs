using System;

namespace Floodit.Core
{
    public class BoardFloodit : Board
    {
        protected int _colorsize;
        private bool isLoad = false;

        public int ColorSize { get => _colorsize; set => _colorsize = value; }
               
        public BoardFloodit()
        {
        }

        public void InitialBoard(int size, int num_color)
        {
            if (isLoad)
                return;
            this._board = new int[size, size];
            this._size = size;
            this._colorsize = num_color;
            isLoad = true;

            Random rnd = new Random();
            for (int i = 0; i < _size; i++)
                for (int j = 0; j < _size; j++)
                    _board[i, j] = rnd.Next(num_color);
        }

        public int GetScore(int _target)
        {
            int score = 0;
            for (int i = 0; i < _size; i++)
                for (int j = 0; j < _size; j++)
                    if (_board[i, j] == _target)
                        score++;

            return score;
        }

        public Boolean isAllSameColor(){
            int color = _board[0, 0];
            for (int i = 0; i < _size; i++)
                for (int j = 0; j < _size; j++)
                    if (_board[i, j] != color)
                        return false;

            return true;
        }

        public void FloodFill(int c, int org_c, int x, int y){
            if (x < 0 || y < 0 || x >= _size || y >= _size)
                return;

            if (_board[x, y] != org_c)
                return;

            _board[x, y] = c;
            FloodFill(c, org_c, x, y-1);
            FloodFill(c, org_c, x, y+1);
            FloodFill(c, org_c, x-1, y);
            FloodFill(c, org_c, x+1, y);
        }

    }
}
