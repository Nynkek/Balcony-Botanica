using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalconyBotanica.Core.DomainObjects;

namespace BalconyBotanica.Adapters.Database.DummyDatabase
{
    public class DummyDatabase
    {

        readonly PlantDataDbo plantData1 = new()
        {
            id = "1",
            common_name = "Sunflower",
            scientific_name = ["Helianthus annuus"],
            other_name = ["Helianthus", "Common Sunflower"],
            cycle = "Annual",
            WateringSchedule = WateringSchedule.FREQUENT,
            sunlight = [Sunlight.FULL_SUN]
        };

        readonly PlantDataDbo plantData2 = new()
        {
            id = "2",
            common_name = "Rose",
            scientific_name = ["Rosa"],
            other_name = ["Garden Rose", "Wild Rose"],
            cycle = "Perennial",
            WateringSchedule = WateringSchedule.AVERAGE,
            sunlight = [Sunlight.FULL_SUN, Sunlight.PART_SHADE]
        };

        readonly PlantDataDbo plantData3 = new()
        {
            id = "3",
            common_name = "Tulip",
            scientific_name = ["Tulipa"],
            other_name = ["Garden Tulip"],
            cycle = "Perennial",
            WateringSchedule = WateringSchedule.AVERAGE,
            sunlight = [Sunlight.FULL_SUN, Sunlight.PART_SHADE]
        };

        readonly PlantDataDbo plantData4 = new()
        {
            id = "4",
            common_name = "Cactus",
            scientific_name = ["Cactaceae"],
            other_name = ["Cacti", "Succulent"],
            cycle = "Perennial",
            WateringSchedule = WateringSchedule.MINIMUM,
            sunlight = [Sunlight.FULL_SUN]
        };

        readonly PlantDataDbo plantData5 = new()
        {
            id = "5",
            common_name = "Lavender",
            scientific_name = ["Lavandula"],
            other_name = ["English Lavender", "French Lavender"],
            cycle = "Perennial",
            WateringSchedule = WateringSchedule.AVERAGE,
            sunlight = [Sunlight.FULL_SUN]
        };

        public PlantDataDbo[] ReturnDummyPlant()
        {
            // TODO: return plant via algorithm
            PlantDataDbo[] plant = [plantData1];

            return plant;
        }

        public PlantDataDbo[] ReturnDummyPlants()
        {
            // TODO: return plant via algorithm
            PlantDataDbo[] plants = [plantData1, plantData2, plantData3, plantData4, plantData5];

            return plants;
        }
    }
}