using ApiQuiz.GameService;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiQuiz.Logic.GameService
{
    public interface IGameCreator
    {
        public IGame CreateGame();
    }
}
