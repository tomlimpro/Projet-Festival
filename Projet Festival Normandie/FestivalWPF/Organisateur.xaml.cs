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
    /// Logique d'interaction pour Organisateur.xaml
    /// </summary>
    public partial class Organisateur : Page
    {
        public Organisateur()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            this.NavigationService.Navigate(menu);
        }

       

        
    }
}
