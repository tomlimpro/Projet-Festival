using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using APIFestival.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace WebFestival.ControllersAPI
{
    public sealed class API
    {
        private static readonly HttpClient client = new HttpClient();

        private API()
        {
            {
                client.BaseAddress = new Uri("http://localhost:63857/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }
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

        public async Task<User> GetUser(int id)
        {
            User user = null;
            HttpResponseMessage response = client.GetAsync("api/Users/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<User>(resp);
            }
            return user;
        }

        public async Task<User> GetUser(string idString)
        {
            int id;
            if (int.TryParse(idString, out id))
                return await GetUser(id);
            return null;
        }

        public async Task<User> GetUser(string Email, string Mot_de_passe)
        {
            User user = null;
            HttpResponseMessage response = client.GetAsync("api/users/" + Email+ "/" + Mot_de_passe).Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<User>(resp);
            }
            return user;
        }
        /*public async Task<ICollection<TypeDeCharge>> GetType_De_Charge()
        {
            ICollection<TypeDeCharge> Type_De_Charges = new List<TypeDeCharge>();
            HttpResponseMessage response = client.GetAsync("api/TypeDeCharges").Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                Type_De_Charges = JsonConvert.DeserializeObject<List<TypeDeCharge>>(resp);
            }
            return Type_De_Charges;
        }
        public async Task<ICollection<Offre>> GetOffre()
        {
            ICollection<Offre> Offres = new List<Offre>();
            HttpResponseMessage response = client.GetAsync("api/Offres").Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                Offres = JsonConvert.DeserializeObject<List<Offre>>(resp);
            }
            return Offres;
        }
        public async Task<ICollection<Commentaire>> GetCommentaire()
        {
            ICollection<Commentaire> commentaires = new List<Commentaire>();
            HttpResponseMessage response = client.GetAsync("api/Commentaires").Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                commentaires = JsonConvert.DeserializeObject<List<Commentaire>>(resp);
            }
            return commentaires;
        }
        public async Task<ICollection<Trajectoire>> GetSommeTrajectoireCommentaire()
        {
            ICollection<Trajectoire> trajectoires = new List<Trajectoire>();
            HttpResponseMessage response = client.GetAsync("api/Trajectoires/Commentaires").Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                trajectoires = JsonConvert.DeserializeObject<List<Trajectoire>>(resp);
            }
            return trajectoires;
        }



        public async Task<ICollection<Realise>> GetSommeTDCRealise()
        {
            ICollection<Realise> realises = new List<Realise>();
            HttpResponseMessage response = client.GetAsync("api/Realises/TypeDeCharges").Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                realises = JsonConvert.DeserializeObject<List<Realise>>(resp);
            }
            return realises;
        }
        public async Task<ICollection<Trajectoire>> GetSommeTTDC()
        {
            ICollection<Trajectoire> trajectoires = new List<Trajectoire>();
            HttpResponseMessage response = client.GetAsync("api/Trajectoires/TypeDeCharges").Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                trajectoires = JsonConvert.DeserializeObject<List<Trajectoire>>(resp);
            }
            return trajectoires;
        }
        public async Task<ICollection<Realise>> GetSommeParOffre()
        {
            ICollection<Realise> Realises = new List<Realise>();
            HttpResponseMessage response = client.GetAsync("api/Realises/Offres").Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                Realises = JsonConvert.DeserializeObject<List<Realise>>(resp);
            }
            return Realises;
        }
        public async Task<ICollection<Trajectoire>> GetSommeTrajectoireOffre()
        {
            ICollection<Trajectoire> Trajectoires = new List<Trajectoire>();
            HttpResponseMessage response = client.GetAsync("api/Trajectoires/Offres").Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                Trajectoires = JsonConvert.DeserializeObject<List<Trajectoire>>(resp);
            }
            return Trajectoires;
        }*/

        

    }
}
