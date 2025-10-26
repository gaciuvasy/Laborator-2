using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Laborator_2.Models;

namespace Laborator_2.Pages.Publishers
{
    public class DetailsModel : PageModel
    {
        private readonly Gaciu_Vasile_Lab2.Data.Gaciu_Vasile_Lab2Context _context;

        public DetailsModel(Gaciu_Vasile_Lab2.Data.Gaciu_Vasile_Lab2Context context)
        {
            _context = context;
        }

        public Publisher Publisher { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                TempData["Error"] = "Publisher can not have id: null!";
                return RedirectToPage("./Index");
            }

            var publisher = await _context.Publisher.FirstOrDefaultAsync(m => m.ID == id);
            if (publisher == null)
            {
                TempData["Error"] = "Publisher not found!";
                return RedirectToPage("./Index");
            }
            else
            {
                Publisher = publisher;
            }
            return Page();
        }
    }
}
