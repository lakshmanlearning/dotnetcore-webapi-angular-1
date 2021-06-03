using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_WebAPI_Angular.Models
{
    public class AppSettingsOptions
    {
        public string MyConnectionString { get; set; }
        public string ConnectionString { get; set; }
        public string EnvironmentName { get; set; }
        public string EnvironmentSlotName { get; set; }
    }
}
