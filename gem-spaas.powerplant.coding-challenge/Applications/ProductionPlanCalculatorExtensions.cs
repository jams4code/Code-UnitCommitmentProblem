using gem_spaas.powerplant.coding_challenge.ViewModel;
using gem_spaas.powerplant_coding_challenge.Models;
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
                //Get the variable cost & update the P values
                powerplant.GetUnitCostAndUpdateP(payloads.Fuels);
            }
            //Rank Up the power plants according to cost metric
            payloads.Powerplants = payloads.Powerplants.OrderBy(x => x.UnitCost).ToList();

            //Use the minimum of powerplants to produce the needed load
            double currentPowerPlantProduction = 0;
            double load = payloads.Load;
            for (int i = 0; i < payloads.Powerplants.Count; i++)
            {
                Powerplant currentPowerplant = payloads.Powerplants[i];
                Powerplant nextPowerplant = null;
                if (i+1 < payloads.Powerplants.Count)
                    nextPowerplant = payloads.Powerplants[i + 1];
                currentPowerPlantProduction = 0;
                if(load > 0)
                {
                    if (load - currentPowerplant.Pmax >= 0)
                    {
                        //Check if the combinaison of the current powerplant and the next powerplant can produce all the current load amount.
                        if(nextPowerplant != null && load < currentPowerplant.Pmax + nextPowerplant.Pmax && load - currentPowerplant.Pmax < nextPowerplant.Pmin)
                        {
                            currentPowerPlantProduction = currentPowerplant.Pmax - nextPowerplant.Pmin;
                        }
                        else
                        {
                            currentPowerPlantProduction = currentPowerplant.Pmax;
                        }
                        load -= currentPowerPlantProduction;

                    }
                    else if (load - currentPowerplant.Pmin >= 0)
                    {
                        currentPowerPlantProduction = load;
                        load -= currentPowerPlantProduction;
                    }
                }
                
                productionplans.Add(new ProductionVm { PowerplantName = currentPowerplant.Name, Production = currentPowerPlantProduction });
            }

            return productionplans;
        }

        
    }
}
