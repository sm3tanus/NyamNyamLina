using NyamNyamLina.DBconnection;
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

namespace NyamNyamLina.Pages
{
    /// <summary>
    /// Interaction logic for ListofDishes.xaml
    /// </summary>
    public partial class ListofDishes : Page
    {
        public ListofDishes()
        {
            InitializeComponent();
            CategoryCb.ItemsSource = DBconnection.Connection.nyamNyam.Category.ToList();
            dishesLv.ItemsSource = Connection.nyamNyam.Dish.ToList();
        }
    }
}
