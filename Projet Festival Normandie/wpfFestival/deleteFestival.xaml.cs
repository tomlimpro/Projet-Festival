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

        // On utilise la variable qu'on a récupéré au moment du click dans la list.
        // On recherche dans notre base de données les informations de ce festival
        // On récupère l'id.
        // On l'a supprime de la base de données grâce à l'id.
        private void BtnDelete(object sender, RoutedEventArgs e)
        {
            var festi = API.Instance.GetFestival(nomfesti).Result;
            
                      
            _ = API.Instance.DeleteFestival(festi.FestivalID);

            MessageBox.Show("Festival supprimé avec succès !", "Enregistrement effectué", MessageBoxButton.OK, MessageBoxImage.Information);
            
            deleteFestival deletefesti = new deleteFestival();
            this.NavigationService.Navigate(deletefesti);

           
        }
        // On selectionne le festival qu'on veut supprimer et on insère dans une variable la valeur.
        // Cette valeur sera utilisé pour rechercher notre festival dans base de données.
        private void LbNomFestivals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nomfesti = LbNomFestivals.SelectedItem.ToString(); 
        }
    }
}
