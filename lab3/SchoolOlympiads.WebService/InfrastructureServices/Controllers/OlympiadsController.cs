using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolOlympiads.DomainObjects;

namespace SchoolOlympiads.WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OlympiadsController : ControllerBase
    {
        private readonly ILogger<OlympiadsController> _logger;

        public OlympiadsController(ILogger<OlympiadsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Olympiad> GetOlympiad()
        {
            return new List<Olympiad>() 
            { 
                new Olympiad() 
                { 
                    Id = 1,                   
                    Name = "Всероссийская олимпиада по технологии",
                    Subject = "Технология ",
                    Type = "Всероссийская олимпиада",
                    Class = "7 - 11",
                    Year = 2015                    
                } 
            };
        }
    }
}
