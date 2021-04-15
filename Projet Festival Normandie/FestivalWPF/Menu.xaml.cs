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

namespace FestivalWPF
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

        private void BtnOrganisateur_Click(object sender, RoutedEventArgs e)
        {
            Organisateur orga = new Organisateur();
            this.NavigationService.Navigate(orga);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Festival festival = new Festival();
            this.NavigationService.Navigate(festival);
        }
    }
}
