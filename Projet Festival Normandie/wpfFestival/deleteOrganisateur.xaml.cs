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
    /// Logique d'interaction pour deleteOrganisateur.xaml
    /// </summary>
    public partial class deleteOrganisateur : Page
    {
        private readonly ICollection<Organisateur> ListeOrganisateurs;
        private string Emailorga;
        public deleteOrganisateur()
        {
            InitializeComponent();
            ListeOrganisateurs = API.Instance.GetOrganisateur().Result;
            foreach (Organisateur organisateur in ListeOrganisateurs)
            {
                LbOrganisateur.Items.Add(organisateur.Email);

            }
        }

        private void BtnDeleteOrga(object sender, RoutedEventArgs e)
        {
            var orga = API.Instance.GetOrganisateur(Emailorga).Result;


            _ = API.Instance.DeleteOrganisateur(orga.OrganisateurID);

            MessageBox.Show("Organisateur supprimé avec succès !", "Enregistrement effectué", MessageBoxButton.OK, MessageBoxImage.Information);

            deleteOrganisateur deleteorga = new deleteOrganisateur();
            this.NavigationService.Navigate(deleteorga);
        }

        private void LbOrganisateur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Emailorga = LbOrganisateur.SelectedItem.ToString();
        }
    }
}
