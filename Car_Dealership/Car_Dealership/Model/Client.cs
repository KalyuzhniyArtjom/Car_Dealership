using System.ComponentModel.DataAnnotations;

namespace Car_Dealership.Model
{
    public class Client : EFModel
    {
        [Required(ErrorMessage = "Необходимо заполнить имя!")]
        public string? FullName { get; set; }
        public DateTime VisitDate { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        
    }
}
