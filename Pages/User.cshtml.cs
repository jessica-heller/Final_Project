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

    // Extra Credit Step 1: We need a professor property
    // User will select which professor they want, so this must use BindProperty
    [BindProperty]
    public User User {get; set;} = default!;

    public UserModel (ProjectDbContext context, ILogger<UserModel> logger)
    {
        _context = context; // Read in DbContext here
        _logger = logger;
    }

    public void OnGet()
    {
        Users = _context.User.ToList();
        UserDropDown = new SelectList(Users, "UserId", "FirstName");
    }

    public void OnPost()
    {
       
        User = _context.User.Find(User.UserId)!;
        Users = _context.User.ToList();
        UserDropDown = new SelectList(Users, "UserId", "FirstName");
    }
}