using Laborator_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Policy;

namespace Laborator_2.Pages.Publishers
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
        public Models.Publisher Publisher { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Publisher.Add(Publisher);
            await _context.SaveChangesAsync();
            TempData["Message"] = $"Publisher {Publisher.PublisherName} created successfully!";
            return RedirectToPage("./Index");
        }
    }
}
