using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Final_Project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Final_Project.Pages;

public class UserModel : PageModel
{
    private readonly ProjectDbContext _context;
    private readonly ILogger<UserModel> _logger;
    public List<User> Users {get; set;} = default!;
    public SelectList UserDropDown {get; set;} = default!;

    [BindProperty]
    public new User User {get; set;} = default!;

    public UserModel (ProjectDbContext context, ILogger<UserModel> logger)
    {
        _context = context; 
        _logger = logger;
    }

    public void OnGet()
    {
        Users = _context.User.ToList();
        UserDropDown = new SelectList(Users, "UserId", "FirstName");
    }

    public void OnPost()
    {
       
        User = _context.User.Include(u => u.UserBooks).ThenInclude(ub => ub.Book).Where(u => u.UserId == User.UserId).First();
        Users = _context.User.ToList();
        UserDropDown = new SelectList(Users, "UserId", "FirstName");
    }
}
