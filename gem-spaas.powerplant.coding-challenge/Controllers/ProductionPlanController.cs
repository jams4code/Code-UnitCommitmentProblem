using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gem_spaas.powerplant.coding_challenge.NewFolder;
using gem_spaas.powerplant.coding_challenge.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace gem_spaas.powerplant.coding_challenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductionPlanController : ControllerBase
    {
        private readonly ILogger<ProductionPlanController> _logger;

        public ProductionPlanController(ILogger<ProductionPlanController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<IEnumerable<ProductionVm>> GetProduction([FromBody] PayloadVm payloads)
        {
            var production = ProductionPlanCalculatorExtensions.Calculate(payloads);
            if(production == null)
            {
                return BadRequest();
            }
            return Ok(production);
        }
    }
}
