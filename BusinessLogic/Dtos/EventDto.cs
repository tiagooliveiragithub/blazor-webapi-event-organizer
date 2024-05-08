﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Localization { get; set; }
        public DateTime Date { get; set; }
        
        public int AvailableQty { get; set; }
        public int MaxCapacity { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
