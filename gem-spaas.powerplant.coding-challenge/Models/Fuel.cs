using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gem_spaas.powerplant_coding_challenge.Models
{
    /**
     * Represents the fuel cost price by type used by the powerplants
    **/
    public class Fuel
    {
        public double Gas { get; set; }
        public double Kerosine { get; set; }
        public double Co2 { get; set; }
        public double Wind { get; set; } //Wind Cost = 0 | Wind % = wind speed
    }
}
