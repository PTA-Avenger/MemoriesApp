using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MemoriesApp.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public IActionResult OnPost()
        {
            // Simple login logic (hardcoded for simplicity)
            if ((Username == "Thato" && Password == "22November") || 
                (Username == "Ofentse" && Password == "22November")) // Replace with your logic or DB check
            {
                // Store login status in session
                HttpContext.Session.SetString("LoggedIn", "true");

                // Redirect to home page
                return RedirectToPage("/Index");
            }

            // If login fails, stay on the login page
            ViewData["ErrorMessage"] = "Invalid credentials, please try again.";
            return Page();
        }

        public void OnGet()
        {
            // Check if user is already logged in (session-based)
            var isLoggedIn = HttpContext.Session.GetString("LoggedIn");
            if (!string.IsNullOrEmpty(isLoggedIn))
            {
                // If logged in, redirect to home page
                RedirectToPage("/Index");
            }
        }
    }
}
