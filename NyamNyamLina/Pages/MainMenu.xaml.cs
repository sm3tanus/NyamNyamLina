﻿using System;
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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
            MainMenuFrame.NavigationService.Navigate(new ListofDishes());
        }

        private void DishesBt_Click(object sender, RoutedEventArgs e)
        {
            MainMenuFrame.NavigationService.Navigate(new ListofDishes());
        }

        private void IngredientsBt_Click(object sender, RoutedEventArgs e)
        {
            MainMenuFrame.NavigationService.Navigate(new ListOfIngredients());
        }

        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            MainMenuFrame.NavigationService.Navigate(new AddDish());
        }
    }
}
