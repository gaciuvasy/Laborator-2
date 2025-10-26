using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Laborator_2.Models;

namespace Laborator_2.Pages.Publishers
{
    public class DeleteModel : PageModel
    {
        private readonly Gaciu_Vasile_Lab2.Data.Gaciu_Vasile_Lab2Context _context;

        public DeleteModel(Gaciu_Vasile_Lab2.Data.Gaciu_Vasile_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                TempData["Error"] = "Publisher can not have id: null!";
            }

            var publisher = await _context.Publisher
                                    .Where(p => p.ID == id)
                                    .Include(p => p.Books)
                                    .FirstOrDefaultAsync();
            if (publisher != null && (publisher.Books == null || publisher.Books.Count == 0))
            {
                Publisher = publisher;
                _context.Publisher.Remove(Publisher);
                await _context.SaveChangesAsync();
                TempData["Message"] = $"Publisher {publisher.PublisherName} deleted successfully!";
            } 
            else if (publisher == null)
            {
                TempData["Error"] = "Publisher not found";
            }
            else
            {
                TempData["Error"] = $"Publisher {publisher.PublisherName} has books associated and cannot be deleted.";
            }

            return RedirectToPage("./Index");
        }
    }
}
