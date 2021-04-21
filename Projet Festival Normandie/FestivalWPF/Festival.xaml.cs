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
    /// Logique d'interaction pour Festival.xaml
    /// </summary>
    public partial class Festival : Page
    {
        public Festival()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            this.NavigationService.Navigate(menu);
        }

        private void BtnAddFestival(object sender, RoutedEventArgs e)
        {
            addFestival addfestival = new addFestival();
            this.NavigationService.Navigate(addfestival);
        }

        private void BtnUpdateFestival(object sender, RoutedEventArgs e)
        {
            updateFestival updatefestival = new updateFestival();
            this.NavigationService.Navigate(updatefestival);
        }

        private void BtnDeleteFestival(object sender, RoutedEventArgs e)
        {
            deleteFestival deletefestival = new deleteFestival();
            this.NavigationService.Navigate(deletefestival);
        }
    }
}
