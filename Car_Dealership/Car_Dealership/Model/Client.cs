namespace Car_Dealership.Model
{
    public class Client : EFModel
    {
        public string? FullName { get; set; }
        public DateTime VisitDate { get; set; }
        public string? PhoneNumber { get; set; }
        public int TableNumber { get; set; }
        
    }
}
