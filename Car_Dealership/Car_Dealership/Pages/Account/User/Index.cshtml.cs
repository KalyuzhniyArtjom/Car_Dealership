using Car_Dealership.Data;
using Car_Dealership.Model;
using Car_Dealership.Model.AuthApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Car_Dealership.Pages.Account.User
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AuthUser> Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = await _context.AuthUsers.ToListAsync();
        }
    }
}
