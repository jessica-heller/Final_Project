using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.Pages;

public class CreateUser : PageModel
{
    private readonly ILogger<CreateUser> _logger;

    [BindProperty]
    [Display(Name = "First Name")]
    [Required]
    [StringLength(60, MinimumLength = 3)]
    public string FirstName {get; set;} = string.Empty;

    [BindProperty]
    [Display(Name = "Last Name")]
    [Required]
    [StringLength(60, MinimumLength = 3)]
    public string LastName {get; set;} = string.Empty;

    [BindProperty]
    [Display(Name = "Email")]
    [EmailAddress]
    [Required]
    public string Email {get; set;} = string.Empty;

    public CreateUser(ILogger<CreateUser> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var newUser = new CustomUserModel
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email
        };

        return RedirectToPage("User");
    }

}

public class CustomUserModel
{
    [Required]
    [Display(Name = "First Name")]
    public string FirstName {get; set;} = string.Empty;

    [Required]
    [Display(Name = "LastName")]
    public string LastName {get; set;} = string.Empty;

    [Required]
    [Display(Name = "Email")]
    [EmailAddress]
    public string Email {get; set;} = string.Empty;
}