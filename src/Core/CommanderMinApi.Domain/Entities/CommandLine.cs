using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Domain.Entities
{
    public class CommandLine
    {
        public Guid CommandLineId { get; set; }
        public string HowTo { get; set; } = string.Empty;
        public string Line { get; set; } = string.Empty;
        public string PlatformName { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public Guid PlatformId { get; set; }
        public virtual Platform? Platform { get; set; }
    }
}
