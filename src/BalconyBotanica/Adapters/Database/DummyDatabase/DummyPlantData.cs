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
            wateringSchedule = WateringSchedule.FREQUENT,
            sunlight = [Sunlight.FULL_SUN],
            toxicity = [Toxicity.POISONOUS_TO_PETS, Toxicity.POISONOUS_TO_HUMANS]
        };

        readonly PlantDataDbo plantData2 = new()
        {
            id = "2",
            common_name = "Rose",
            scientific_name = ["Rosa"],
            other_name = ["Garden Rose", "Wild Rose"],
            cycle = "Perennial",
            wateringSchedule = WateringSchedule.AVERAGE,
            sunlight = [Sunlight.FULL_SUN, Sunlight.PART_SHADE],
            toxicity = [Toxicity.POISONOUS_TO_HUMANS]

        };

        readonly PlantDataDbo plantData3 = new()
        {
            id = "3",
            common_name = "Tulip",
            scientific_name = ["Tulipa"],
            other_name = ["Garden Tulip"],
            cycle = "Perennial",
            wateringSchedule = WateringSchedule.AVERAGE,
            sunlight = [Sunlight.FULL_SUN, Sunlight.PART_SHADE],
            toxicity = [Toxicity.POISONOUS_TO_PETS]

        };

        readonly PlantDataDbo plantData4 = new()
        {
            id = "4",
            common_name = "Cactus",
            scientific_name = ["Cactaceae"],
            other_name = ["Cacti", "Succulent"],
            cycle = "Perennial",
            wateringSchedule = WateringSchedule.MINIMUM,
            sunlight = [Sunlight.FULL_SUN],
            toxicity = [Toxicity.NONE]

        };

        readonly PlantDataDbo plantData5 = new()
        {
            id = "5",
            common_name = "Lavender",
            scientific_name = ["Lavandula"],
            other_name = ["English Lavender", "French Lavender"],
            cycle = "Perennial",
            wateringSchedule = WateringSchedule.AVERAGE,
            sunlight = [Sunlight.FULL_SUN],
            toxicity = [Toxicity.NONE]

        };

        readonly PlantDataDbo plantData6 = new()
        {
            id = "5",
            common_name = "Lavender shade",
            scientific_name = ["Lavandula"],
            other_name = ["English Lavender", "French Lavender"],
            cycle = "Perennial",
            wateringSchedule = WateringSchedule.MINIMUM,
            sunlight = [Sunlight.FULL_SHADE],
            toxicity = [Toxicity.NONE]

        };

        public PlantDataDbo[] ReturnDummyPlant()
        {
            PlantDataDbo[] plant = [plantData1];

            return plant;
        }

        public PlantDataDbo[] ReturnDummyPlants()
        {
            PlantDataDbo[] plants = [plantData1, plantData2, plantData3, plantData4, plantData5, plantData6];

            return plants;
        }
    }
}