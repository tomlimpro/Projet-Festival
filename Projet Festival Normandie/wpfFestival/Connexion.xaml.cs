using FestivalAPI.Models;
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
    /// Logique d'interaction pour Connexion.xaml
    /// </summary>
    public partial class Connexion : Page
    {
        
        public Connexion()
        {
            
                InitializeComponent();           
           
        }


        private void Se_connecter(object sender, RoutedEventArgs e)
        {
            

            if (LoginTextBox.Text != "" && MdpTextBox.Text != "")
            {
                Gestionnaire gestionnaire = API.Instance.GetLoginGestionnaire(LoginTextBox.Text, MdpTextBox.Text).Result;

                if (gestionnaire != null)
                {
                    Session.connecte = true;
                    Menu menu = new Menu();
                    this.NavigationService.Navigate(menu);
                }
                else
                {

                    MessageBox.Show("Login et/ou Mot de passe incorrect(s) ", "Erreur de connexion !", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }




        }
        private void MdpTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
