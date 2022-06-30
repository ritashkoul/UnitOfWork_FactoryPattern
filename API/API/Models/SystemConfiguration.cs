using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class SystemConfiguration
    {
        public int SystemConfigurationKey { get; set; }
        public int SortOrder { get; set; }
        public string CurrentValue { get; set; }
        public string PreviousValue { get; set; }
    }
}
