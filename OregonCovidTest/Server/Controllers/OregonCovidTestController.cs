using OregonCovidTest.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OregonCovidTest.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OregonCovidTestController : ControllerBase
    {
       
        private readonly ILogger<OregonCovidTestController> logger;
        private readonly CsvService csvService;

        public OregonCovidTestController(ILogger<OregonCovidTestController> logger, CsvService csvService)
        {
            this.logger = logger;
            this.csvService = csvService;
        }

        [HttpGet]
        public IEnumerable<Pin> Get()
        {
            var pins = csvService.Pins;
            return pins;
        }
    }
}
