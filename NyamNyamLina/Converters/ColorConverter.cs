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
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Dish dish = value as Dish;
            List<Dish>dishes = Connection.nyamNyam.Dish.Where(i => i.CookingStage.All(stage => stage.IngredientOfStage.All(ingredient => ingredient.Availible == true))).ToList();      
            return dishes.Contains(dish)?PixelFormats.Pbgra32 : PixelFormats.Gray8;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
