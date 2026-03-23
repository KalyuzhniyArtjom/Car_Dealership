using Car_Dealership.Data;
using Car_Dealership.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Car_Dealership.Pages.Clients
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Client Client { get; set; }

        public IActionResult OnGet(int id)
        {
            Client = _context.Clients.Find(id);

            if (Client == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            var student = _context.Clients.Find(Client.Id);

            if (student != null)
            {
                _context.Clients.Remove(student);
                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}