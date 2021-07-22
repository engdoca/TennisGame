using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisGame.Entities
{
    public class Report
    {
        private Game _game;
        public Report(Game game)
        {
            if (game is null)
                throw new ArgumentNullException(nameof(game));
            _game = game;
        }

        #region Methods
        public string ReportScore()
        {
            if (_game.SecondPlayerScore.Points == 0 && _game.FirstPlayerScore.Points == 0)
                return $"The match is started";
            if (_game.IsParity())
                return $"Deuce";
            if (_game.IsFirstPlayerAdvantage())
                return $"Advantage {_game.FirstPlayerScore.Player.Name}";
            if (_game.IsSecondPlayerAdvantage())
                return $"Advantage {_game.SecondPlayerScore.Player.Name}";
            if(_game.IsFinished())
                return $"{_game.Winner.Name} won the game\r\nPlease close the program to start new game!";
            return $"{_game.FirstPlayerScore.Player.Name} vs {_game.SecondPlayerScore.Player.Name} : {_game.PointsToGamePoints(_game.FirstPlayerScore.Points)} - {_game.PointsToGamePoints(_game.SecondPlayerScore.Points)}";
        }

        #endregion
    }
}
