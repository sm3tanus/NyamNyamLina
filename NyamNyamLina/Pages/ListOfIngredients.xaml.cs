using NyamNyamLina.DBconnection;
using NyamNyamLina.Properties;
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
    /// Логика взаимодействия для ListOfIngredients.xaml
    /// </summary>
    public partial class ListOfIngredients : Page
    {
       
        public ListOfIngredients()
        {
            InitializeComponent();
            List<Ingredient> ingredients = Connection.nyamNyam.Ingredient.ToList();
            ingredientsLv.ItemsSource = Connection.nyamNyam.Ingredient.ToList();
            double count = 0;
            foreach (Ingredient i in ingredients)
            {
                count += i.AvailableCount;
            }
            CountTb.Text = count.ToString();

        }
        private void plus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.selectedIngredient.AvailableCount++;
                Connection.nyamNyam.SaveChanges();
                NavigationService.Navigate(new ListOfIngredients());
            }
            catch {
                MessageBox.Show("Choise ingredient");
            }
           
        }
        private void minus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.selectedIngredient.AvailableCount--;
                Connection.nyamNyam.SaveChanges();
                NavigationService.Navigate(new ListOfIngredients());
            }
            catch
            {
                MessageBox.Show("Choise ingredient");
            }
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<IngredientOfStage> filter = Connection.nyamNyam.IngredientOfStage.Where(i => i.IngredientId == App.selectedIngredient.Id).ToList();
                if (filter.Count == 0)
                {
                    Connection.nyamNyam.Ingredient.Remove(App.selectedIngredient);
                    Connection.nyamNyam.SaveChanges();
                    NavigationService.Navigate(new ListOfIngredients());
                }
                else
                {
                    MessageBox.Show("This ingredient is used in dishes!");
                }
            }
            catch
            {
                MessageBox.Show("Choise ingredient");
            }
        }
        private void ingredientsLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.selectedIngredient = ingredientsLv.SelectedItem as Ingredient;
        }
    }
}
