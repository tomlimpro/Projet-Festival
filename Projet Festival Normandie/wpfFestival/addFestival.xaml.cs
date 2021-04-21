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
using Microsoft.Win32;
using System.IO;

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
            // On affiche la liste des festivals dans listbox
            ListeFestivals = API.Instance.GetFestival().Result;
            foreach (Festival festival in ListeFestivals)
            {
                LbNomFestivals.Items.Add(festival.Nom_Festival + " " + festival.Ville + " " + festival.Description);
                
            }
        }

        private void Btnadd(object sender, RoutedEventArgs e)
        {
            // On s'assure que l'utilisateur a inséré des valeurs dans les textbox.
            if(nomFestivalbox.Text.Length >= 3 && lieuFestivalbox.Text.Length >= 3 && descriptionFestivalbox.Text.Length >= 3)
            {
                // On vérifie que la saisie du nom et du lieu ne se retrouve pas dans notre base de données, 
                Festival vide = API.Instance.GetFestival(nomFestivalbox.Text, lieuFestivalbox.Text).Result;
                if(vide == null)
                {
                    Festival festival = new Festival();
                    // Les informations qu'on récupère dans nos TextBox sont save dans festival.
                    festival.Nom_Festival = nomFestivalbox.Text;
                    festival.Ville = lieuFestivalbox.Text;
                    festival.Description = descriptionFestivalbox.Text;
                    festival.Logo = pathLogoBox.Text;
                    // On ajoute ces données dans notre bdd.
                    _ = API.Instance.AjoutFestival(festival);
                    MessageBox.Show("Festival ajouté avec succès !","Enregistrement effectué" ,MessageBoxButton.OK, MessageBoxImage.Information);
                    addFestival addfesti = new addFestival();
                    this.NavigationService.Navigate(addfesti);
                }
                else
                {
                    MessageBox.Show("Le festival existe dans notre base de données","Enregistrement non effectué", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Stream checkStream = null;
            // On ouvre une fenêtre qui nous permet de récupérer l'image.
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "All Image Files | *.*";
            if ((bool)openFileDialog.ShowDialog())
            {
                try
                {
                    if ((checkStream = openFileDialog.OpenFile()) != null)
                    {
                        // On charge l'image dans notre picturebox 
                        pictureBox1.Source = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Absolute));
                        // On récupère le chemin qui nous mène vers l'image.
                        pathLogoBox.Text = openFileDialog.FileName;
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
