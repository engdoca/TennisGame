using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisGame.Entities;

namespace TennisGame.Model
{
    public class GameViewModel : INotifyPropertyChanged
    {

        public GameViewModel()
        {
            _game = new Game(new Player ("Matteo Berettini"), new Player("Novak Đoković"));
            _print = new Report(_game);
        }

        #region Members
        Game _game;
        Report _print;
        #endregion

        #region Properties
        public Game Game
        {
            get
            {
                return _game;
            }
            set
            {
                _game = value;
            }
        }
        public Report Print
        {
            get
            {
                return _print;
            }
            set
            {
                _print = value;
            }
        }

        private string _report;
        public string Report
        {
            get
            {
                _report += Print.ReportScore() + Environment.NewLine;
                return _report;
            }
        }

        public bool IsNotFinished
        {
            get { return Game.IsNotGameFinished; }
        }

        public int FirstPlayerPoints
        {
            get { return Game.FirstPlayerScore.Points; }
            set
            {
                if (Game.FirstPlayerScore.Points != value)
                {
                    Game.FirstPlayerScore.Points = value;
                    RaisePropertyChanged(nameof(FirstPlayerPoints));
                    RaisePropertyChanged(nameof(Report));
                    RaisePropertyChanged(nameof(IsNotFinished));
                }
            }
        }

        public int SecondPlayerPoints
        {
            get { return Game.SecondPlayerScore.Points; }
            set
            {
                if (Game.SecondPlayerScore.Points != value)
                {
                    Game.SecondPlayerScore.Points = value;
                    RaisePropertyChanged(nameof(SecondPlayerPoints));
                    RaisePropertyChanged(nameof(Report));
                    RaisePropertyChanged(nameof(IsNotFinished));
                }
            }
        }

        public string FirstPlayerName
        {
            get
            {
                return Game.FirstPlayerScore.Player.Name;
            }
        }

        public string SecondPlayerName
        {
            get
            {
                return Game.SecondPlayerScore.Player.Name;
            }
        }

        public string Winner
        {
            get { return Game.Winner.Name; }
        }

        #endregion

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
