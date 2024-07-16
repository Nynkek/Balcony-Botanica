using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using BalconyBotanica.Adapters.Database;
using BalconyBotanica.Core.DomainObjects;
using BalconyBotanica.Hosts.Models;

namespace BalconyBotanica.Hosts.Mapping
{
    public static class PlantDataDboMapper
    {
        public static RecommendedPlants MapToRecommendedPlants(this IEnumerable<PlantDataDbo> plantDataDboList)
        {
            return new RecommendedPlants
            {
                Plants = plantDataDboList.MapToPlantData()
            };
        }

        public static PlantData[] MapToPlantData(this IEnumerable<PlantDataDbo> plantDataDboList)
        {
            PlantData[] plantDataArray = plantDataDboList.Select(dbo => new PlantData
            {
                Id = dbo.id,
                Common_name = dbo.common_name,
                Scientific_name = dbo.scientific_name,
                Other_name = dbo.other_name,
                Cycle = dbo.cycle,
                WateringSchedule = (WateringSchedule)dbo.wateringSchedule!,
                Sunlight = dbo.sunlight!,
                Toxicity = dbo.toxicity!,
            }).ToArray();

            return plantDataArray;
        }
    }
}