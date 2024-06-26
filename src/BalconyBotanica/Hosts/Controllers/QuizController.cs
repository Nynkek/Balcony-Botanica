using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BalconyBotanica.Adapters.Database;
using BalconyBotanica.Core.Algorithm;
using BalconyBotanica.Core.DomainObjects;
using BalconyBotanica.Hosts.Mapping;
using BalconyBotanica.Hosts.Models;
using Microsoft.AspNetCore.Mvc;

namespace BalconyBotanica.Hosts.Controllers
{
    [ApiController]
    [Route("v1/")]
    public class QuizController : ControllerBase
    {
        readonly PlantRepository plantRepository = new();
        readonly Recommender recommender = new();

        [HttpGet("getPlantTopThree")]
        public ActionResult GetPlantTopThree(
                [FromQuery, Required] string sunlight,
                [FromQuery] int spaceSizeSquareMeters,
                [FromQuery, Required] string wateringSchedule,
                [FromQuery] string plantFunction,
                [FromQuery] string toxicity)
        {
            QuizAnswers quizAnswers = ParseQuizAnswers(sunlight, spaceSizeSquareMeters, wateringSchedule, plantFunction, toxicity);
            IEnumerable<PlantDataDbo> recommendedPlantsDbo = plantRepository.GetPlants();
            RecommendedPlants recommendedPlants = recommendedPlantsDbo.MapToRecommendedPlants();

            var result = recommender.Recommend(recommendedPlants, quizAnswers);

            TrimPlantsArrayToLenght(result, lenght: 3);


            return Ok(result);
        }



        [HttpGet("getPlantTopOne")]
        public RecommendedPlants GetPlantTopOne()
        {
            //TODO: for testing purpose only. This one has no Path Query's (yet).

            IEnumerable<PlantDataDbo> recommendedPlantDbo = plantRepository.GetPlantById(2);
            RecommendedPlants recommendedPlant = recommendedPlantDbo.MapToRecommendedPlants();

            return recommendedPlant;
        }

        private static QuizAnswers ParseQuizAnswers(string sunlight, int spaceSizeSquareMeters, string wateringSchedule, string plantFunction, string toxicity)
        {
            if (!Enum.TryParse(sunlight, true, out Sunlight parsedSunlight))
            {
                throw new Exception(nameof(sunlight) + " can't be empty.");
            }

            if (!Enum.TryParse(wateringSchedule, true, out WateringSchedule parsedWateringSchedule))
            {
                throw new Exception(nameof(wateringSchedule) + " can't be empty.");
            }

            if (!Enum.TryParse(plantFunction, true, out PlantFunction parsedPlantFunction))
            {
                parsedPlantFunction = PlantFunction.NONE;
            }

            if (!Enum.TryParse(toxicity, true, out Toxicity parsedToxicity))
            {
                parsedToxicity = Toxicity.NONE;
            }

            QuizAnswers quizAnswers = new(
                        sunlight: parsedSunlight,
                        spaceSizeSquareMeters: spaceSizeSquareMeters,
                        wateringSchedule: parsedWateringSchedule,
                        plantFunction: parsedPlantFunction,
                        toxicity: parsedToxicity
            );
            return quizAnswers;
        }
        public void TrimPlantsArrayToLenght(RecommendedPlants recommendedPlants, int lenght)
        {
            if (recommendedPlants.Plants.Length > lenght)
            {
                recommendedPlants.Plants = recommendedPlants.Plants.Take(lenght).ToArray();
            }
        }
    }
}