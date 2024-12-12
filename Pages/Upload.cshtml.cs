using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MemoriesApp.Pages
{
    public class UploadModel : PageModel
    {
        [BindProperty]
        public IFormFile MemoryFile { get; set; }

        [BindProperty]
        public string Description { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (MemoryFile != null)
            {
                var uploadsPath = Path.Combine("wwwroot", "uploads");
                Directory.CreateDirectory(uploadsPath);

                var filePath = Path.Combine(uploadsPath, MemoryFile.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await MemoryFile.CopyToAsync(stream);
                }
            }

            return RedirectToPage("Display");
        }
    }
}
