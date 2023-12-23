using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhonesMVC.Data;
using PhonesMVC.Models;
using PhonesMVC.ViewModels;

namespace PhonesMVC.Controllers
{
    public class PhoneClientsController : Controller
    {
        private readonly MVCDbContext _context;
        public PhoneClientsController(MVCDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clients = await _context.PhoneClients.ToListAsync();

            return View(clients);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPhoneClientVM addRequest)
        {
            var client = new PhoneClient()
            {
                Id = Guid.NewGuid(),
                Surname = addRequest.Surname,
                Name = addRequest.Name,
                BirthDate = addRequest.BirthDate,
                Phone = addRequest.Phone,
                Address = addRequest.Address,
                Description = addRequest.Description
            };

            await _context.PhoneClients.AddAsync(client);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var client = await _context.PhoneClients.FirstOrDefaultAsync(x => x.Id == id);

            if (client == null) return View("Error");

            var updateClient = new UpdatePhoneClientVM()
            {
                Id = client.Id,
                Surname = client.Surname,
                Name = client.Name,
                BirthDate = client.BirthDate,
                Phone = client.Phone,
                Address = client.Address,
                Description = client.Description
            };

            return await Task.Run( () => View("View", updateClient));
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdatePhoneClientVM updateClient)
        {
            var client = await _context.PhoneClients.FindAsync(updateClient.Id);

            if (client == null) return View("Error");

            client.Surname = updateClient.Surname;
            client.Name = updateClient.Name;
            client.BirthDate = updateClient.BirthDate;
            client.Phone = updateClient.Phone;
            client.Address = updateClient.Address;
            client.Description = updateClient.Description;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdatePhoneClientVM updateClient)
        {
            var client = await _context.PhoneClients.FindAsync(updateClient.Id);

            if (client == null) return View("Error");

            _context.PhoneClients.Remove(client);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
