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
using NyamNyamLina.DBconnection;

namespace NyamNyamLina.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddRecipe.xaml
    /// </summary>
    public partial class AddRecipe : Page
    {
        public static CookingStage cookingStage;
        public AddRecipe()
        {
            InitializeComponent();
  
            ingredientsLv.ItemsSource = Connection.nyamNyam.Ingredient.ToList();
        }

        private void SaveBt_Click(object sender, RoutedEventArgs e)
        {
 
                IngredientOfStage ingredientOfStage = new IngredientOfStage();
                ingredientOfStage.CookingStageId = cookingStage.Id;
                ingredientOfStage.IngredientId = (ingredientsLv.SelectedItem as Ingredient).Id;
                ingredientOfStage.Quantity = int.Parse(quantityTb.Text);
                Connection.nyamNyam.IngredientOfStage.Add(ingredientOfStage);
                Connection.nyamNyam.SaveChanges();
                NavigationService.Navigate(new ListofDishes());


                MessageBox.Show("Fill in all the fields!");

           
        }

        private void NextBt_Click(object sender, RoutedEventArgs e)
        {

                IngredientOfStage ingredientOfStage = new IngredientOfStage();
                ingredientOfStage.CookingStageId = cookingStage.Id;
                ingredientOfStage.IngredientId = (ingredientsLv.SelectedItem as Ingredient).Id;
                ingredientOfStage.Quantity = int.Parse(quantityTb.Text);
                Connection.nyamNyam.IngredientOfStage.Add(ingredientOfStage);
                Connection.nyamNyam.SaveChanges();
                NavigationService.Navigate(new AddRecipe());
        }

        private void Save1Bt_Click(object sender, RoutedEventArgs e)
        {
   
                cookingStage.DishId = App.createDish.Id;
                cookingStage.ProcessDescription = descriptionTb.Text;
                cookingStage.TimeInMinutes = int.Parse(timeTb.Text);
                Connection.nyamNyam.CookingStage.Add(cookingStage);
                Connection.nyamNyam.SaveChanges();
                quantityTb.Visibility = Visibility.Visible;
                QuantityV.Visibility = Visibility.Visible;
                ingredientsLv.Visibility = Visibility.Visible;
                ingrV.Visibility = Visibility.Visible;
                SaveBt.Visibility = Visibility.Visible;
                NextBt.Visibility = Visibility.Visible;
                Save1Bt.Visibility = Visibility.Hidden;
            
        }
    }
}
