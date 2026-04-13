namespace Car_Dealership.Model
{
    public class Car : EFModel
    {
        public decimal Price { get; set; }
        public string? Title { get; set; }
        public int? YearOfManufacture { get; set; }
        public string? Сountry { get; set; }
        public int BrandId { get; set; }  
        public BrandCar? Brand { get; set; }
    }
}
 