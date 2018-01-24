using ng2trello_backend.Models.Serializable;

namespace ng2trello_backend.Models
{
    public class User
    {
        public User()
        {

        }

        public User(SerUser user)
        {
            Id = user.Id;
            Username = user.Username;
            Role = user.Role;
            Email = user.Email;
            AvatarUrl = user.AvatarUrl;
            Description = user.Description;
            Preferences = user.Preferences;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string AvatarUrl { get; set; }
        public string Description { get; set; }
        public string Preferences { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
