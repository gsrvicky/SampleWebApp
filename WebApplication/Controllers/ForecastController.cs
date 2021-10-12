using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public ForecastController()
        {
            
        }

        [HttpGet]
        public IEnumerable<Forecast> GetAll()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Forecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("GetWeather/{key}")]
        public IActionResult GetWeather(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                
                var rng = new Random();
                return Ok(new {data = new
                {
                    Date = DateTime.Now.AddDays(10),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = key
                }
                });
            }
            return Ok(new { data = string.Empty });
        }
    }
}
