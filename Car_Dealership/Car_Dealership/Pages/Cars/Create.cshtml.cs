using Car_Dealership.Data;
using Car_Dealership.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Car_Dealership.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; }

        public void OnGet()
        {
             BrandCars = new SelectList(_context.BrandCars.ToList(), "Id", "Name");
        }

        public SelectList BrandCars { get; set; }   

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Cars.Add(Car);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
