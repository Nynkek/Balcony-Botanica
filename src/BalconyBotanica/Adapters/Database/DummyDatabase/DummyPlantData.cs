using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            watering = "FREQUENT",
            sunlight = ["FULL_SUN"]
        };

        readonly PlantDataDbo plantData2 = new()
        {
            id = "2",
            common_name = "Rose",
            scientific_name = new string[] { "Rosa" },
            other_name = new string[] { "Garden Rose", "Wild Rose" },
            cycle = "Perennial",
            watering = "AVERAGE",
            sunlight = new string[] { "FULL_SUN", "PART_SHADE" }
        };

        readonly PlantDataDbo plantData3 = new()
        {
            id = "3",
            common_name = "Tulip",
            scientific_name = new string[] { "Tulipa" },
            other_name = new string[] { "Garden Tulip" },
            cycle = "Perennial",
            watering = "AVERAGE",
            sunlight = new string[] { "FULL_SUN", "PART_SHADE" }
        };

        readonly PlantDataDbo plantData4 = new()
        {
            id = "4",
            common_name = "Cactus",
            scientific_name = new string[] { "Cactaceae" },
            other_name = new string[] { "Cacti", "Succulent" },
            cycle = "Perennial",
            watering = "MINIMUM",
            sunlight = new string[] { "FULL_SUN" }
        };

        readonly PlantDataDbo plantData5 = new PlantDataDbo
        {
            id = "5",
            common_name = "Lavender",
            scientific_name = new string[] { "Lavandula" },
            other_name = new string[] { "English Lavender", "French Lavender" },
            cycle = "Perennial",
            watering = "AVERAGE",
            sunlight = new string[] { "FULL_SUN" }
        };



        public PlantDataDbo ReturnDummyPlant()
        {

            return plantData1;
        }

        public PlantDataDbo[] ReturnDummyPlants()
        {
            PlantDataDbo[] plants = [plantData1, plantData2, plantData3, plantData4, plantData5];

            return plants;
        }
    }
}