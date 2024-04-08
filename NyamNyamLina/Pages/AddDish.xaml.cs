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
    /// Логика взаимодействия для AddDish.xaml
    /// </summary>
    public partial class AddDish : Page
    {
        public AddDish()
        {
            InitializeComponent();
            CategoryCb.ItemsSource = Connection.nyamNyam.Category.ToList();
        }

        private void SaveBt_Click(object sender, RoutedEventArgs e)
        {
            try {
                App.createDish.Name = NameTb.Text.Trim();
                App.createDish.BaseServingsQuantity = int.Parse(quantityTb.Text.Trim());
                App.createDish.CategoryId = (CategoryCb.SelectedItem as Category).Id;
                App.createDish.Image = imageLinkTb.Text.Trim();
                App.createDish.RecipeLink = recipeTb.Text.Trim();
                App.createDish.Description = descriptionTb.Text.Trim();
                App.createDish.FinalPriceInDollars = double.Parse(priceTb.Text.Trim());
                Connection.nyamNyam.Dish.Add(App.createDish);
                Connection.nyamNyam.SaveChanges();
                NavigationService.Navigate(new AddRecipe());
            }
            catch {
                MessageBox.Show("Fill in all the fields!");
            }
           

        }
    }
}
