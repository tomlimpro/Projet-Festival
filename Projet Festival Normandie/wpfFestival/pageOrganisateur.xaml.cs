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

namespace wpfFestival
{
    /// <summary>
    /// Logique d'interaction pour Organisateur.xaml
    /// </summary>
    public partial class pageOrganisateur : Page
    {
        public pageOrganisateur()
        {
            InitializeComponent();
        }

        private void BtnAddOrganisateur(object sender, RoutedEventArgs e)
        {
            addOrganisateur addorga = new addOrganisateur();
            this.NavigationService.Navigate(addorga);
        }

        private void BtnUpdateOrganisateur(object sender, RoutedEventArgs e)
        {
            updateOrganisateur updateorga = new updateOrganisateur();
            this.NavigationService.Navigate(updateorga);
        }

        private void BtnDeleteOrganisateur(object sender, RoutedEventArgs e)
        {
            deleteOrganisateur deleteorga = new deleteOrganisateur();
            this.NavigationService.Navigate(deleteorga);
        }
    }
}
