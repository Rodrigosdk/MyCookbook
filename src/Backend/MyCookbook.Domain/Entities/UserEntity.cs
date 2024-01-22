using MyCookbook.Domain.SeedWork;

namespace MyCookbook.Domain.Entities
{
    public class UserEntity : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; } 
    }
}
