using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gaciu_Vasile_Lab2.Data;
using Nume_Pren_Lab2.Models;

namespace Laborator_2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Gaciu_Vasile_Lab2.Data.Gaciu_Vasile_Lab2Context _context;

        public IndexModel(Gaciu_Vasile_Lab2.Data.Gaciu_Vasile_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Book = await _context.Book.ToListAsync();
        }
    }
}
