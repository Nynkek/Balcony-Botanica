using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalconyBotanica.Core.DomainObjects;

namespace BalconyBotanica.Adapters.Database
{
    //  data access concerns only.
    public class PlantRepository : IPlantRepository
    {
        public PlantData GetPlantById(int plantId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlantData> GetPlants()
        {
            throw new NotImplementedException();
        }
    }
}