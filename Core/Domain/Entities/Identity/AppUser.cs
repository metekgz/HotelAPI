using Microsoft.AspNetCore.Identity;
namespace Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public string NameSurname { get; set; }
        public string? RefleshToken { get; set; }
        public DateTime? RefleshTokenEndDate { get; set; }
    }
}
