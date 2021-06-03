using DotNet_WebAPI_Angular.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_WebAPI_Angular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyValuesController : ControllerBase
    {
        private readonly ILogger<MyValuesController> _logger;
        private readonly IOptions<AppSettingsOptions> _appSettings;
        public MyValuesController(ILogger<MyValuesController> logger, IOptions<AppSettingsOptions> appsettings)
        {
            _logger = logger;
            _appSettings = appsettings;
        }

        [HttpGet]
        [Route("GetAppSettings")]
        public AppSettingsOptions GetAppSettings()
        {
            var appSettings = new AppSettingsOptions()
            {
                MyConnectionString = _appSettings.Value.MyConnectionString,
                ConnectionString = _appSettings.Value.ConnectionString,
                EnvironmentName = _appSettings.Value.EnvironmentName,
                EnvironmentSlotName = _appSettings.Value.EnvironmentSlotName
            };
            return appSettings;
            //return Ok(appSettings);
        }
    }
}
