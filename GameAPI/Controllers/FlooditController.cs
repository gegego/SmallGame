using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Floodit.Core;

namespace GameAPI.Controllers
{
    public class GameStatus 
    { 
        public int[,] board { get; set; }  
        public int step { get; set; } 
    } 

    public class GameResult{
        public int[,] board { get; set; }  
        public bool isWin { get; set; } 
    }

    [Route("gameapi/[controller]")]
    public class FlooditController : Controller
    {
        public BoardFloodit _board;
        GameFloodit _game;
        PlayerGreed _player;

        public FlooditController()
        {
            _board = new BoardFloodit();
            _game = new GameFloodit();
            _player = new PlayerGreed();
        }

        [HttpGet]
        public JsonResult Get()
        {
            _board.InitialBoard(15, 3);
            int steps_com = _player.AutoPlay(_game, _board);
            GameStatus _com = new GameStatus();
            _com.board = _board.GetBoard();
            _com.step = steps_com;
            return Json(_com);
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody]GameStatus value)
        {
            _board.InitialBoard(value.board);
            _game.Step(_board, value.step);

            GameResult result = new GameResult();
            result.board = _board.GetBoard();
            result.isWin = _game.isWin(_board);

            return Json(result);
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
