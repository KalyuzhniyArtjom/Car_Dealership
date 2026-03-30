using Car_Dealership.Data;
using Car_Dealership.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Car_Dealership.Pages.Cars
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Car Car { get; set; }

        public IActionResult OnGet(int id)
        {
            Car = _context.Cars.FirstOrDefault(b => b.Id == id);

            if (Car == null)
                return NotFound();

            return Page();
        }
    }
}
