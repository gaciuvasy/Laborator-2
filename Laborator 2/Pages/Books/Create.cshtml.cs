using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gaciu_Vasile_Lab2.Data;
using Nume_Pren_Lab2.Models;

namespace Laborator_2.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Gaciu_Vasile_Lab2.Data.Gaciu_Vasile_Lab2Context _context;

        public CreateModel(Gaciu_Vasile_Lab2.Data.Gaciu_Vasile_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
