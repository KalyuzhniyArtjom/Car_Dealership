using Car_Dealership.Data;
using Car_Dealership.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Car_Dealership.Pages.Cars
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; }

        public IActionResult OnGet(int id)
        {
            Car = _context.Cars.Find(id);

            if (Car == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            var car = _context.Cars.Find(Car.Id);

            if (car != null)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}
