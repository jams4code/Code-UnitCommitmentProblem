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
        public IEnumerable<ProductionVm> GetProduction([FromBody] PayloadVm payloads)
        {
            
            return ProductionPlanCalculatorExtensions.Calculate(payloads);
        }
    }
}
