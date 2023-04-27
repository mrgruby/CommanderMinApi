using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Domain.Entities
{
    public class CommandLineEntity
    {
        [Key]
        public Guid CommandLineId { get; set; }
        public string HowTo { get; set; } = string.Empty;
        public string CommandLine { get; set; } = string.Empty;
        public string PlatformName { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public Guid PlatformId { get; set; }
        public virtual PlatformEntity? Platform { get; set; }
    }
}
