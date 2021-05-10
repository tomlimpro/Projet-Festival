using FestivalAPI.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
        // Lorsqu'on selectionne un festival dans la liste, on affiche toutes ces informations dans les textbox attribués.
        // L'utilisateur voit les informations et changent les informations qui l'intéressent.
        private void LbFestivals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            nomfesti = LbFestivals.SelectedItem.ToString();
            var fest = API.Instance.GetFestival(nomfesti).Result;
            nomFestivalBox.Text = fest.Nom_Festival;
            lieuFestivalbox.Text = fest.Ville;
            string dest = @"C:\Users\tomli\source\repos\Projet Festival Normandie\FestivalWEB\wwwroot\festivalimage\" + fest.Logo;
            oldpictureBox.Source = new BitmapImage(new Uri(dest, UriKind.Absolute));
            descriptionFestivalBox.Text = fest.Description;
           

        }
        // Les informations sont modifiés dans notre base de données.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var festi = API.Instance.GetFestival (nomfesti).Result;
            festi.Nom_Festival = nomFestivalBox.Text;
            festi.Ville = lieuFestivalbox.Text;
            festi.Description = descriptionFestivalBox.Text; 
            if(String.IsNullOrEmpty(pathlogoBox.Text))
            {
                festi.Logo = oldpictureBox.Source.ToString();
            }
            else
            {
                festi.Logo = pathlogoBox.Text;
            }
            _ = API.Instance.ModifierFestival(festi);
            MessageBox.Show("Festival modifié avec succès !", "Enregistrement effectué", MessageBoxButton.OK, MessageBoxImage.Information);
            updateFestival updatefesti = new updateFestival();
            this.NavigationService.Navigate(updatefesti);




        }

        // Lorsqu'on appuie sur le bouton, on ouvre une fenêtre qui nous permet d'aller chercher l'image
        // On affiche l'image dans la picturebox
        // On récupère le chemin qui nous mène vers l'image.
        private void BtnLoadImage(object sender, RoutedEventArgs e)
        {
            Stream checkStream = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "All Image Files | *.*";
            if ((bool)openFileDialog.ShowDialog())
            {
                try
                {
                    if ((checkStream = openFileDialog.OpenFile()) != null)
                    {
                        newpictureBox.Source = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Absolute));
                        string source = openFileDialog.FileName;
                        string dest = @"C:\Users\tomli\source\repos\Projet Festival Normandie\FestivalWEB\wwwroot\festivalimage\" + System.IO.Path.GetFileName(source);
                        string namefile = System.IO.Path.GetFileName(source);
                        File.Copy(source, dest);
                        pathlogoBox.Text = namefile;
                        MessageBox.Show("L'image a bien été récupéré", "Enregistrement effecuté", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : Le fichier n'a pas pu être lu. Erreur original :" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Probleme rencontré, réessayez plus tard");
            }
        }

        
    }
}
