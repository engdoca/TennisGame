using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisGame.Entities
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
        }

        #region Properties
        public string Name { get; set; }
        #endregion
    }
}
