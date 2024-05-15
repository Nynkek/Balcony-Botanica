using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalconyBotanica.Adapters.Database
{
    public class PlantDataDbo
    {
        public string id;
        public string common_name;
        public string[] scientific_name;
        public string[] other_name;
        public string cycle;
        public string watering;
        public string[] sunlight;
    }
}