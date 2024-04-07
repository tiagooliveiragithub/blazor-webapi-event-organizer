using System.ComponentModel.DataAnnotations;

namespace EventOrganize.Models
{
    public enum UserType
    {
        Participant = 0,
        Organizer = 1,
        UserManager = 2,
        Admin = 3,
    }

    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public UserType Type { get; set; }

        public IEnumerable<Event>? Events { get; set; }

        public IEnumerable<Ticket>? Tickets { get; set; }

    }
}
