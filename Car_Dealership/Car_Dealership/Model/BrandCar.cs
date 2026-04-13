namespace Car_Dealership.Model
{
    public class BrandCar : EFModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Car> Car { get; set; } = new List<Car>();
    }
}
