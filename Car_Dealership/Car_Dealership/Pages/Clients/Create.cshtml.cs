using Car_Dealership.Data;
using Car_Dealership.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Car_Dealership.Pages.Clients
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Client Client { get; set; }
        public void OnGet() { }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Clients.Add(Client);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}