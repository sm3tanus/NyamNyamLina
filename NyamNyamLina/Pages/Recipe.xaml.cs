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
    /// Interaction logic for Recipe.xaml
    /// </summary>
    public partial class Recipe : Page
    {
        int Servings = 1;
        public Recipe()
        {
            InitializeComponent();
            CookingStage cooking = Connection.nyamNyam.CookingStage.FirstOrDefault(i => i.DishId == App.selectedDish.Id);
            NameDishTb.Text = App.selectedDish.Name;
            CategoryTb.Text = App.selectedDish.Category.Name;
            CookingTimeTb.Text = $"{cooking.TimeInMinutes}m.";
            ServingsTb.Text = Servings.ToString();
            TotalCostTb.Text = (App.selectedDish.FinalPriceInDollars * Servings).ToString();
            DescriptionTb.Text = App.selectedDish.Description;
            ingredientsLv.ItemsSource = Connection.nyamNyam.IngredientOfStage.Where(i => i.CookingStage.DishId == App.selectedDish.Id).ToList();
            processLv.ItemsSource = Connection.nyamNyam.CookingStage.Where(i => i.DishId == App.selectedDish.Id).ToList();

        }

        private void minusServingsBt_Click(object sender, RoutedEventArgs e)
        {
            Servings --;
            ServingsTb.Text = Servings.ToString();
            TotalCostTb.Text = (App.selectedDish.FinalPriceInDollars * Servings).ToString();
        }

        private void plusServingsBt_Click(object sender, RoutedEventArgs e)
        {
            Servings ++;
            ServingsTb.Text = Servings.ToString();
            TotalCostTb.Text = (App.selectedDish.FinalPriceInDollars * Servings).ToString();
        }

        private void ServingsTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (ServingsTb.Text.Length != 0)
                {
                    Servings = int.Parse(ServingsTb.Text);
                    TotalCostTb.Text = (App.selectedDish.FinalPriceInDollars * Servings).ToString();
                }
            }
            catch
            {
                MessageBox.Show("Введите число!");
            }
        }
    }
}
