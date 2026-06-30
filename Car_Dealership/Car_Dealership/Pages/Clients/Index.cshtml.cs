using Car_Dealership.Data;
using Car_Dealership.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Car_Dealership.Pages.Clients
{
    public class IndexModel : PageModel
    {
       
            private readonly ApplicationDbContext _context;
            public IndexModel(ApplicationDbContext context)
            {
                _context = context;
            }
            public List<Client> Client { get; set; }
            public void OnGet()
            {
                Client = _context.Clients.ToList();
            }
        
    }
   
}

