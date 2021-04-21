﻿using FestivalAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using wpfFestival.ControllersAPI;

namespace wpfFestival
{
    /// <summary>
    /// Logique d'interaction pour pageFestival.xaml
    /// </summary>
    public partial class pageFestival : Page
    {
        private ICollection<Festival> ListeFestivals;
      
        public pageFestival()
        {
            InitializeComponent();
            
            

        }

        private void btnAddFesti(object sender, RoutedEventArgs e)
        {
            addFestival addfesti = new addFestival();
            this.NavigationService.Navigate(addfesti);
        }

        private void updateFesti(object sender, RoutedEventArgs e)
        {
            updateFestival updatefesti = new updateFestival();
            this.NavigationService.Navigate(updatefesti);
        }

        private void deleteFesti(object sender, RoutedEventArgs e)
        {
            deleteFestival deletefesti = new deleteFestival();
            this.NavigationService.Navigate(deletefesti);
        }

        
    }
}
