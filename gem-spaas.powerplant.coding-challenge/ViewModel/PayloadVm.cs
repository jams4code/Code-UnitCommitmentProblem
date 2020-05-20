using gem_spaas.powerplant_coding_challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gem_spaas.powerplant.coding_challenge.ViewModel
{
    public class PayloadVm
    {
        public double Load { get; set; }
        public Fuel Fuels { get; set; }
        public List<Powerplant> Powerplants { get; set; }
    }
}
