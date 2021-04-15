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
    /// Logique d'interaction pour deleteFestival.xaml
    /// </summary>
    public partial class deleteFestival : Page
    {
        private readonly ICollection<Festival> ListeFestivals;
        private string nomfesti;
        public deleteFestival()
        {
            InitializeComponent();
            ListeFestivals = API.Instance.GetFestival().Result;
            foreach (Festival festival in ListeFestivals)
            {
                LbNomFestivals.Items.Add(festival.Nom_Festival);

            }
        }

        private void BtnDelete(object sender, RoutedEventArgs e)
        {
            var festi = API.Instance.GetFestival(nomfesti).Result;
            
                      
            _ = API.Instance.DeleteFestival(festi.FestivalId);

            MessageBox.Show("Festival supprimé avec succès !", "Enregistrement effectué", MessageBoxButton.OK, MessageBoxImage.Information);
            
            deleteFestival deletefesti = new deleteFestival();
            this.NavigationService.Navigate(deletefesti);

           
        }

        private void LbNomFestivals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nomfesti = LbNomFestivals.SelectedItem.ToString(); 
        }
    }
}
