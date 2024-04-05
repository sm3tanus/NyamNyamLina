using NyamNyamLina.DBconnection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace NyamNyamLina.Converters
{
    public class ColorCheckBox : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IngredientOfStage ingredient = (IngredientOfStage)value;
            Color greenColor = Colors.Green;
            Color redColor = Colors.Red;
            return (bool)ingredient.Availible ? greenColor : redColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
