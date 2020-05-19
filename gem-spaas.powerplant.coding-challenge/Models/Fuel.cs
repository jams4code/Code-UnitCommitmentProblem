using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace gem_spaas.powerplant_coding_challenge.Models
{
    /**
     * Represents the fuel cost price by type used by the powerplants
    **/
    public class Fuel
    {
        [JsonPropertyName("gas(euro/MWh)")]
        public double Gas { get; set; }
        [JsonPropertyName("kerosine(euro/MWh)")]
        public double Kerosine { get; set; }
        [JsonPropertyName("co2(euro/ton)")]
        public double Co2 { get; set; }
        [JsonPropertyName("wind(%)")]
        public double Wind { get; set; } //Wind Cost = 0 | Wind % = wind speed
    }
}
