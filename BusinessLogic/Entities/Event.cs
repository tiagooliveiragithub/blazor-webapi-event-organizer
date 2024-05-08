using BusinessLogic.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventOrganize.Models
{
    public partial class Event
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public DateTime Hour { get; set; }

        public string Localization { get; set; }

        public string Description { get; set; }

        public int MaxCapacity { get; set; }

        public int OwnerId { get; set; }

        public int CategoryId { get; set; }

        public virtual User? Owner { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Activity> Activities { get; set; } = new HashSet<Activity>();

        public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}
