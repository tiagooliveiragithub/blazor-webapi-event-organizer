using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Date { get; set; }
        public DateTime Hour { get; set; }
        public string Localization { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int MaxCapacity { get; set; }
        public int? OwnerId { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}
