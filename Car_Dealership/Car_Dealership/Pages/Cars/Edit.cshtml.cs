using Car_Dealership.Data;
using Car_Dealership.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Car_Dealership.Pages.Cars
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; }

        public IActionResult OnGet(int id)
        {
            Car = _context.Cars
                .Where(c => c.Id == id)
                .Include(c => c.Brand)
                .FirstOrDefault();

            if (Car == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Cars.Update(Car);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
