using EduConnect.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EduConnect.Controllers
{
    public class ContactController : Controller
    {
        // afiseaza /Contact
        [HttpGet]
        public ActionResult Index()
        {
            return View(new ContactVm());
        }

        // primeste datele din formular
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(ContactVm model)
        {
            if (!ModelState.IsValid)
                return View(model);        // daca sunt erori de validare, ramanem in pagina

            try
            {
                await SendMailAsync(model, GetSmtp()); // trimitem mailul
                ViewBag.Sent = true;        // flag pentru mesaj de succes in View
            }
            catch (SmtpException)
            {
                // logheaza-l cum doresti
                ModelState.AddModelError("", "Nu am putut trimite mesajul. incearca din nou mai tarziu.");
            }

            return View(new ContactVm());   // golim formularul dupa trimitere
        }

        private static SmtpClient GetSmtp()
        {
            return new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential(
                                        "dorin.buh@gmail.com",   // user
                                        "tqnptjmvtrvbsxze")      // App Password de 16 caractere
            };
        }

        /* ----------------- functia privata care trimite efectiv mailul ----------------- */
        private static async Task SendMailAsync(ContactVm m, SmtpClient smtp)
        {
            string body = $@"De la: {m.Name} ({m.Email}) Subiect: {m.Subject}{m.Message}";

            var mail = new MailMessage
            {
                From = new MailAddress("dorin.buh@gmail.com", "EduConnect"),   // trebuie sa fie IDENTIC cu contul autentificat
                Subject = $"[Contact] {m.Subject}",
                Body = body,
                IsBodyHtml = false
            };
            mail.To.Add("buhna.dorin@gmail.com");        // adresa la care vrei sa ajunga mesajele

            await smtp.SendMailAsync(mail);
        }
    }
}
