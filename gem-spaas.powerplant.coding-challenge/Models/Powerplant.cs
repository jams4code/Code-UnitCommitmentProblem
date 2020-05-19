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
        public void GetUnitCost(Fuel fuel)
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
                    break;
                default:
                    throw new Exception($"Bad Type of powerplant for powerplant named : {this.Name}");
            }
            this.UnitCost = fuelPrice / this.Efficiency;
        }
    }
}
