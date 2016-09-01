using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACC.PTAutomated.Model
{
    public class Automatization
    {
        /// <summary>
        /// Projects title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The stating date to execution. If the value is null, the execution will be start after execution.
        /// </summary>
        public DateTime? Start { get; set; }
        /// <summary>
        /// The ending time for the execution. Set 'null' to avoid stoping execution at some time.
        /// </summary>
        public DateTime? End { get; set; }
        /// <summary>
        /// Number of repetitions, default value must be 0. this 
        /// </summary>
        public uint StopAt { get; set; }
        /// <summary>
        /// List of sequences (each sequence has events)
        /// </summary>
        public List<Sequence> Sequences { get; set; }

    }
}
