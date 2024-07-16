using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalconyBotanica.Core.DomainObjects;

namespace BalconyBotanica.Adapters.Database
{
    public class PlantDataDbo
    {
        public required string id;
        public required string common_name;
        public required string[] scientific_name;
        public string[]? other_name;
        public string? cycle;
        public required WateringSchedule? wateringSchedule;
        public required Sunlight[] sunlight;
        public required Toxicity[] toxicity;
    }
}