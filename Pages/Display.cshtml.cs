using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MemoriesApp.Pages
{
    public class DisplayModel : PageModel
    {
        public List<string> Memories { get; set; }

        public void OnGet()
        {
            var uploadsPath = Path.Combine("wwwroot", "uploads");
            if (!Directory.Exists(uploadsPath))
            {
                Directory.CreateDirectory(uploadsPath);
            }

            Memories = Directory.GetFiles(uploadsPath)
                                .Select(Path.GetFileName)
                                .ToList();
        }
    }
}
