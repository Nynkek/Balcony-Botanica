using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalconyBotanica.Adapters.Database;
using BalconyBotanica.Hosts.Mapping;
using BalconyBotanica.Hosts.Models;
using Microsoft.AspNetCore.Mvc;

namespace BalconyBotanica.Hosts.Controllers
{
    [ApiController]
    [Route("v1/")]
    public class QuizController : ControllerBase
    {
        PlantRepository plantRepository = new();

        [HttpGet("getPlantTopThree")]
        public RecommendedPlants getPlantTopThree(
                [FromQuery] string balcony_sunlight,
                [FromQuery] int balcony_spaceSize,
                [FromQuery] string plant_watering,
                [FromQuery] string plant_function,
                [FromQuery] string plant_toxicity)
        {
            //TODO: with the questions filled in, 
            // we generate a top 3, that fits the questions 
            IEnumerable<PlantDataDbo> recommendedPlantsDbo = plantRepository.GetPlants();
            RecommendedPlants recommendedPlants = recommendedPlantsDbo.MapToRecommendedPlants();

            return recommendedPlants;
        }

        [HttpGet("getPlantTopOne")]
        public RecommendedPlants getPlantTopOne()
        {
            //TODO: with the questions filled in, 
            // we generate an plant

            IEnumerable<PlantDataDbo> recommendedPlantDbo = plantRepository.GetPlantById(2);
            RecommendedPlants recommendedPlant = recommendedPlantDbo.MapToRecommendedPlants();

            return recommendedPlant;
        }
    }
}