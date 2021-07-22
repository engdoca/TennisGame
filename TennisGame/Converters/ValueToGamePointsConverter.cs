using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TennisGame.Converters
{
    public class ValueToGamePointsConverter : IMultiValueConverter
    {
        public const string Parity = "Deuce";
        public const string FirstPlayerAdvantage = "Advantage-Forty";
        public const string SecondPlayerAdvantage = "Forty-Advantage";
        public const string FirstPlayerWin = "First player won the game";
        public const string SecondPlayerWin = "Second player won the game";
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && values.Length == 2)
            {
                    int firstResult = (int)values[0];
                    int secondResult = (int)values[1];
                    string firRes;
                    string secRes;
                    firRes = PointsToGamePoints(firstResult);
                    secRes = PointsToGamePoints(secondResult);
                if (firRes == "Undefined" || secRes == "Undefined")
                {
                    if (firstResult == secondResult)
                        return Parity;
                    else if (firstResult > secondResult)
                    {
                        if (firstResult - 2 > secondResult)
                            return FirstPlayerWin;
                        return FirstPlayerAdvantage;
                    }
                    else if (firstResult < secondResult)
                    {
                        if (secondResult - 2 > firstResult)
                            return SecondPlayerWin;
                        return SecondPlayerAdvantage;
                    }
                }
                return firRes + " - " + secRes;
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private string PointsToGamePoints(int points)
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
    }
}
