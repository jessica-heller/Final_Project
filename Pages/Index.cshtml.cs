using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Final_Project.Pages;

public class IndexModel : PageModel
{
    public IActionResult OnPostGoToUsers()
        {
            return RedirectToPage("User");
        }

        public IActionResult OnPostGoToBooks()
        {
            return RedirectToPage("/Books/Index");
        }
    }