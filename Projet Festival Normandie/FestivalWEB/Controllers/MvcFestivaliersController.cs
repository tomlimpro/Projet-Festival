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

namespace FestivalWEB.Controllers
{
    public class MvcFestivaliersController : Controller
    {
        private readonly FestivalAPIContext _context;

        public MvcFestivaliersController(FestivalAPIContext context)
        {
            _context = context;
        }

        // GET: MvcFestivaliers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Festivaliers.ToListAsync());
        }

        // GET: MvcFestivaliers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var festivalier = await _context.Festivaliers
                .FirstOrDefaultAsync(m => m.IdUser == id);
            if (festivalier == null)
            {
                return NotFound();
            }

            return View(festivalier);
        }

        // GET: MvcFestivaliers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MvcFestivaliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUser,Nom,Prenom,Mot_de_passe,Email,Genre,Telephone,Code_postal,Commune,Pays,Date_de_naissance,EmailConfirme")] Festivalier festivalier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(festivalier);
                await _context.SaveChangesAsync();
                BuildEmailTemplate(festivalier.IdUser, festivalier.Email);
                return RedirectToAction(nameof(Index));
            }
            return View(festivalier);
        }

        // GET: MvcFestivaliers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var festivalier = await _context.Festivaliers.FindAsync(id);
            if (festivalier == null)
            {
                return NotFound();
            }
            return View(festivalier);
        }

        // POST: MvcFestivaliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUser,Nom,Prenom,Mot_de_passe,Email,Genre,Telephone,Code_postal,Commune,Pays,Date_de_naissance,EmailConfirme")] Festivalier festivalier)
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

        // GET: MvcFestivaliers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var festivalier = await _context.Festivaliers
                .FirstOrDefaultAsync(m => m.IdUser == id);
            if (festivalier == null)
            {
                return NotFound();
            }

            return View(festivalier);
        }

        // POST: MvcFestivaliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var festivalier = await _context.Festivaliers.FindAsync(id);
            _context.Festivaliers.Remove(festivalier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FestivalierExists(int id)
        {
            return _context.Festivaliers.Any(e => e.IdUser == id);
        }



        private void BuildEmailTemplate(int idUser, string email)
        {
            string body = System.IO.File.ReadAllText("EmailTemplate/MailTemplate.cshtml");
            var url = "http://localhost:64356/" + "Register/Confirm?regId=" + idUser;

            var mail = email;
            BuilEmailTemplate1("Votre compte a été créé avec succès", body, mail);
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

    }
}
