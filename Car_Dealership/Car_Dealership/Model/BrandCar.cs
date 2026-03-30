namespace Car_Dealership.Model
{
    public class BrandCar : EFModel
    {
        public List<Car> Car { get; set; } = new List<Car>();
    }
}
