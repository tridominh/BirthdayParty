using Microsoft.AspNetCore.Identity;
namespace BirthdayParty.Models
{
    public class User : IdentityUser
    {
        public string? Jwt {get;set;}
    }
}
