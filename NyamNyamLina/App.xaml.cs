﻿using NyamNyamLina.DBconnection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NyamNyamLina
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Dish selectedDish;
        public static Ingredient selectedIngredient;
        public static Dish createDish = new Dish();
    }
}
