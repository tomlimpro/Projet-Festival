using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIFestival.Models;
using WebFestival.ControllersAPI;
using WebFestival.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace WebFestival.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            UserViewModel viewModel = new UserViewModel { Authentifie = false };
            //if (HttpContext.User.Identity.IsAuthenticated)
            //{
            //    viewModel.User = API.Instance.GetUser(HttpContext.User.Identity.Name).Result;
            //}
            //else
            //{
            //    HttpContext.User.Identity.;
            //}
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(UserViewModel viewModel)
        {
            //if (ModelState.IsValid)
            {
                User user = API.Instance.GetUser(viewModel.User.Email, viewModel.User.Mot_de_passe).Result;
                if (user != null)
                {
                    return Redirect("/Home/Index");
                }
                ModelState.AddModelError("User.Email", "Email et/ou mot de passe incorrect(s)");
            }
            return View(viewModel);
        }

        public ActionResult Deconnexion()
        {

            return Redirect("../Login/Index");
        }
    }
}