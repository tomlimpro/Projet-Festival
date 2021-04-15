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
using FestivalAPI.Models;

namespace wpfFestival
{
    /// <summary>
    /// Logique d'interaction pour addFestival.xaml
    /// </summary>
    public partial class addFestival : Page
    {
        private readonly ICollection<Festival> ListeFestivals;
        public addFestival()
        {
            InitializeComponent();

            ListeFestivals = API.Instance.GetFestival().Result;
            foreach (Festival festival in ListeFestivals)
            {
                LbNomFestivals.Items.Add(festival.Nom_Festival + " " + festival.Lieu);
                
            }
        }

        private void Btnadd(object sender, RoutedEventArgs e)
        {
            if(nomFestivalbox.Text.Length >= 3 && lieuFestivalbox.Text.Length >= 3)
            {
                Festival vide = API.Instance.GetFestival(nomFestivalbox.Text, lieuFestivalbox.Text).Result;
                if(vide == null)
                {
                    Festival festival = new Festival();
                    festival.Nom_Festival = nomFestivalbox.Text;
                    festival.Lieu = lieuFestivalbox.Text;
                    _ = API.Instance.AjoutFestival(festival);
                    MessageBox.Show("Festival ajouté avec succès !","Enregistrement effectué" ,MessageBoxButton.OK, MessageBoxImage.Information);
                    addFestival addfesti = new addFestival();
                    this.NavigationService.Navigate(addfesti);
                }

            }
        }

       
    }
}
