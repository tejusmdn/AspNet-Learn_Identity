using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Asp_NET_Learn_Identity.Pages
{
    using Asp_NET_Learn_Identity.ViewModels;
    using Microsoft.AspNetCore.Identity;

    public class LoginModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }


        public void OnGet()
        {
        }

        [BindProperty]
        public Login Model { get; set; }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var result = await this._signInManager.PasswordSignInAsync(Model.Email, Model.Password, Model.RememberMe, false);

                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(returnUrl) || returnUrl == "/")
                    {
                        return RedirectToPage("Index");
                    }
                    else
                    {
                        return RedirectToPage(returnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect Username or Password.");
                }
            }

            return Page();

        }
    }
}
