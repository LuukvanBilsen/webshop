using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace WebShop.Presentation.Accounts
{
    public class LoginModel : PageModel
    {
        private SignInManager<IdentityUser> signInManager;

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        [BindProperty]
        public LoginViewModel Input { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var result = await signInManager.PasswordSignInAsync(Input.Username, Input.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToPage("/Admin/Index");
            }
            {
                return Page();
            }


        }
    }

    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
