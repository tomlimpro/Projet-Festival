using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FestivalAPI.Models;
using Newtonsoft.Json;
namespace wpfFestival.ControllersAPI
{
    public sealed class API
    {
        private static readonly HttpClient client = new HttpClient();

        private API()
        {
            client.BaseAddress = new Uri("http://localhost:63398/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        private static readonly object padlock = new object();
        private static API instance = null;

        public static API Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new API();
                    }
                    return instance;
                }
            }
        }
        /**************************************** Festival **************************************/
        // GetFestival permet de récupérer toutes les données de la table Festival
        public async Task<ICollection<Festival>> GetFestival()
        {
            ICollection<Festival> Festival = new List<Festival>();
            HttpResponseMessage response = client.GetAsync("api/Festivals").Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                Festival = JsonConvert.DeserializeObject<List<Festival>>(resp);
            }
            return Festival;
        }
        
        // Même méthode mais on recherche en insérant  le nom du festival
        public async Task<Festival> GetFestival(string nom_festival)
        {
            Festival festi = null;
            HttpResponseMessage response = client.GetAsync("api/Festivals/GetNomFestival/" + nom_festival).Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                festi = JsonConvert.DeserializeObject<Festival>(resp);
            }
            return festi;
        }

        // Même méthode mais en renseignant le nom du festival puis le lieu.
        public async Task<Festival> GetFestival(string? Nom_Festival, string? Lieu)
        {
            Festival Festival = null;
            HttpResponseMessage response = client.GetAsync("api/Festivals/" + Nom_Festival + Lieu).Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                Festival = JsonConvert.DeserializeObject<Festival>(resp);
            }
            return Festival;
        }
        // AjoutFestival permet d'ajouter une ligne dans notre table festival.
        // Tous les attributs doivent être renseigné dans la méthode.
        public async Task<Uri> AjoutFestival(Festival festival)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Festivals", festival);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        // ModifierFestival permet de modifier une ligne dans la table Festival
        // Tous les informations doivent être renseigné.
        public async Task<Uri> ModifierFestival(Festival festival)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync("api/Festivals/" + festival.FestivalID, festival);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return null;
        }

        // DeleteFestival supprime une ligne dans la table Festival
        // On utilise l'id d'un festival pour supprimer.
        public async Task<Uri> DeleteFestival(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("api/Festivals/" + id);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        /********************************* Organisateur ****************************************/


        public async Task<ICollection<Organisateur>> GetOrganisateur()
        {
            ICollection<Organisateur> Organisateur = new List<Organisateur>();
            HttpResponseMessage response = client.GetAsync("api/Organisateurs").Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                Organisateur = JsonConvert.DeserializeObject<List<Organisateur>>(resp);
            }
            return Organisateur;
        }

        public async Task<Organisateur> GetOrganisateur(string email)
        {
            Organisateur organi = null;
            HttpResponseMessage response = client.GetAsync("api/Organisateurs/GetEmailOrganisateur/" + email).Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                organi = JsonConvert.DeserializeObject<Organisateur>(resp);
            }
            return organi;
        }

        public async Task<Organisateur> GetOrganisateur(string? nom, string? email)
        {
            Organisateur Organisateur = null;
            HttpResponseMessage response = client.GetAsync("api/Organisateurs/" + nom + email).Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                Organisateur = JsonConvert.DeserializeObject<Organisateur>(resp);
            }
            return Organisateur;
        }





        public async Task<Uri> AjoutOrganisateur(Organisateur organisateur)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Organisateurs", organisateur);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Uri> ModifierOrganisateur(Organisateur organisateur)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync("api/Organisateurs/" + organisateur.OrganisateurID, organisateur);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return null;
        }

        public async Task<Uri> DeleteOrganisateur(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("api/Organisateurs/" + id);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        /*******************************************Gestionnaire*************************************************/
        public async Task<ICollection<Gestionnaire>> GetGestionnaire()
        {
            ICollection<Gestionnaire> Gestionnaire = new List<Gestionnaire>();
            HttpResponseMessage response = client.GetAsync("api/Gestionnaires").Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                Gestionnaire = JsonConvert.DeserializeObject<List<Gestionnaire>>(resp);
            }
            return Gestionnaire;
        }


        public async Task<Gestionnaire> GetLoginGestionnaire(string email, string mdp)
        {
            Gestionnaire Gestionnaire = null;
            HttpResponseMessage response = client.GetAsync("api/Gestionnaires/GetLoginGestionnaire/" + email + "/" + mdp).Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                Gestionnaire = JsonConvert.DeserializeObject<Gestionnaire>(resp);
            }
            return Gestionnaire;
        }
    }

}