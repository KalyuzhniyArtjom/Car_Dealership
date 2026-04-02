namespace Car_Dealership.Model
{
    public class Car : EFModel
    {
        public int Price { get; set; }
        public string? Manufacturer { get; set; }
        public DateTime YearOfManufacture { get; set; }

    }
}
 