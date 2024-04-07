namespace EventOrganize.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Type { get; set; }
        public string Msg { get; set; } = null!;
        public double Price { get; set; }
        public int Rating { get; set; }

        public virtual Event? Event { get; set; }
        public virtual User? Owner { get; set; }
    }
}
