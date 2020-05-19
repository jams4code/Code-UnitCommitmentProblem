using gem_spaas.powerplant.coding_challenge.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gem_spaas.powerplant.coding_challenge.NewFolder
{
    /**
     * This extension represent the business logic to calculate how much power each of a multitude of different powerplants need to produce 
     * when the load is given and taking into account the cost of the underlying energy sources.
     * 
    **/
    public static class ProductionPlanCalculatorExtensions
    {
        /**
         * Intuitive logic: Organize the powerplants by cost (Ascending low -> high) and use the right amount to have the load. 
         * 
        **/
        public static IEnumerable<ProductionVm> Calculate(PayloadVm payloads)
        {
            ICollection<ProductionVm> productionplans = new List<ProductionVm>();
            foreach (var powerplant in payloads.Powerplants)
            {
                powerplant.GetUnitCost(payloads.Fuels);
            }
            payloads.Powerplants = payloads.Powerplants.OrderBy(x => x.UnitCost).ToList();
            int currentPowerPlantProduction = 0;
            int load = payloads.Load;
            foreach (var powerplant in payloads.Powerplants)
            {
                currentPowerPlantProduction = 0;
                if(load > 0)
                {
                    if (load - powerplant.Pmax >= 0)
                    {
                        currentPowerPlantProduction = powerplant.Pmax;
                        load -= currentPowerPlantProduction;
                    }
                    else if (load - powerplant.Pmin >= 0)
                    {
                        currentPowerPlantProduction = powerplant.Pmax - load;
                        load -= currentPowerPlantProduction;
                    }
                }
                
                productionplans.Add(new ProductionVm { PowerplantName = powerplant.Name, Production = currentPowerPlantProduction });
            }

            return productionplans;
        }

        
    }
}
