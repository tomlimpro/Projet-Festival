using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FestivalAPI.Data;
using FestivalAPI.Models;
using System.Text;
using System.Net.Mail;
using Microsoft.AspNetCore.Http;
using FestivalAPI.Controllers;


namespace FestivalWEB.Controllers
{
    public class MvcTarifsController : Controller
    {
        private readonly FestivalAPIContext _context;
        

        public string email { get; private set; }
        public string nom { get; private set; }
        public string prenom { get; private set; }
        public DateTime date_de_naissance { get; private set; }
        public MvcTarifsController(FestivalAPIContext context)
        {
            _context = context;
        }

        // GET: MvcTarifs
        public async Task<IActionResult> Index()
        {
            var festivalAPIContext = _context.Tarifs.Include(t => t.Festival);
            return View(await festivalAPIContext.OrderBy(i => i.Festival.Nom_Festival).ToListAsync());
        }

        // GET: MvcTarifs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
          
            var tarif = await _context.Tarifs
                .Include(t => t.Festival)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.TarifID == id);
            if (tarif == null)
            {
                return NotFound();
            }

            return View(tarif);
        }

        // GET: MvcTarifs/Create
        public IActionResult Create()
        {
            PopulateFestivalsDropDownList();
            return View();
        }

        // POST: MvcTarifs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TarifID,NomTarif,PrixTarif,QuantiteTotal,DescriptionTarif,FestivalID")] Tarif tarif)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarif);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateFestivalsDropDownList();
            return View(tarif);
        }

        // GET: MvcTarifs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarif = await _context.Tarifs
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.TarifID == id);

            if (tarif == null)
            {
                return NotFound();
            }
            PopulateFestivalsDropDownList(tarif.FestivalID);
            return View(tarif);
        }

        // POST: MvcTarifs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarifToUpdate = await _context.Tarifs
                .FirstOrDefaultAsync(c => c.TarifID == id);

            if (await TryUpdateModelAsync<Tarif>(tarifToUpdate,
                "",
                c => c.NomTarif, c => c.PrixTarif,c => c.QuantiteTotal, c => c.DescriptionTarif, c => c.FestivalID))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            PopulateFestivalsDropDownList(tarifToUpdate.FestivalID);
            return View(tarifToUpdate);
        }


        public async Task<IActionResult> Pagetarif(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarif = await _context.Tarifs
                .Include(m => m.Festival)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.TarifID == id);

            if (tarif == null)
            {
                return NotFound();
            }
            
            return View(tarif);
        }


        [HttpPost, ActionName("Pagetarif")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Pagetarifpost(int? id)
        {
            if (id == null)
            {
                return NotFound();
                
            }

            var tarifToUpdate = await _context.Tarifs
                .Include(c => c.Festival)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.TarifID == id);

            if (await TryUpdateModelAsync<Tarif>(tarifToUpdate,
                "",
                c => c.QuantiteTotal))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return Redirect("/MvcFestivals/Index");
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            
            return View(tarifToUpdate);
        }

        private void PopulateFestivalsDropDownList(object selectedFestival = null)
        {
            var festivalsQuery = from d in _context.Festivals
                                 orderby d.Nom_Festival
                                 select d;
            ViewBag.FestivalID = new SelectList(festivalsQuery.AsNoTracking(), "FestivalID", "Nom_Festival", selectedFestival);
        }

        // GET: MvcTarifs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarif = await _context.Tarifs
                .Include(t => t.Festival)
                .FirstOrDefaultAsync(m => m.TarifID == id);
            if (tarif == null)
            {
                return NotFound();
            }

            return View(tarif);
        }
        //GET userinformation
        public async Task<IActionResult> Acheter()
        {

            var email = HttpContext.Session.GetString("email");           
            
            var festivalier = await _context.Festivaliers
               .FirstOrDefaultAsync(m => m.Email == email);
            BuildEmailTemplate(festivalier.IdUser,festivalier.Email,festivalier.Nom,festivalier.Prenom,festivalier.Date_de_naissance);
            
            return View("../Home/Index");
        }

        // Construction et envoie de l'email récapitulatif 
        private void BuildEmailTemplate(int idUser, string email, string nom, string prenom, DateTime date_de_naissance)
        {
            // envoyer les infos à la page 
            string body = System.IO.File.ReadAllText("EmailTemplate/MailTemplateTarif.cshtml");
            //var url = "http://localhost:64356" + "Register/Confirm?regId=" + idUser;
            this.email = email;
            this.nom = nom;
            this.prenom = prenom;
            this.date_de_naissance = date_de_naissance;
                        
            BuilEmailTemplate1("Récapitulatif de vos achats", body, email);
        }


        public static void BuilEmailTemplate1(string subjectText, string bodyText, string sendTo)
        {
            string from, to, bcc, cc, subject, body;
            from = "FestivalNormandie@outlook.com";
            to = sendTo.Trim();
            bcc = "";
            cc = "";
            subject = subjectText;
            StringBuilder sb = new StringBuilder();
            sb.Append(bodyText);
            body = sb.ToString();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(new MailAddress(to));
            if (!string.IsNullOrEmpty(bcc))
            {
                mail.Bcc.Add(new MailAddress(bcc));
            }
            if (!string.IsNullOrEmpty(cc))
            {
                mail.CC.Add(new MailAddress(cc));
            }
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            SendEmail(mail);
        }

        public static void SendEmail(MailMessage mail)
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp-mail.outlook.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential("FestivalNormandie@outlook.com", "ProjetFestival04/05");
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // POST: MvcTarifs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarif = await _context.Tarifs.FindAsync(id);
            _context.Tarifs.Remove(tarif);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TarifExists(int id)
        {
            return _context.Tarifs.Any(e => e.TarifID == id);
        }



    }
}
