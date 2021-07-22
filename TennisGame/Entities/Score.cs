using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisGame.Entities
{
    public class Score
    {
        public Score(Player player)
        {
            Player = player;
            Points = 0;
        }

        #region Properties
        public Player Player { get; set; }

        public int Points { get; set; }
        #endregion
    }
}
