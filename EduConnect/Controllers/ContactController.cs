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
        {
            var contactEntity = new EduConnect.Domain.Entities.User.Contact
            {
                Name = model.Name,
                Email = model.Email,
                Subiect = model.Subiect,
                Message = model.Message
            };

            context.Contacts.Add(contactEntity);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        return View(model);
    }
}
