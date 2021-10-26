using Microsoft.AspNetCore.Identity;

namespace EasyBookStore.Domain.Models.Identity
{
    public class User : IdentityUser
    {
        public const string Administrator = "Admin";
        public const string DefaultAdminPassword = "12DBF150wifi@";
    }
}
