using System.ComponentModel.DataAnnotations;

namespace Car_Dealership.Model
{
    public class Car : EFModel
    {
        [Required(ErrorMessage = "Цена обязательна")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Цена должна быть положительной")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Введите название автомобиля")]
        [StringLength(100, ErrorMessage = "Название не может превышать 100 символов")]
        public string? Title { get; set; }

        [Range(1900, 2026, ErrorMessage = "Год выпуска должен быть между 1900 и 2026")]
        public int? YearOfManufacture { get; set; }

        [StringLength(50, ErrorMessage = "Страна не может превышать 50 символов")]
        public string? Country { get; set; }

        [Required(ErrorMessage = "Укажите идентификатор бренда")]
        public int? BrandCarId { get; set; }

        public BrandCar? BrandCar { get; set; }
    }
}