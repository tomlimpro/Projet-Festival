using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FestivalAPI.Data;
using FestivalAPI.Models;
using SendGrid.Helpers.Mail;
using System.Text;
using System.Net.Mail;


namespace FestivalWEB.Controllers
{
    public class FestivaliersController : Controller
    {
        private readonly FestivalAPIContext _context;

        public FestivaliersController(FestivalAPIContext context)
        {
            _context = context;
        }

        // GET: Festivaliers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Festivalier.ToListAsync());
        }

        // GET: Festivaliers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var festivalier = await _context.Festivalier
                .FirstOrDefaultAsync(m => m.IdUser == id);
            if (festivalier == null)
            {
                return NotFound();
            }

            return View(festivalier);
        }

        // GET: Festivaliers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Festivaliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUser,Nom,Prenom,Mot_de_passe,Email,Genre,Telephone,Code_postal,Commune,Pays,Date_de_naissance")] Festivalier festivalier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(festivalier);
                await _context.SaveChangesAsync();
                BuildEmailTemplate(festivalier.IdUser,festivalier.Email);

                return RedirectToAction(nameof(Index));
            }
            return View(festivalier);
        }
        // renvoie vers la page de confirmation 
        public ActionResult Confirm(int idUser)
        {
            ViewBag.idUser = idUser;
            return View();
        }
       
       
        /// <summary>
        /// construit l'email de validation 
        /// </summary>
        /// <param name="idUser"></param>
        private void BuildEmailTemplate(int idUser,string email)
        {
            string body = System.IO.File.ReadAllText("C:/Users/emili/source/repos/Projet-Festival/Projet-Festival-Normandie/Projet Festival Normandie/FestivalWEB/EmailTemplate/MailTemplate.cshtml");
            var url = "http://localhost:63398" + "Register/Confirm?regId=" + idUser;
            // var festivalier = .Festivalier.Where<Festivalier>(m => m.IdUser == idUser).FirstOrDefault;
            var mail = email;
            BuilEmailTemplate1("Your Account Is succefully Created",body,mail);
        }

        public static void BuilEmailTemplate1(string subjectText, string bodyText,string sendTo)
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
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // GET: Festivaliers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var festivalier = await _context.Festivalier.FindAsync(id);
            if (festivalier == null)
            {
                return NotFound();
            }
            return View(festivalier);
        }

        // POST: Festivaliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUser,Nom,Prenom,Mot_de_passe,Email,Genre,Telephone,Code_postal,Commune,Pays,Date_de_naissance")] Festivalier festivalier)
        {
            if (id != festivalier.IdUser)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(festivalier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FestivalierExists(festivalier.IdUser))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(festivalier);
        }

        // GET: Festivaliers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var festivalier = await _context.Festivalier
                .FirstOrDefaultAsync(m => m.IdUser == id);
            if (festivalier == null)
            {
                return NotFound();
            }

            return View(festivalier);
        }

        // POST: Festivaliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var festivalier = await _context.Festivalier.FindAsync(id);
            _context.Festivalier.Remove(festivalier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FestivalierExists(int id)
        {
            return _context.Festivalier.Any(e => e.IdUser == id);
        }
    }
}
