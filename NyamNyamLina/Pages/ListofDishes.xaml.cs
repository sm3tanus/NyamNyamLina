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
        List<Dish> dishes;
        public ListofDishes()
        {
            InitializeComponent();
            dishes = Connection.nyamNyam.Dish.ToList();
            CategoryCb.ItemsSource = Connection.nyamNyam.Category.ToList();
            dishesLv.ItemsSource = dishes;
        }

        private void dishesLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.selectedDish = dishesLv.SelectedItem as Dish;
            NavigationService.Navigate(new Recipe());
        }
        private void CategoryCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dishesLv.ItemsSource = dishes.Where(i => i.Category == CategoryCb.SelectedItem as Category && i.Name.Contains(NameTb.Text)).ToList();
        }

        private void NameTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            dishesLv.ItemsSource = dishes.Where(i => i.Name.Contains(NameTb.Text) && i.Category == CategoryCb.SelectedItem as Category).ToList();   
        }
    }
}
