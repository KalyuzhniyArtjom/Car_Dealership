namespace Car_Dealership.Model
{
    public class Car : EFModel
    {
        public int Price { get; set; }
        public string? Title { get; set; }
        public DateTime YearOfManufacture { get; set; }
        public string? Сountry { get; set; }
        public BrandCar Brand { get; set; } = new BrandCar();
    }
}
 