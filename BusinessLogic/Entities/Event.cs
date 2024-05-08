
namespace BusinessLogic.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Localization { get; set; }
        public DateTime Date { get; set; }
        public int AvailableQty { get; set; }
        public int MaxCapacity { get; set; }
        public int CategoryId { get; set; }
    }
}
