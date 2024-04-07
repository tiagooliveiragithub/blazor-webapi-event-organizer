namespace EventOrganize.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Date { get; set; }
        public DateTime Hour { get; set; }
        public string Description { get; set; } = null!;
        public Event? Event { get; internal set; }
    }
}
