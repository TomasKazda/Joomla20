using Microsoft.AspNetCore.Identity;

namespace Joomla20.Models
{
    public class JUser: IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
