using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Final_Project.Models;

namespace Final_Project.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Final_Project.Models.ProjectDbContext _context;

        public IndexModel(Final_Project.Models.ProjectDbContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public int PageNum {get; set;} = 1;
        public int PageSize {get; set;} = 10;

        [BindProperty(SupportsGet = true)]
        public string CurrentSort {get; set;}


        public async Task OnGetAsync()
        {
            var query = _context.Book.Select(b => b);

            switch (CurrentSort)
            {
                case "first_asc":
                    query = query.OrderBy(b => b.Title);
                    break;
                case "first_desc":
                    query = query.OrderBy(b => b.Title);
                    break;
            }
            if (_context.Book != null)
            {
                Book = await query.Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync();
        }
    }
}
}