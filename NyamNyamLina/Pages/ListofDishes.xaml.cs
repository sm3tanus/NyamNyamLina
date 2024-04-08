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
using static System.Net.Mime.MediaTypeNames;

namespace NyamNyamLina.Pages
{
    /// <summary>
    /// Interaction logic for ListofDishes.xaml
    /// </summary>
    public partial class ListofDishes : Page
    {
        List<Dish> dishes = Connection.nyamNyam.Dish.ToList();

        public ListofDishes()
        {
            InitializeComponent();
            CategoryCb.ItemsSource = Connection.nyamNyam.Category.ToList();
            dishesLv.ItemsSource = dishes;
            double max = dishes[0].FinalPriceInDollars;
            double min = dishes[0].FinalPriceInDollars;
            CategoryCb.SelectedItem = Connection.nyamNyam.Category.ToList().Last();
            
            foreach (Dish dish in dishes)
            {
                if (dish.FinalPriceInDollars > max)
                {
                    max = dish.FinalPriceInDollars;
                }
                if (dish.FinalPriceInDollars < min)
                {
                    min = dish.FinalPriceInDollars;
                }
            }
            Slider.Maximum = max;
            Slider.Minimum = min;
            Slider.Value = max;


            Filter();
        }
        private void Filter()
        {
            if (CategoryCb.SelectedItem != Connection.nyamNyam.Category.ToList().Last() && ShowCb.IsChecked == false)
                dishesLv.ItemsSource = dishes.Where(i => i.Name.Contains(NameTb.Text) && i.FinalPriceInDollars <= Slider.Value && i.Category == CategoryCb.SelectedItem as Category).ToList();
            else if (CategoryCb.SelectedItem != Connection.nyamNyam.Category.ToList().Last() && ShowCb.IsChecked == true)
            {
                dishesLv.ItemsSource = dishes.Where(i =>
                i.CookingStage.All(stage =>
                    stage.IngredientOfStage.All(ingredient =>
                         ingredient.Availible == true)) && i.Name.Contains(NameTb.Text) && i.FinalPriceInDollars <= Slider.Value && i.Category == CategoryCb.SelectedItem as Category).ToList();
            }
            else if (CategoryCb.SelectedItem == Connection.nyamNyam.Category.ToList().Last() && ShowCb.IsChecked == true)
                dishesLv.ItemsSource = dishes.Where(i => i.CookingStage.All(stage =>
                    stage.IngredientOfStage.All(ingredient =>
                         ingredient.Availible == true)) && i.Name.Contains(NameTb.Text) && i.FinalPriceInDollars <= Slider.Value).ToList();
            else
                dishesLv.ItemsSource = dishes.Where(i => i.Name.Contains(NameTb.Text) && i.FinalPriceInDollars <= Slider.Value).ToList();
        }
        private void dishesLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.selectedDish = dishesLv.SelectedItem as Dish;
            NavigationService.Navigate(new Recipe());
        }
        private void CategoryCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void NameTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Tb.Text = Convert.ToInt32(Slider.Value).ToString();
            Filter();
        }

        private void ShowCb_Checked(object sender, RoutedEventArgs e)
        {
            dishes = Connection.nyamNyam.Dish.ToList();
            Filter();
        }
        
    }
}
