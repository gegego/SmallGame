using System;
using IGameCore;
namespace Floodit.Core
{
    public class PlayerGreed
    {
        public PlayerGreed()
        {
        }

        public int AutoPlay(GameFloodit g, BoardFloodit b)
        {
            int totalsteps = 0;
            Board _org = new Board();
            _org.InitialBoard(b.GetBoard());
            Board _maxSolution = new Board();
            _maxSolution.InitialBoard(b.GetBoard());
            BoardFloodit work = new BoardFloodit();
            work.InitialBoard(b.GetBoard());

            int colorsize = b.ColorSize;
            int setp= 0;
            while(true)
            {
                int max_score = 0;
                for (int i = 0; i < colorsize; i++){
                    g.Step(work, i);
                    int _s = g.GetScore(work); 
                    if (_s > max_score){
                        max_score = _s;
                        setp = i;
                        _maxSolution.InitialBoard(work.GetBoard());
                    }
                    work.InitialBoard(_org.GetBoard());
                }

                totalsteps++;
                if(g.isWin(work)){
                    break;
                }

                //_maxSolution.PrintBoard();
                //Console.Write(setp.ToString()+":");
                //Console.WriteLine(max_score);

                work.InitialBoard(_maxSolution.GetBoard());
                _org.InitialBoard(work.GetBoard());
            }
            return totalsteps;
        }
    }
}
