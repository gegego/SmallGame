using System;
using IGameCore;

namespace Floodit.Core
{
    public class GameFloodit
    {
        public GameFloodit()
        {
        }

        public void Step(BoardFloodit b, int color)
        {
            int _old = b.GetStartColor();
            if (_old == color)
                return;
            else
                b.FloodFill(color, _old, 0, 0);
        }

        public int GetScore(BoardFloodit b){
            int _old = b.GetStartColor();
            b.FloodFill(100000, _old, 0, 0);
            int score = b.GetScore(100000);
            b.FloodFill(_old, 100000, 0, 0);
            return score;
        }

        public Boolean isWin(BoardFloodit b)
        {
            return b.isAllSameColor();
        }

    }
}
