using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisGame.Entities
{
    public class Game
    {
        public Game(Player firstPlayer, Player secondPlayer)
        {
            Result = 0;
            FirstPlayerScore = new Score(firstPlayer);
            SecondPlayerScore = new Score(secondPlayer);
            Report = string.Empty;
        }

        #region Properties
        public int Result { get; set; }

        public Player Winner {
            get
            {
                if ((SecondPlayerScore.Points - 2 == FirstPlayerScore.Points && 
                    SecondPlayerScore.Points >= 3 &&
                    FirstPlayerScore.Points >=2) ||
                    (SecondPlayerScore.Points == 4 &&
                    FirstPlayerScore.Points < 2))
                    return SecondPlayerScore.Player;
                else
                    return FirstPlayerScore.Player;
            }
        }

        public Score FirstPlayerScore { get; set; }

        public Score SecondPlayerScore { get; set; }

        public string Report { get; set; }

        public bool IsNotGameFinished
        {
            get
            {
                if (this.IsFinished())
                    return false;
                else
                    return true;
            }
        }
        #endregion

        #region Methods
        public bool IsParity()
        {
            if (FirstPlayerScore.Points == SecondPlayerScore.Points && FirstPlayerScore.Points >= 3)
                return true;
            else
                return false;
        }

        public bool IsFirstPlayerAdvantage()
        {
            if (FirstPlayerScore.Points == SecondPlayerScore.Points+1 && 
                FirstPlayerScore.Points >= 3 && 
                SecondPlayerScore.Points > 2)
                return true;
            else
                return false;
        }

        public bool IsSecondPlayerAdvantage()
        {
            if (SecondPlayerScore.Points == FirstPlayerScore.Points + 1 
                && SecondPlayerScore.Points >= 3 &&
                FirstPlayerScore.Points > 2)
                return true;
            else
                return false;
        }

        public bool IsFinished()
        {
            if (SecondPlayerScore.Points -2 == FirstPlayerScore.Points && FirstPlayerScore.Points >= 3 ||
                FirstPlayerScore.Points - 2 == SecondPlayerScore.Points && SecondPlayerScore.Points >= 3 ||
                SecondPlayerScore.Points >=4 && FirstPlayerScore.Points <= 2 ||
                FirstPlayerScore.Points >= 4 && SecondPlayerScore.Points <= 2)
                return true;
            else
                return false;
        }

        public string PointsToGamePoints(int points)
        {
            switch (points)
            {
                case 0:
                    return "Love";
                case 1:
                    return "Fifteen";
                case 2:
                    return "Thirty";
                case 3:
                    return "Forty";
                default:
                    return "Undefined";
            }
        }
        #endregion

    }
}
