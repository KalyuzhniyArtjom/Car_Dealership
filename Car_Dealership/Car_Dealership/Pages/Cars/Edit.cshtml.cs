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

        // Добавляем список брендов для выпадающего списка
        public List<BrandCar> Brands { get; set; }

        public IActionResult OnGet(int id)
        {
            Car = _context.Cars
                .Where(c => c.Id == id)
                .Include(c => c.BrandCar)
                .FirstOrDefault();

            if (Car == null)
                return NotFound();

            // Загружаем список брендов для выбора
            Brands = _context.BrandCars.ToList();

            return Page();
        }

        public IActionResult OnPost()
        {
            // Проверяем, что выбран бренд
            if (Car.BrandCarId == 0)
            {
                ModelState.AddModelError("Car.BrandCarId", "Пожалуйста, выберите бренд");
                Brands = _context.BrandCars.ToList();
                return Page();
            }

            if (!ModelState.IsValid)
            {
                Brands = _context.BrandCars.ToList();
                return Page();
            }

            // Находим существующую машину в базе
            var existingCar = _context.Cars.Find(Car.Id);
            if (existingCar == null)
                return NotFound();

            // Проверяем, существует ли выбранный бренд
            var brandExists = _context.BrandCars.Any(b => b.Id == Car.BrandCarId);
            if (!brandExists)
            {
                ModelState.AddModelError("Car.BrandCarId", "Выбранный бренд не существует");
                Brands = _context.BrandCars.ToList();
                return Page();
            }

            // Обновляем поля
            existingCar.Title = Car.Title;
            existingCar.Price = Car.Price;
            existingCar.YearOfManufacture = Car.YearOfManufacture;
            existingCar.Country = Car.Country;
            existingCar.BrandCarId = Car.BrandCarId;

            // Сохраняем изменения
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}