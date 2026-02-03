
namespace Entities
{
    public class User
    {
        private Guid Id { get; set; }
        private string Name { get; set; }
        private string Email { get; set; }

        public User (Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
        
    }
}
