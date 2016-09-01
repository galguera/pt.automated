using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACC.PTAutomated.Model
{
    public class Sequence: BaseModel
    {
        public int Order { get; set; }
        public ushort Repeat { get; set; }
        public decimal Duration { get; set; }
        /// <summary>
        /// Time before execution (in seconds)
        /// </summary>
        public double DelayBefore {get; set; }
        /// <summary>
        /// Time delay after next execution (in seconds)
        /// </summary>
        public double DelayAfter { get; set; }
        /// <summary>
        /// Defines if the event is disabled
        /// </summary>
        public bool IsDisabled { get; set; }
        public List<Event> Events { get; set; }


        public Sequence()
        {
            Id = Guid.NewGuid();
            Repeat = 0;
            Title = "New sequence";
            DelayAfter = 0;
            DelayBefore = 0;

        }
    }
}
