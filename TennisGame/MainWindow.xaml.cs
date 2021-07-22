using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TennisGame.Model;

namespace TennisGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameViewModel _gameViewModel;

        public MainWindow()
        {
            InitializeComponent();
            _gameViewModel = (GameViewModel)base.DataContext;
            _gameViewModel.Print.ReportScore();
        }

        private void ButtonUpdateScore_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                if ((sender as Button).Name.Equals("btnFirstPlayerPoint"))
                    _gameViewModel.FirstPlayerPoints++;
                else if ((sender as Button).Name.Equals("btnSecondPlayerPoint"))
                    _gameViewModel.SecondPlayerPoints++;
                _gameViewModel.Print.ReportScore();
            }
        }
    }
}
