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
    /// Logique d'interaction pour updateOrganisateur.xaml
    /// </summary>
    public partial class updateOrganisateur : Page
    {
        private readonly ICollection<Festival> ListeFestivals;
        private readonly ICollection<Organisateur> ListeOrganisateurs;
        private string EmailOrga;
        public updateOrganisateur()
        {
            InitializeComponent();
            ListeFestivals = API.Instance.GetFestival().Result;
            foreach (Festival festival in ListeFestivals)
            {
                LbFestival.Items.Add(festival.FestivalId + " " + festival.Nom_Festival);

            }

            ListeOrganisateurs = API.Instance.GetOrganisateur().Result;
            foreach (Organisateur organisateur in ListeOrganisateurs)
            {
                LbOrganisateur.Items.Add(organisateur.Email);

            }

        }

        private void BtnUpdateOrga(object sender, RoutedEventArgs e)
        {
            var orga = API.Instance.GetOrganisateur(EmailOrga).Result;
            orga.Prenom = updatePrenomBox.Text;
            orga.Nom = updateNomBox.Text;
            orga.Email = updateEmailBox.Text;
            orga.Mot_de_passe = updateMdpBox.Text;
            orga.FestivalId = int.Parse(updateIdFestivalBox.Text);
            _ = API.Instance.ModifierOrganisateur(orga);
            MessageBox.Show("Organisateur modifié avec succès !", "Enregistrement effectué", MessageBoxButton.OK, MessageBoxImage.Information);
            updateOrganisateur updateorga = new updateOrganisateur();
            this.NavigationService.Navigate(updateorga);
        }

        private void LbOrganisateur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EmailOrga = LbOrganisateur.SelectedItem.ToString();
            var organisateur = API.Instance.GetOrganisateur(EmailOrga).Result;
            updatePrenomBox.Text = organisateur.Prenom;
            updateNomBox.Text = organisateur.Nom;
            updateEmailBox.Text = organisateur.Email;
            updateMdpBox.Text = organisateur.Mot_de_passe;
            updateIdFestivalBox.Text = organisateur.FestivalId.ToString();

        }
    }
}
