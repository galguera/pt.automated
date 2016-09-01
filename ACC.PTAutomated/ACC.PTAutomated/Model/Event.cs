using ACC.PTAutomated.DataTypes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACC.PTAutomated.Model
{
    public class Event: BaseModel
    {
        public EventsType Type { get; set; }
        public int Order { get; set; }
        public double DelayBefore { get; set; }
        public double DelayAfter { get; set; }
        public EventData Data { get; set; }
        public string Comment { get; set; }

        public Event()
        {
            Id = Guid.NewGuid();
            Title = "New event";
            DelayAfter = 0;
            DelayBefore = 0;
            Type = EventsType.MouseMove;
            Data = new EventData() { X = 0, Y = 0 };
            Comment = "";
        }
    }
}
