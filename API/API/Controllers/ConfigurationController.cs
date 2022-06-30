using API.BL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("configuration")]
    public class ConfigurationController : ControllerBase
    {
        private readonly ILogger<ConfigurationController> _logger;
        private readonly IConfigurationBL _bl;

        public ConfigurationController(ILogger<ConfigurationController> logger, IConfigurationBL bl)
        {
            _logger = logger;
            _bl = bl;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _bl.InsertConfigurationData();
            
            List<BL.Entities.SystemConfiguration> systemConfigurations = _bl.GetAllConfigurationData();

            return Ok(systemConfigurations);
        }
    }
}
