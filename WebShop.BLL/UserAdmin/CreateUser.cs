using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebShop.BLL.UserAdmin
{
    [Service]
    public class CreateUser
    {
        private readonly UserManager<IdentityUser> userManager;

        public CreateUser(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public class UserName
        {
            public string UserNameOfAccount { get; set; }
        }

        public async Task<bool> DoCreateUser(UserName name)
        {
            var managerUser = new IdentityUser()
            {
                UserName = name.UserNameOfAccount
            };

            var result = await userManager.CreateAsync(managerUser, "password");

            var managerClaim = new Claim("Role", "Manager");
            var claimResult = await userManager.AddClaimAsync(managerUser, managerClaim);

            return (result.Succeeded && claimResult.Succeeded);
        }
    }
}
