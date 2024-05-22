using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalconyBotanica.Adapters.Database.DummyDatabase;
using BalconyBotanica.Core.DomainObjects;

namespace BalconyBotanica.Adapters.Database
{
    //  data access concerns only.
    public class PlantRepository : IPlantRepository
    {
        DummyDatabase.DummyDatabase dummyPlantData = new();

        public IEnumerable<PlantDataDbo> GetPlantById(int plantId)
        {
            return dummyPlantData.ReturnDummyPlant();
        }

        public IEnumerable<PlantDataDbo> GetPlants()
        {
            return dummyPlantData.ReturnDummyPlants();
        }
    }
}