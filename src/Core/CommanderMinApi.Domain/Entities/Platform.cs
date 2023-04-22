using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Domain.Entities
{
    public class Platform
    {
        public Guid PlatformId { get; set; }
        public string PlatformName { get; set; } = string.Empty;
        public string PlatformDescription { get; set; } = string.Empty;
        public string PlatformImageUrl { get; set; } = string.Empty;
        public virtual ICollection<CommandLine> CommandLineList { get; set; } = new List<CommandLine>();
    }
}
