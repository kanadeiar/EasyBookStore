using Microsoft.AspNetCore.Identity;

namespace EasyBookStore.Domain.Models.Identity
{
    public class Role : IdentityRole
    {
        public const string Administrators = "Administrators";
        public const string Users = "Users";
    }
}
