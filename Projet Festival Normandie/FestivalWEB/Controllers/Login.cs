using FestivalAPI.Data;
using FestivalAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wpfFestival.ControllersAPI;

namespace FestivalWEB.Controllers
{
    public class Login : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string email, string mot_de_passe)
        {
            if(email != null && mot_de_passe != null)
            {
                Organisateur orga = API.Instance.GetOrganisateur(email, mot_de_passe).Result;
                if(orga != null)
                {

                    HttpContext.Session.SetString("Prenom", orga.Prenom);
                    HttpContext.Session.SetString("Nom", orga.Nom);
                    HttpContext.Session.SetString("email", email);
                    HttpContext.Session.SetString("categorie", "Organisateur");
                    return Redirect("/MvcFestivals/Index");
                }
                else
                {
                    Festivalier festivalier = API.Instance.GetFestivalier(email, mot_de_passe).Result;
                    if(festivalier != null)
                    {
                   
                        HttpContext.Session.SetString("email", email);
                        HttpContext.Session.SetString("categorie", "Festivalier");
                        return Redirect("/Home/Index");
                    }
                }
            }
            return View();
        }



        public IActionResult Deconnection()
        {
            HttpContext.Session.Clear();
            return Redirect("/Home/Index");
        }
        public bool CheckLogin()
        {
            if (HttpContext.Session.GetString("Email") != null) return true;
            return false;
        }

    }
}
