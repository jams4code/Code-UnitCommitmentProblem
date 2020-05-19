using gem_spaas.powerplant.coding_challenge.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gem_spaas.powerplant_coding_challenge.Models
{
    /**
     * Represents a powerplants at disposal to generate the demanded load
    **/
    public class Powerplant
    {

        public string Name { get; set; }
        public string Type { get; set; }
        public double Efficiency { get; set; }
        public int Pmin { get; set; }
        public int Pmax { get; set; }
        public double UnitCost { get; set; }
        /** 
         * This function will set a unit cost for the powerplant depending on the type, the efficiency and the pmax. A
         * And it will update the Pmin and Pmax of the powerplant that are a "windturbine" to take the wind in consideration. It's the real Pmin and Pmax in a certain weather condition.
        **/
        public void GetUnitCostAndUpdateP(Fuel fuel)
        {
            double fuelPrice = -1;
            switch (Type)
            {
                case "gasfired":
                    fuelPrice = fuel.Gas;
                    break;
                case "turbojet":
                    fuelPrice = fuel.Kerosine;
                    break;
                case "windturbine":
                    fuelPrice = 0;
                    this.Pmin = Convert.ToInt32(this.Pmin * fuel.Wind/100);
                    this.Pmax = Convert.ToInt32(this.Pmax * fuel.Wind/100);
                    break;
                default:
                    throw new Exception($"Bad Type of powerplant for powerplant named : {this.Name}");
            }
            if(fuelPrice < 0 || this.Pmin < 0 || this.Pmax < 0 || this.Pmax < this.Pmin)
            {
                throw new Exception($"Bad values for powerplant named : {this.Name}");
            }
                
            this.UnitCost = (fuelPrice / this.Efficiency)/this.Pmax;
        }
        
    }
}
