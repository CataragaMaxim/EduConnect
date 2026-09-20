using EduConnect.BusinessLogic.DBModel;
using EduConnect.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

public class ContactController : Controller
{
    private readonly UserContext context;

    public ContactController()
    {
        context = new UserContext();
    }

    // GET: Contact
    public ActionResult Index()
    {
        var domainContacts = context.Contacts.ToList();

        var viewModelContacts = domainContacts.Select(c => new Contact
        {
            Name = c.Name,
            Email = c.Email,
            Subiect = c.Subiect,
            Message = c.Message
        }).ToList();

        return View(viewModelContacts);
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

    // GET: Contact/Create
    public ActionResult Create()
    {
        return View(new Contact());
    }

    // POST: Contact/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(Contact model)
    {
        if (ModelState.IsValid)
        /* ----------------- functia privata care trimite efectiv mailul ----------------- */
        private static async Task SendMailAsync(ContactVm m, SmtpClient smtp)
        {
            var contactEntity = new EduConnect.Domain.Entities.User.Contact
            {
                Name = model.Name,
                Email = model.Email,
                Subiect = model.Subiect,
                Message = model.Message
                From = new MailAddress("dorin.buh@gmail.com", "EduConnect"),   // trebuie sa fie IDENTIC cu contul autentificat
                Subject = $"[Contact] {m.Subject}",
                Body = body,
                IsBodyHtml = false
            };
            mail.To.Add("buhna.dorin@gmail.com");        // adresa la care vrei sa ajunga mesajele

            context.Contacts.Add(contactEntity);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        return View(model);
    }
}
