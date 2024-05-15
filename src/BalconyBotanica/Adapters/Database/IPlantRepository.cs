using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalconyBotanica.Core.DomainObjects;

namespace BalconyBotanica.Adapters.Database
{
    public interface IPlantRepository
    {
        IEnumerable<PlantData> GetPlants();
        PlantData GetPlantById(int plantId);
    }
}