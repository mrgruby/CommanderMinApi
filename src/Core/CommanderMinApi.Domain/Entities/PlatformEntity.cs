using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Domain.Entities
{
    public class PlatformEntity
    {
        [Key]
        public Guid PlatformId { get; set; }
        public string PlatformName { get; set; } = string.Empty;
        public string PlatformDescription { get; set; } = string.Empty;
        public string PlatformImageUrl { get; set; } = string.Empty;
        public virtual ICollection<CommandLineEntity> CommandLineList { get; set; } = new List<CommandLineEntity>();
    }
}
