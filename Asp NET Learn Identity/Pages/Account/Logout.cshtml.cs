using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Asp_NET_Learn_Identity.Pages
{
    using Microsoft.AspNetCore.Identity;

    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _singInManager;

        public LogoutModel(SignInManager<IdentityUser> singInManager)
        {
            _singInManager = singInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostLogoutAsync(string? returnUrl = null)
        {
            await this._singInManager.SignOutAsync();

            return RedirectToPage("Login");
        }

        public IActionResult OnPostCancel(string? returnUrl = null)
        {
            return RedirectToPage("Index");
        }
    }
}
