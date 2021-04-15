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
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
        }
        // Lorsqu'on appuie sur le bouton BtnOrganisateur_Clik, on se dirige vers la page Organisateur
        private void BtnOrganisateur_Click(object sender, RoutedEventArgs e)
        {
            pageOrganisateur orga = new pageOrganisateur();
            this.NavigationService.Navigate(orga);
        }
        // Lorsqu'on appuie sur le Button_Click, on se dirige vers la page Festival
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pageFestival pagefestival = new pageFestival();
            this.NavigationService.Navigate(pagefestival);
            
        }
    }
}
