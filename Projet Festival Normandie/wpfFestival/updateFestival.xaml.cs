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
    /// Logique d'interaction pour updateFestival.xaml
    /// </summary>
    public partial class updateFestival : Page
    {
        private readonly ICollection<Festival> ListeFestivals;
        private string nomfesti;


        public updateFestival()
        {
            InitializeComponent();
            ListeFestivals = API.Instance.GetFestival().Result;
            foreach (Festival festival in ListeFestivals)
            {
                LbFestivals.Items.Add(festival.Nom_Festival);

            }
        }

        private void LbFestivals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nomfesti = LbFestivals.SelectedItem.ToString();
            var fest = API.Instance.GetFestival(nomfesti).Result;
            nomFestivalBox.Text = fest.Nom_Festival;
            lieuFestivalBox.Text = fest.Lieu;
            descriptionFestivalBox.Text = fest.Description;
           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var festi = API.Instance.GetFestival (nomfesti).Result;
            festi.Nom_Festival = nomFestivalBox.Text;
            festi.Lieu = lieuFestivalBox.Text;
            festi.Description = descriptionFestivalBox.Text;
            _ = API.Instance.ModifierFestival(festi);
            MessageBox.Show("Festival modifié avec succès !", "Enregistrement effectué", MessageBoxButton.OK, MessageBoxImage.Information);
            updateFestival updatefesti = new updateFestival();
            this.NavigationService.Navigate(updatefesti);




        }
    }
}
