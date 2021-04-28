using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_WebAPI_Angular_DTO;
using DotNet_WebAPI_Angular_InterfaceContracts.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotNet_WebAPI_Angular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMemberService _memberService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMemberService memberService)
        {
            _logger = logger;
            _memberService = memberService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("GetAllMembers")]
        public async Task<IActionResult> GetAllMembers()
        {
            return Ok(await _memberService.GetAllMembers());
        }
    }
}
