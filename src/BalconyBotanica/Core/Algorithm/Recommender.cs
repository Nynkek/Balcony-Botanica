using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalconyBotanica.Core.DomainObjects;
using BalconyBotanica.Hosts.Models;

namespace BalconyBotanica.Core.Algorithm

{
    /// <summary>
    /// provides a list of (generic) items when given a set of quiz-answers
    /// </summary>
    public class Recommender
    {
        // TODO: make Recommend more generic, for now I want it working
        public RecommendedPlants Recommend(RecommendedPlants insertedArray, QuizAnswers quizAnswers)
        {

            PlantData[] arrayToFilter = insertedArray.Plants;

            // TODO: did not test this yet, sunlight is an array, so it's a bit different from wateringSchedule

            arrayToFilter = arrayToFilter
            .Where(plantData =>
                plantData.Sunlight.Contains(quizAnswers.sunlight))
            .ToArray();

            arrayToFilter = arrayToFilter
                .Where(plantData =>
                    plantData.WateringSchedule <= quizAnswers.wateringSchedule)
                .OrderBy(plantData =>
                    plantData.WateringSchedule)
                .ToArray();


            arrayToFilter = arrayToFilter
                  .Where(x =>
                    x.Toxicity.All(s =>
                        s != quizAnswers.toxicity))
                  .ToArray();

            RecommendedPlants recommendedPlants = new()
            {
                Plants = arrayToFilter
            };

            return recommendedPlants;
        }
    }
}
