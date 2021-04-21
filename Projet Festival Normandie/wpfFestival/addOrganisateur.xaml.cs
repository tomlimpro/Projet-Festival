using FestivalAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logique d'interaction pour addOrganisateur.xaml
    /// </summary>
    public partial class addOrganisateur : Page
    {
        private readonly ICollection<Festival> ListeFestivals;
        private readonly ICollection<Organisateur> ListeOrganisateurs;
        private string nomfesti;

        public addOrganisateur()
        {
            InitializeComponent();
            ListeFestivals = API.Instance.GetFestival().Result;
            foreach (Festival festival in ListeFestivals)
            {
                LbFestivals.Items.Add(festival.Nom_Festival);

            }
            ListeOrganisateurs = API.Instance.GetOrganisateur().Result;
            foreach (Organisateur organisateur in ListeOrganisateurs)
            {
                lbOrganisateur.Items.Add(organisateur.Prenom + " " + organisateur.Nom + " " + organisateur.Email + " ");

            }
        }

        private void BtnAddOrga(object sender, RoutedEventArgs e)
        {
            if (PrenomBox.Text.Length >= 3 && NomBox.Text.Length >= 3 && EmailBox.Text.Length >= 3 && MdpBox.Text.Length >= 3 && EmailValid(EmailBox.Text))
            {
                if(EmailValid(EmailBox.Text) == true)
                {
                    Organisateur vide = API.Instance.GetOrganisateur(NomBox.Text, EmailBox.Text).Result;
                    if (vide == null)
                    {
                        Organisateur organisateur = new Organisateur();
                        organisateur.Prenom = PrenomBox.Text;
                        organisateur.Nom = NomBox.Text;
                        organisateur.Email = EmailBox.Text;
                        organisateur.Mot_de_passe = MdpBox.Text;
                        organisateur.FestivalID = int.Parse(idfestivalbox.Text);
                        _ = API.Instance.AjoutOrganisateur(organisateur);
                        MessageBox.Show("Organisateur ajouté avec succès !", "Enregistrement effectué", MessageBoxButton.OK, MessageBoxImage.Information);
                        addOrganisateur addorga = new addOrganisateur();
                        this.NavigationService.Navigate(addorga);
                    }
                }
                
                
                

            }
        }

        public static bool EmailValid(string emailAddress)
        {
            var regex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            bool isValid = Regex.IsMatch(emailAddress, regex, RegexOptions.IgnoreCase);
            if(isValid == true)
            {
                return isValid;
            }

            else
            {
                return false;
            }
            
            
            
            
            
        }

        private void LbFestivals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nomfesti = LbFestivals.SelectedItem.ToString();
            var fest = API.Instance.GetFestival(nomfesti).Result;
            idfestivalbox.Text = Convert.ToString(fest.FestivalID);
        }
    }
}
